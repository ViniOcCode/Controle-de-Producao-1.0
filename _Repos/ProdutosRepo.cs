using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using ControleProdForms.Models;

namespace ControleProdForms._Repos
{
    public class ProdutosRepo : RepoBase, IProdutosRepo
    {
        //Construtor
        public ProdutosRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Metódos
        public void AddProduto(ProdutosModel produto)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO 
                                        Produtos VALUES (@codigo, @nome, @palete, @estoque, @ativo, @categoria)";
                command.Parameters.Add("@codigo", DbType.Int32).Value = produto.Codigo;
                command.Parameters.Add("@nome", DbType.String).Value = produto.Nome;
                command.Parameters.Add("@palete", DbType.Int32).Value = produto.Un_Palete;
                command.Parameters.Add("@estoque", DbType.Int32).Value = produto.Estoque;
                command.Parameters.Add("@ativo", DbType.Int32).Value = 1;
                command.Parameters.Add("@categoria", DbType.Int32).Value = produto.Categoria;
                command.ExecuteNonQuery();
            }
        }

        public void DesProduto(int codigo)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE Produtos 
                                        SET pr_ativo=0 
                                        WHERE pr_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = codigo;
                command.ExecuteNonQuery();
            }
        }



        public void DelProduto(int codigo)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"DELETE 
                                        FROM Produtos 
                                        WHERE pr_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = codigo;
                command.ExecuteNonQuery();
            }
        }
        public void EditProduto(ProdutosModel produto)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE Produtos 
                                        SET pr_nome=@nome, pr_un_palete=@palete, pr_estoque=@estoque, pr_ativo=1
                                        WHERE pr_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = produto.Codigo;
                command.Parameters.Add("@nome", DbType.String).Value = produto.Nome;
                command.Parameters.Add("@palete", DbType.Int32).Value = produto.Un_Palete;
                command.Parameters.Add("@estoque", DbType.Int32).Value = produto.Estoque;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProdutosModel> GetAll()
        {
            var prodLista = new List<ProdutosModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT 
                                        pr_codigo, pr_nome, pr_un_palete, pr_estoque, pr_categoria
                                        FROM produtos WHERE pr_ativo=1
                                        ORDER BY pr_estoque DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var produto = new ProdutosModel();
                        produto.Codigo = reader[0].ToString();
                        produto.Nome = reader[1].ToString();
                        produto.Un_Palete = reader[2].ToString();
                        produto.Estoque = reader[3].ToString();
                        produto.Categoria = Convert.ToInt32(reader[4]);
                        prodLista.Add(produto);
                    }
                }
            }

            return prodLista;
        }

        public IEnumerable<ProdutosModel> GetByValue(string valor)
        {
            var prodLista = new List<ProdutosModel>();

            int prodCodigo = int.TryParse(valor, out _) ? Convert.ToInt32(valor) : 0;
            string prodNome = valor;
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT 
                                              pr_codigo, pr_nome, pr_un_palete, pr_estoque, pr_categoria
                                        FROM produtos
                                        WHERE pr_codigo=@codigo OR pr_nome LIKE @nome";
                command.Parameters.AddWithValue("@codigo", prodCodigo);
                command.Parameters.AddWithValue("@nome", "%" + prodNome + "%");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var produto = new ProdutosModel();
                        produto.Codigo = reader[0].ToString();
                        produto.Nome = reader[1].ToString();
                        produto.Un_Palete = reader[2].ToString();
                        produto.Estoque = reader[3].ToString();
                        produto.Categoria = Convert.ToInt32(reader[4]);
                        prodLista.Add(produto);
                    }
                }
            }

            return prodLista;
        }

    }
}
