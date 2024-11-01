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
        public struct TempoData
        {
            public string Data { get; set; }
            public decimal Total { get; set; }
        }

        // Fields & Properties
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumProdutos { get; private set; }
        public int NumMat { get; private set; }
        public int NumProducao { get; private set; }
        public int TotalProducao{ get; private set; }
        public List<KeyValuePair<string, int>> TopProdutos { get; private set; }
        public List<KeyValuePair<string, int>> TopMateriaPrima { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<TempoData> ProducaoLista { get; private set; }

        // Constructor
        public CapaModel(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Private methods
        private void Numeros()
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                // Get Total Number of Customers
                command.CommandText = "select count(pr_codigo) from produtos";
                NumProdutos = Convert.ToInt32((long)command.ExecuteScalar());

                // Get Total Number of Suppliers
                command.CommandText = "select count(mp_codigo) from materia_prima";
                NumMat = Convert.ToInt32((long)command.ExecuteScalar());

                // Get Total Number of Products
                command.CommandText =  "select count(pd_pr_codigo) from producao";
                NumProducao = Convert.ToInt32((long)command.ExecuteScalar());

                // Get Total Number of Orders
                command.CommandText = @"select count(log_pd_id) from producao_log
                                        where log_pd_data between  @fromDate and @toDate";
                command.Parameters.Add("@fromDate", DbType.String).Value = startDate.ToString("yyyy-MM-dd");
                command.Parameters.Add("@toDate", DbType.String).Value = endDate.ToString("yyyy-MM-dd");
                TotalProducao = Convert.ToInt32((long)command.ExecuteScalar());
            }
        }

        private void AnaliseProduto()
        {
            TopProdutos = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                SQLiteDataReader reader;
                command.Connection = connection;
                command.CommandText = @"select P.pr_nome, sum(producao_log.log_pd_qtd) as Q
                                                from producao_log
                                                inner join produtos P on P.pr_codigo = producao_log.log_pd_codigo
                                                where log_pd_data between @fromDate and @toDate
                                                group by P.pr_nome
                                                order by Q desc 
                                                LIMIT 5";
                command.Parameters.Add("@fromDate", DbType.String).Value = startDate.ToString("yyyy-MM-dd");
                command.Parameters.Add("@toDate", DbType.String).Value = endDate.ToString("yyyy-MM-dd");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TopProdutos.Add(
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

        private void AnaliseMateriaPrima()
        {
            TopProdutos = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                SQLiteDataReader reader;
                command.Connection = connection;
                command.CommandText = @"select P.pr_nome, sum(producao_log.log_pd_qtd) as Q
                                                from producao_log
                                                inner join produtos P on P.pr_codigo = producao_log.log_pd_codigo
                                                where log_pd_data between @fromDate and @toDate
                                                group by P.pr_nome
                                                order by Q desc 
                                                LIMIT 5";
                command.Parameters.Add("@fromDate", DbType.String).Value = startDate.ToString("yyyy-MM-dd");
                command.Parameters.Add("@toDate", DbType.String).Value = endDate.ToString("yyyy-MM-dd");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TopProdutos.Add(
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


        private void AnalisePedido(string nome)
        {
            ProducaoLista = new List<TempoData>();

            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT pl.log_pd_data, SUM(pl.log_pd_qtd)
                                        FROM 
                                            producao_log pl
                                        LEFT JOIN produtos P ON P.pr_codigo = pl.log_pd_codigo
                                        WHERE 
                                            log_pd_data BETWEEN @fromDate AND @toDate
                                        AND (P.pr_nome LIKE @nomeProduto )
                                        GROUP BY log_pd_data";
                command.Parameters.Add("@fromDate", DbType.String).Value = startDate.ToString("yyyy-MM-dd");
                command.Parameters.Add("@toDate", DbType.String).Value = endDate.ToString("yyyy-MM-dd");
                command.Parameters.Add("@nomeProduto", DbType.String).Value = nome;

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
                    ProducaoLista = (from orderList in resultTable
                                        group orderList by orderList.Key.ToString("dd MMM")
                                       into order
                                        select new TempoData
                                        {
                                            Data = order.Key,
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }

                // Group by Weeks
                else if (numberDays <= 92)
                {
                    ProducaoLista = (from orderList in resultTable
                                        group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                        orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                        into order
                                        select new TempoData
                                        {
                                            Data = "Semana " + order.Key.ToString(),
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }

                // Group by Months
                else if (numberDays <= (365 * 2))
                {
                    bool isYear = numberDays <= 365 ? true : false;
                    ProducaoLista = (from orderList in resultTable
                                        group orderList by orderList.Key.ToString("MMM yyyy")
                                       into order
                                        select new TempoData
                                        {
                                            Data = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }

                // Group by Years
                else
                {
                    ProducaoLista = (from orderList in resultTable
                                        group orderList by orderList.Key.ToString("yyyy")
                                        into order
                                        select new TempoData
                                        {
                                            Data = order.Key,
                                            Total = order.Sum(amount => amount.Value)
                                        }).ToList();
                }
            }
        }



        // Public methods
        public bool LoadData(DateTime startDate, DateTime endDate, string nome)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                Numeros();
                AnaliseProduto();
                AnalisePedido(nome);
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
