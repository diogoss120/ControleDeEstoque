using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    class DataGrid
    {
        ConexaoBD conexao = new ConexaoBD();
        public DataTable preecherDataGrid(in string consulta)
        {
            MySqlCommand comando = new MySqlCommand(consulta, conexao.sqlConnection);
            DataTable tabela = new DataTable();
            try
            {
                conexao.sqlConnection.Open();
                MySqlDataAdapter adapador = new MySqlDataAdapter(comando);
                adapador.Fill(tabela);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no método da classe DataGrid " + erro.Message);
            }
            finally
            {
                conexao.sqlConnection.Close();
            }
            return tabela;
        }
    }
}
