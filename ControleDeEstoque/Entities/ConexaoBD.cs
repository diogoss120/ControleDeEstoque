using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    class ConexaoBD
    {
        static public string conection { get; private set; } = "server=localhost;user id=root;password=4052;database=controleDeEstoque;port=3306";
        public MySqlConnection sqlConnection { get; private set; } = new MySqlConnection();

        /*static void Ler()
        {
            try
            {
                using (StreamReader reader = File.OpenText("conection.txt"))
                {
                    conection = reader.ReadLine();
                    reader.Close();
                }
            }catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }*/
        public ConexaoBD()
        {
            //Ler();
            sqlConnection.ConnectionString = conection;
        }
    }
}
