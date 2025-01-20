using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleProdForms.Models;
using System.Drawing;

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
                                        producao_log (log_id, log_pd_codigo, log_pd_data, log_pd_qtd)VALUES ((SELECT IFNULL(MAX(log_id), 0) + 1 FROM producao_log), @codigo, @data, @quantidade)";
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
        public IEnumerable<MatProdModel> GetAllMatProd()
        {
            var matProdList = new List<MatProdModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT m.mp_codigo,
                                               m.mp_nome,
                                               m.mp_estoque
                                               FROM materia_prima m
                                               "; // Ajuste a consulta conforme necessário
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var matProd = new MatProdModel
                        {
                            CodigoMp = Convert.ToInt32(reader[0]),
                            NomeMp = reader[1].ToString(),
                            EstoqueMp =Convert.ToInt32(reader[2])
                        };
                        matProdList.Add(matProd);
                    }
                }
            }
            return matProdList;
        }

        public void AddMatProd(List<MatProdModel> matProdList)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;

                foreach (var matProd in matProdList)
                {
                    command.CommandText = @"INSERT INTO producao_materiaprima 
                                    (
                                    pmp_id,
                                    pmp_pr_codigo,
                                    pmp_mp_codigo, 
                                    pmp_qtd
                                    )
                                    VALUES ((SELECT IFNULL(MAX(pd_codigo), 0) + 1 FROM producao), @codigo, @codigoMp, @quantidade)";
                    command.Parameters.Clear();
                    command.Parameters.Add("@codigo", DbType.Int32).Value = matProd.CodigoPd;
                    command.Parameters.Add("@codigoMp", DbType.Int32).Value = matProd.CodigoMp;
                    command.Parameters.Add("@quantidade", DbType.Double).Value = matProd.QuantidadeMp;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<MatProdModel> GetMatProd(int matProdId)
        {
            var mpLista = new List<MatProdModel>();
            int id = int.TryParse(matProdId.ToString(), out _) ? Convert.ToInt32(matProdId) : 0;

            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();  
                command.Connection = connection;
                command.CommandText = @"SELECT
                                            m.mp_codigo,
                                            m.mp_estoque,
                                            m.mp_nome,
                                            p.pmp_qtd,
                                            p.pmp_data
                                        FROM producao_materiaprima p
                                        LEFT JOIN materia_prima m ON p.pmp_mp_codigo = m.mp_codigo
                                        INNER JOIN producao pr ON p.pmp_pr_codigo = pr.pd_pr_codigo
                                        WHERE 
                                            p.pmp_id = @codigo
                                        ";
                command.Parameters.Add("@codigo", DbType.Int32).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var matProd = new MatProdModel();
                        matProd.CodigoMp = Convert.ToInt32(reader[0]);
                        matProd.EstoqueMp = Convert.ToInt32(reader[1]);
                        matProd.NomeMp = reader[2].ToString();
                        matProd.QuantidadeMp = Convert.ToInt32(reader[3]);
                        mpLista.Add(matProd);
                    }
                }
            }

            return mpLista;
        }

        public void EditMatProd(List<MatProdModel> matProdList)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;

                foreach (var matProd in matProdList)
                {
                    command.CommandText = @"UPDATE producao_materiaprima
                                            SET pmp_qtd=@quantidade
                                            WHERE pmp_pr_codigo=@codigo AND pmp_mp_codigo=@codigoMp";
                    command.Parameters.Clear();
                    command.Parameters.Add("@codigo", DbType.Int32).Value = matProd.CodigoPd;
                    command.Parameters.Add("@codigoMp", DbType.Int32).Value = matProd.CodigoMp;
                    command.Parameters.Add("@quantidade", DbType.Double).Value = matProd.QuantidadeMp;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
