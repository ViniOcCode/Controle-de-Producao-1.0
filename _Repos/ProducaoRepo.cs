using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleProdForms.Models;

namespace ControleProdForms._Repos
{
    public class ProducaoRepo : RepoBase, IProducaoRepo
    {
        public ProducaoRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddProducao(ProducaoModel produto)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO 
                                        producao (pd_codigo, pd_pr_codigo, pd_data, pd_qtd_produzida) VALUES ((SELECT IFNULL(MAX(pd_codigo), 0) + 1 FROM producao), @codigo, @data, @quantidade)";
                command.Parameters.Add("@codigo", DbType.Int32).Value = produto.Codigo;
                command.Parameters.Add("@data", DbType.String).Value = produto.Data;
                command.Parameters.Add("@quantidade", DbType.Double).Value = produto.Quantidade;
                command.ExecuteNonQuery();
            }
        }

        public void AddProducaoLog(ProducaoModel produto)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO 
                                        producao_log (log_pd_codigo, log_pd_data, log_pd_qtd)VALUES (@codigo, @data, @quantidade)";
                command.Parameters.Add("@codigo", DbType.Int32).Value = produto.Codigo;
                command.Parameters.Add("@data", DbType.String).Value = produto.Data;
                command.Parameters.Add("@quantidade", DbType.Double).Value = produto.Quantidade;
                command.ExecuteNonQuery();
            }
        }

        public void DelProducao(int codigo)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"DELETE 
                                        FROM producao
                                        WHERE pd_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = codigo;
                command.ExecuteNonQuery();
            }
        }

        public void EditProducao(ProducaoModel produto)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE producao
                                        SET pd_data=@data, pd_qtd_produzida=@quantidade
                                        WHERE pd_pr_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = produto.Codigo;
                command.Parameters.Add("@data", DbType.String).Value = produto.Data;
                command.Parameters.Add("@quantidade", DbType.Int32).Value = produto.Quantidade;
                command.ExecuteNonQuery();
            }
        }

        public void PegaNome(ProducaoModel produto)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT pr_nome
                                            FROM produtos
                                            WHERE pr_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = produto.Codigo;
                if (produto.Codigo != string.Empty)
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produto.Nome = reader[0].ToString();
                        }
                    }
                }
                else
                {
                    produto.Nome = string.Empty;
                }
            }
        }

        public IEnumerable<ProducaoModel> GetAll()
        {
            var pdLista = new List<ProducaoModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT 
                                            p.pd_pr_codigo,
                                            pr.pr_nome,
                                            p.pd_data,
                                            p.pd_qtd_produzida,
                                            p.pd_codigo
                                        FROM produtos pr     
                                        INNER JOIN 
                                            producao p ON p.pd_pr_codigo = pr.pr_codigo 
                                        ORDER BY p.pd_data DESC
                                      ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producao = new ProducaoModel();
                        producao.Codigo = reader[0].ToString();
                        producao.Nome = reader[1].ToString();
                        producao.Data = reader[2].ToString();
                        producao.Quantidade = reader[3].ToString();
                        pdLista.Add(producao);

                        producao.Id = Convert.ToInt32(reader[4]);
                    }
                }
            }

            return pdLista;
        }

        public IEnumerable<ProducaoModel> GetByValue(string valor)
        {
            var pdLista = new List<ProducaoModel>();
            int pdCodigo = int.TryParse(valor, out _) ? Convert.ToInt32(valor) : 0;
            string pdNome = valor;
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT 
                                            p.pd_pr_codigo,
                                            pr.pr_nome,
                                            p.pd_data,
                                            p.pd_qtd_produzida
                                        FROM produtos pr     
                                        INNER JOIN 
                                            producao p ON p.pd_pr_codigo = pr.pr_codigo 
                                        WHERE 
                                             pd_pr_codigo=@codigo OR pr.pr_nome LIKE @nome";
                command.Parameters.Add("@codigo", DbType.Int32).Value = pdCodigo;
                command.Parameters.AddWithValue("@nome", "%" + pdNome + "%");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producao = new ProducaoModel();
                        producao.Codigo = reader[0].ToString();
                        producao.Nome = reader[1].ToString();
                        producao.Data = reader[2].ToString();
                        producao.Quantidade = reader[3].ToString();
                        pdLista.Add(producao);
                    }
                }
            }

            return pdLista;
        }
    }
}
