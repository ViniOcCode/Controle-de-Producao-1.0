using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms
{
    class Database
    {
        private static string connectionString = @"DataSource=..\..\Bin\Files\database.db; Version=3;";
        public static void Iniciar(string SqlConnection)
        {
            if (!File.Exists(@"..\..\Bin\Files\database.db"))
            {
                SQLiteConnection.CreateFile(@"..\..\Bin\Files\database.db");

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string criaprodutos = @"
                        CREATE TABLE IF NOT EXISTS produtos (
                        pr_codigo INTEGER PRIMARY KEY,
                        pr_nome TEXT NOT NULL,
                        pr_un_palete INTEGER DEFAULT(0),
                        pr_estoque INTEGER DEFAULT(0),
                        ativo INTEGER DEFAULT(1)
                        );";

                    SQLiteCommand command = new SQLiteCommand(criaprodutos, connection);
                    command.ExecuteNonQuery();

                    string criamateriaprima = @"
                        CREATE TABLE IF NOT EXISTS materia_prima(
                        mp_codigo INTEGER PRIMARY KEY,
                        mp_nome TEXT NOT NULL,
                        mp_estoque INTEGER DEFAULT(0)
                        );";

                    command = new SQLiteCommand(criamateriaprima, connection);
                    command.ExecuteNonQuery();



                    string criaprodutomateriaprima = @"
                        CREATE TABLE IF NOT EXISTS producao_materiaprima (
                        pmp_pr_codigo INTEGER,
                        pmp_id INTEGER,
                        pmp_mp_codigo INTEGER,
                        pmp_qtd REAL,
                        pmp_data TEXT DEFAULT (datetime('now', 'localtime')),
                        FOREIGN KEY(pmp_pr_codigo) REFERENCES produtos(pr_codigo),
                        FOREIGN KEY(pmp_mp_codigo) REFERENCES materia_prima(mp_codigo)
                        );";

                    command = new SQLiteCommand(criaprodutomateriaprima, connection);
                    command.ExecuteNonQuery();

                    string criaproducao = @"CREATE TABLE IF NOT EXISTS producao (
                        pd_codigo INTEGER,
                        pd_pr_codigo INTEGER,
                        pd_data TEXT NOT NULL,
                        pd_qtd_produzida REAL,
                        PRIMARY KEY(pd_pr_codigo, pd_codigo, pd_data)
                        FOREIGN KEY(pd_pr_codigo) REFERENCES produtos(pr_codigo)
                        );";

                    command = new SQLiteCommand(criaproducao, connection);
                    command.ExecuteNonQuery();

                    string criaproducaolog = @"CREATE TABLE IF NOT EXISTS pproducao_log (
                        log_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    	log_pd_codigo INTEGER,
                        log_pd_data TEXT,
                        log_pd_qtd REAL,
                        data_atualizacao TEXT DEFAULT (datetime('now', 'localtime')),
                    	FOREIGN KEY(log_pd_codigo) REFERENCES produtos(pr_codigo)
                        );";

                    command = new SQLiteCommand(criaproducaolog, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
    class Funcoes
    {
        public static DataTable Cursor(string comandosql, SQLiteParameter[] parametros = null)
        {
            DataTable dataTable = new DataTable();

            string databasePath = @"DataSource=..\..\Files\database.db; Version=3;";

            if (!File.Exists(databasePath))
            {
                File.Create(databasePath).Close();
            }

            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(comandosql, connection))
                {
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros);
                    }

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }

                connection.Close();
            }

            return dataTable;
        }

    }

}