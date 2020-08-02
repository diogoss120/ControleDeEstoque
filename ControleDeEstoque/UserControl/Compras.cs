using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Compras : UserControl
    {
        int controleIdCompra = 0;
        ConexaoBD conexao = new ConexaoBD();
        InserirDados dados = new InserirDados();
        public void ConsultarDados()
        {
            comboBox2.Items.Clear();
            string comandoConsulta = "select coalesce(MAX(idProduto), 0) from produto";
            int controle = dados.retornarId(comandoConsulta, "");
            List<string> produtos = new List<string>();
            for (int i = 1; i <= controle; i++)
            {
                try
                {
                    string consulta = "select nome from produto where idProduto = @codigo";
                    MySqlCommand comando = new MySqlCommand(consulta, conexao.sqlConnection);
                    comando.Parameters.AddWithValue("@codigo", i);
                    conexao.sqlConnection.Open();
                    MySqlDataReader lista = comando.ExecuteReader();
                    if (lista.Read())
                    {
                        produtos.Add(lista.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Erro no metodo ConsultarDados()");
                }
                finally
                {

                    conexao.sqlConnection.Close();
                }
            }
            produtos.Sort();
            foreach (var p in produtos)
            {
                comboBox2.Items.Add(p);
            }
        }

        void LimparOpcoes()
        {
            textBox2.Text = "";
            textBox3.Clear();
            comboBox2.Text = "";
            textBox1.Clear();
            controleIdCompra = 0;
            dateTimePicker1.Value = DateTime.Now;
        }
        bool ValidarCampos()
        {
            string msg = "";
            if (comboBox2.Text == "")
                msg += "Produto ";
            if (textBox2.Text == "")
                msg += "Quantidade ";

            try
            {
                double.Parse(textBox3.Text);
            }
            catch (Exception)
            {
                msg += "Preço ";
            }

            if (msg != "")
            {
                MessageBox.Show(msg + "Vazio ou Inválido");
                return false;
            }

            return true;
        }
        void traserCompras()
        {
            try
            {
                string consulta = "select quantidade, preco_total, p.nome, c.data_compra from compra c join produto p on c.codProduto= p.idProduto where c.id = @idCompra";
                MySqlCommand comando = new MySqlCommand(consulta, conexao.sqlConnection);
                comando.Parameters.AddWithValue("@idCompra", controleIdCompra);
                conexao.sqlConnection.Open();
                MySqlDataReader lista = comando.ExecuteReader();
                if (lista.Read())
                {
                    textBox2.Text = lista.GetInt32(0).ToString();
                    textBox3.Text = lista.GetDouble(1).ToString();
                    comboBox2.Text = lista.GetString(2);
                    dateTimePicker1.Value = lista.GetDateTime(3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Erro no metodo traserVendas()");
            }
            finally
            {
                conexao.sqlConnection.Close();
            }
        }
        public void dataGridDaClasse()
        {
            DataGrid grid = new DataGrid();
            string consulta = "select	c.id as 'Cod', c.data_compra as Data,p.nome as Produto, c.quantidade as Qtd, c.preco_total as 'Total', c.precoUnitario as 'Custo Por Un' from compra c join produto p on c.codProduto=p.idProduto order by c.data_compra desc";
            dataGridView1.DataSource = grid.preecherDataGrid(consulta);
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 190;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 60;
        }

        void apagarCompra()
        {
            if (MessageBox.Show("Deseja Relmente Apagar a Compra?", "Atenção", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string delete = "delete from compra where id = @idCompra";
                string msg = "Compra Apagada";
                MySqlCommand comando = new MySqlCommand(delete);
                comando.Parameters.AddWithValue("@idCompra", controleIdCompra);
                dados.Inserir(comando, msg);
            }
            else
                MessageBox.Show("Exclusão Cancelada");
        }
        void alterarCompra()
        {
            string update = "update compra set quantidade = @quantidade, preco_total = @preco_total, data_compra = @data, codProduto = @codProduto, precoUnitario = @precoUnitario where id = @idCompra";
            string msg = "Alteração Realizada";

            double precoUnitario = double.Parse(textBox3.Text) / int.Parse(textBox2.Text);
            string consulta = "select coalesce(idProduto, 0) from produto where nome = @produto";
            int codProduto = dados.retornarId(consulta, comboBox2.Text);
            MySqlCommand comando = new MySqlCommand(update);
            DateTime dataCompra = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            comando.Parameters.AddWithValue("@data", dataCompra);
            comando.Parameters.AddWithValue("@quantidade", int.Parse(textBox2.Text));
            comando.Parameters.AddWithValue("@preco_total", double.Parse(textBox3.Text));
            comando.Parameters.AddWithValue("@idCompra", controleIdCompra);
            comando.Parameters.AddWithValue("@codProduto", codProduto);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            dados.Inserir(comando, msg);
        }
        void inserirCompra()
        {
            string insert = "insert into compra (data_compra, quantidade, preco_total, codProduto, precoUnitario) values(@data, @quantidade, @preco_total, @codProduto, @precoUnitario)";
            string msg = "Compra Registrada";

            double precoUnitario = Math.Round(double.Parse(textBox3.Text) / int.Parse(textBox2.Text), 2);
            string consulta = "select coalesce(idProduto, 0) from produto where nome = @produto";
            int codProduto = dados.retornarId(consulta, comboBox2.Text);
            MySqlCommand comando = new MySqlCommand(insert);
            DateTime dataCompra = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            comando.Parameters.AddWithValue("@data", dataCompra);
            comando.Parameters.AddWithValue("@quantidade", int.Parse(textBox2.Text));
            comando.Parameters.AddWithValue("@preco_total", double.Parse(textBox3.Text));
            comando.Parameters.AddWithValue("@idCompra", controleIdCompra);
            comando.Parameters.AddWithValue("@codProduto", codProduto);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            dados.Inserir(comando, msg);

        }
        void CarregarQtd()
        {
            for (int i = 1; i <= 20; i++)
                textBox2.Items.Add(i);
        }
        public Compras()
        {
            InitializeComponent();
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            CarregarQtd();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                inserirCompra();
                LimparOpcoes();
                ConsultarDados();
                dataGridDaClasse();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ConsultarDados();
            dataGridDaClasse();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (controleIdCompra == 0)
            {
                MessageBox.Show("Selecione uma compra");
            }
            else
            {
                apagarCompra();
                ConsultarDados();
                LimparOpcoes();
                dataGridDaClasse();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (controleIdCompra == 0)
            {
                MessageBox.Show("Selecione uma compra");
            }
            else
            {
                if (ValidarCampos())
                {
                    alterarCompra();
                    LimparOpcoes();
                    ConsultarDados();
                    dataGridDaClasse();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                controleIdCompra = int.Parse(textBox1.Text);
                if (textBox1.Text == string.Empty)
                    MessageBox.Show("Digite o Código de uma Venda");
                else
                    traserCompras();
            }
            catch
            {
                MessageBox.Show("Código Invalido!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimparOpcoes();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                controleIdCompra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch
            {

            }
            textBox1.Text = controleIdCompra.ToString();
            traserCompras();
        }
    }
}
