using ControleProdForms._Repos;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ControleProdForms.Models
{
    public class CapaModel : RepoBase
    {
        public struct RevenueByDate
        {
            public string Data { get; set; }
            public decimal Total { get; set; }
        }

        // Fields & Properties
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        // Constructor
        public CapaModel(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Private methods
        private void GetNumberItems()
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                // Get Total Number of Customers
                command.CommandText = "select count(pd_pr_codigo) from producao";
                NumCustomers = Convert.ToInt32((long)command.ExecuteScalar());

                // Get Total Number of Suppliers
                command.CommandText = "select count(mp_codigo) from materia_prima";
                NumSuppliers = Convert.ToInt32((long)command.ExecuteScalar());

                // Get Total Number of Products
                command.CommandText = "select count(pr_codigo) from produtos";
                NumProducts = Convert.ToInt32((long)command.ExecuteScalar());

                // Get Total Number of Orders
                command.CommandText = @"select count(id) from [producao_log]" +
                                        "where log_pd_data between  @fromDate and @toDate";
                command.Parameters.Add("@fromDate", DbType.DateTime).Value = startDate;
                command.Parameters.Add("@toDate", DbType.DateTime).Value = endDate;
                NumOrders = Convert.ToInt32((long)command.ExecuteScalar());
            }
        }

        private void GetProductAnalisys()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                SQLiteDataReader reader;
                command.Connection = connection;
                // Get Top 5 products
                command.CommandText = @"select P.pr_nome, sum(producao.pd_qtd_produzida) as Q
                                                from producao
                                                inner join produtos P on P.pr_codigo = producao.pd_pr_codigo
                                                where pd_data between @fromDate and @toDate
                                                group by P.pr_nome
                                                order by Q desc ";
                command.Parameters.Add("@fromDate", DbType.String).Value = startDate;
                command.Parameters.Add("@toDate", DbType.String).Value = endDate;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TopProductsList.Add(
                        new KeyValuePair<string, int>(reader[0].ToString(), Convert.ToInt32(reader[1])));
                }
                reader.Close();

                // Get Understock
                command.CommandText = @"select pr_nome, pr_estoque
                                                from produtos
                                                where pr_estoque <= 6 and ativo = 1";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UnderstockList.Add(
                        new KeyValuePair<string, int>(reader[0].ToString(), Convert.ToInt32(reader[1])));
                }
                reader.Close();
            }
        }


        private void GetOrderAnalisys()
        {
            GrossRevenueList = new List<RevenueByDate>();

            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select log_pd_data, sum(log_pd_qtd)
                                                    from producao_log
                                                    where log_pd_data between '16/10/2024' and '23/10/2024'
                                                    group by log_pd_data";
                command.Parameters.Add("@fromDate", DbType.DateTime).Value = startDate;
                command.Parameters.Add("@toDate", DbType.DateTime).Value = endDate;
                var reader = command.ExecuteReader();
                var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                while (reader.Read())
                {
                    resultTable.Add(
                        new KeyValuePair<DateTime, decimal>(Convert.ToDateTime(reader[0]), Convert.ToDecimal(reader[1]))
                        );
                }

                reader.Close();
                if (numberDays <= 30)
                {
                    GrossRevenueList = (from orderList in resultTable
                                        group orderList by orderList.Key.ToString("dd MMM")
                                       into order
                                        select new RevenueByDate
                                        {
                                            Data = order.Key,
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }

                // Group by Weeks
                else if (numberDays <= 92)
                {
                    GrossRevenueList = (from orderList in resultTable
                                        group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                        orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                        into order
                                        select new RevenueByDate
                                        {
                                            Data = "Week " + order.Key.ToString(),
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }

                // Group by Months
                else if (numberDays <= (365 * 2))
                {
                    bool isYear = numberDays <= 365 ? true : false;
                    GrossRevenueList = (from orderList in resultTable
                                        group orderList by orderList.Key.ToString("MMM yyyy")
                                       into order
                                        select new RevenueByDate
                                        {
                                            Data = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }

                // Group by Years
                else
                {
                    GrossRevenueList = (from orderList in resultTable
                                        group orderList by orderList.Key.ToString("yyyy")
                                        into order
                                        select new RevenueByDate
                                        {
                                            Data = order.Key,
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }
            }
        }

        // Public methods
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItems();
                GetProductAnalisys();
                GetOrderAnalisys();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data not refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
        }
    }
}
