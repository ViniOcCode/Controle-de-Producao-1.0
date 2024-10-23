using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleProdForms.Models;
using System.Data.SQLite;
using System.Data;

namespace ControleProdForms._Repos
{
    public class MatRepo : RepoBase, IMatRepo
    {
        //Construtor
        public MatRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Metódos
        public void AddMateria(MatModel materia)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO 
                                        materia_prima VALUES (@codigo, @nome, @estoque)";
                command.Parameters.Add("@codigo", DbType.Int32).Value = materia.Codigo;
                command.Parameters.Add("@nome", DbType.String).Value = materia.Nome;
                command.Parameters.Add("@estoque", DbType.Int32).Value = materia.Estoque;
                command.ExecuteNonQuery();
            }
        }

        public void DelMateria(int codigo)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"DELETE 
                                        FROM materia_prima
                                        WHERE mp_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = codigo;
                command.ExecuteNonQuery();
            }
        }

        public void EditMateria(MatModel materia)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE materia_prima
                                        SET mp_nome=@nome, mp_estoque=@estoque 
                                        WHERE mp_codigo=@codigo";
                command.Parameters.Add("@codigo", DbType.Int32).Value = materia.Codigo;
                command.Parameters.Add("@nome", DbType.String).Value = materia.Nome;
                command.Parameters.Add("@estoque", DbType.Int32).Value = materia.Estoque;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<MatModel> GetAll()
        {
            var matLista = new List<MatModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT 
                                        *
                                        FROM materia_prima";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var materia = new MatModel();
                        materia.Codigo = reader[0].ToString();
                        materia.Nome = reader[1].ToString();
                        materia.Estoque = reader[2].ToString();
                        matLista.Add(materia);
                    }
                }
            }

            return matLista;
        }

        public IEnumerable<MatModel> GetByValue(string valor)
        {
            var matLista = new List<MatModel>();

            int matCodigo = int.TryParse(valor, out _) ? Convert.ToInt32(valor) : 0;
            string matNome = valor;
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT 
                                        *
                                        FROM materia_prima
                                        WHERE mp_codigo=@codigo OR mp_nome LIKE @nome";
                command.Parameters.AddWithValue("@codigo", matCodigo);
                command.Parameters.AddWithValue("@nome", "%" + matNome + "%");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var materia = new MatModel();
                        materia.Codigo = reader[0].ToString();
                        materia.Nome = reader[1].ToString();
                        materia.Estoque = reader[2].ToString();
                        matLista.Add(materia);
                    }
                }
            }

            return matLista;
        }

    }
}
