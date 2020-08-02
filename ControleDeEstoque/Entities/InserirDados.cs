using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControleDeEstoque
{
    class InserirDados
    {
        ConexaoBD conexao = new ConexaoBD();
        public int retornarId(string consulta, string nome)
        {
            int num = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexao.sqlConnection);
                comando.Parameters.AddWithValue("@produto", nome);
                conexao.sqlConnection.Open();
                MySqlDataReader retornoId = comando.ExecuteReader();
                if (retornoId.Read())
                    num = retornoId.GetInt32(0);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " Erro no metodo idProduto() das classe InserirDados()");
            }
            finally
            {
                conexao.sqlConnection.Close();
            }
            return num;
        }

        public double RetornarCusto(string consulta)
        {
            double num = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexao.sqlConnection);
                conexao.sqlConnection.Open();
                MySqlDataReader retornoValor = comando.ExecuteReader();
                if (retornoValor.Read())
                {
                    num = retornoValor.GetDouble(0);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(" Erro no metodo RetornarCusto() das classe InserirDados(): " + erro.Message);
            }
            finally
            {
                conexao.sqlConnection.Close();
            }
            return num;
        }
        public void Inserir(MySqlCommand c, string msg)
        {
            c.Connection = conexao.sqlConnection;
            try
            {
                conexao.sqlConnection.Open();
                c.ExecuteNonQuery();
                MessageBox.Show(msg);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro! Metodo de inserir da classe InserirDados\n" + erro.Message);
            }
            finally
            {
                conexao.sqlConnection.Close();
            }
        }
    }
}
