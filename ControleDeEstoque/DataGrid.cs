using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    class DataGrid
    {
        string Conexao()
        {
            return "Data Source=COROLA;Initial Catalog=controleDeEstoque;Integrated Security=True";
        }
       public DataTable preecherDataGrid(in string consulta)
        {
            string conexaoBD = Conexao();
            SqlConnection conexao = new SqlConnection(conexaoBD);
            SqlCommand comando = new SqlCommand(consulta, conexao);
            DataTable tabela = new DataTable();
            try
            {
                conexao.Open();
                SqlDataAdapter adapador = new SqlDataAdapter(comando);
                adapador.Fill(tabela);
                conexao.Close();
            }
            catch (Exception erro)
            {
                conexao.Close();
                MessageBox.Show("Erro no método da classe DataGrid"+erro.Message);
            }
            return tabela;
        }
    }
}
