using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Vendas : UserControl
    {
        int IdVenda = 0;
        InserirDados dados = new InserirDados();
        ConexaoBD conexao = new ConexaoBD();
        public Vendas()
        {
            InitializeComponent();
        }
        public void ConsultarDados()
        {
            comboBox1.Items.Clear();
            string consultarMax = "select coalesce(MAX(idProduto), 0) from produto";
            int controle = dados.retornarId(consultarMax, "");
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
                comboBox1.Items.Add(p);
            }
        }
        bool verificarOpcoes()
        {
            string msg = "";
            if (comboBox1.Text == "")
                msg += "Produto ";
            if (comboBox2.Text == "")
                msg += "Forma de Pagamento ";

            try
            {
                int.Parse(textBox1.Text);
            }
            catch
            {
                msg += "Quantidade ";
            }

            try
            {
                double.Parse(textBox2.Text);
            }
            catch
            {
                msg += "Venda Total ";
            }

            if (msg != "")
            {
                MessageBox.Show(msg + "Vazio ou Inválido");
                return false;
            }
            return true;
        }
        void traserVendas()
        {
            string consulta = "select	p.nome, v.pagamento, v.quantidade, v.valorVenda, v.dataVenda from produto p join vendas v on v.codProduto = p.idProduto where v.idVenda = @idVenda";
            MySqlCommand comando = new MySqlCommand(consulta, conexao.sqlConnection);
            comando.Parameters.AddWithValue("@idVenda", IdVenda);
            try
            {
                conexao.sqlConnection.Open();
                MySqlDataReader lista = comando.ExecuteReader();
                if (lista.Read())
                {
                    comboBox1.Text = lista.GetString(0);
                    comboBox2.Text = lista.GetString(1);
                    textBox1.Text = lista.GetInt32(2).ToString();
                    textBox2.Text = lista.GetDouble(3).ToString();
                    dateTimePicker1.Value = lista.GetDateTime(4);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro metodo TraserVendas()" + erro.Message);
            }
            finally
            {
                conexao.sqlConnection.Close();
            }
        }
        void limparOpcoes()
        {
            comboBox1.Text = "";
            comboBox2.Text = "Dinheiro";
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            IdVenda = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        public void dataGridDaClasse()
        {
            DataGrid grid = new DataGrid();
            string consulta = "select v.idVenda as 'Cod', p.nome as 'Produto',v.quantidade as 'Qtd' ,v.valorVenda as 'Total' ,v.custo as 'Custo' ,v.valorVenda - v.custo as 'Lucro',v.dataVenda as 'Data' ,v.pagamento as 'Pagamento' from produto p join vendas v on v.codProduto = p.idProduto order by v.dataVenda desc";
            dataGridView1.DataSource = grid.preecherDataGrid(consulta);
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 70;
        }
        void inserirVenda()
        {
            string insert = "insert into vendas (codProduto, quantidade, pagamento, valorVenda, dataVenda, custo) values (@produto, @quantidade, @formaPagamento, @vendaTotal, @dataVenda, @custo)";
            string msg = "Venda Cadastrada";
            MySqlCommand comando = new MySqlCommand(insert);
            string consulta = "select idProduto from produto where nome = @produto";
            int codProduto = dados.retornarId(consulta, comboBox1.Text);
            DateTime dataVenda = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            string precoProduto = "select precoUnitario from compra where codProduto = " + codProduto + " order by data_compra desc limit 1";
            double custo = dados.RetornarCusto(precoProduto) * int.Parse(textBox1.Text);
            comando.Parameters.AddWithValue("@produto", codProduto);
            comando.Parameters.AddWithValue("@quantidade", int.Parse(textBox1.Text));
            comando.Parameters.AddWithValue("@formaPagamento", comboBox2.Text);
            comando.Parameters.AddWithValue("@vendaTotal", double.Parse(textBox2.Text));
            comando.Parameters.AddWithValue("@dataVenda", dataVenda);
            comando.Parameters.AddWithValue("@custo", custo);
            dados.Inserir(comando, msg);
        }
        void alterarVendas()
        {
            string update = "update vendas set codProduto = @produto, quantidade = @quantidade, pagamento = @formaPagamento, valorVenda = @vendaTotal, dataVenda = @dataVenda, custo = @custo where idVenda = '" + IdVenda + "'";
            string msg = "Alteração Realizada";
            MySqlCommand comando = new MySqlCommand(update);
            string consulta = "select idProduto from produto where nome = @produto";
            int codProduto = dados.retornarId(consulta, comboBox1.Text);
            DateTime dataVenda = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            string precoProduto = "select precoUnitario from compra where codProduto = " + codProduto + " order by data_compra desc limit 1";
            double custo = dados.RetornarCusto(precoProduto) * int.Parse(textBox1.Text);
            comando.Parameters.AddWithValue("@produto", codProduto);
            comando.Parameters.AddWithValue("@quantidade", int.Parse(textBox1.Text));
            comando.Parameters.AddWithValue("@formaPagamento", comboBox2.Text);
            comando.Parameters.AddWithValue("@vendaTotal", double.Parse(textBox2.Text));
            comando.Parameters.AddWithValue("@dataVenda", dataVenda);
            comando.Parameters.AddWithValue("@custo", custo);
            dados.Inserir(comando, msg);
        }
        void apagarVenda()
        {
            if (MessageBox.Show("Deseja Relmente apagar a Venda?", "Atenção", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string delete = "delete from vendas where idVenda = '" + IdVenda + "'";
                string msg = "Venda Apagada";
                MySqlCommand comando = new MySqlCommand(delete);
                dados.Inserir(comando, msg);
            }
            else
                MessageBox.Show("Exclusão Cancelada");
        }
        void CarregarQtd()
        {
            for (int i = 1; i <= 15; i++)
                textBox1.Items.Add(i);
        }
        void TraserPreco()
        {
            string produto = comboBox1.Text;
            int quantidade;
            try
            {
                quantidade = int.Parse(textBox1.Text);
            }
            catch
            {
                quantidade = 0;
            }

            if (produto != "" && quantidade >= 1)
            {
                string nome = comboBox1.Text;
                string consulta = "select preco_venda from produto where nome = '" + nome + "'";
                double precoProduto = dados.RetornarCusto(consulta);
                textBox2.Text = (precoProduto * quantidade).ToString("F2"); ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarDados();
            dataGridDaClasse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verificarOpcoes())
            {
                inserirVenda();
                limparOpcoes();
                ConsultarDados();
                dataGridDaClasse();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (IdVenda == 0)
            {
                MessageBox.Show("Selecione uma Venda!");
            }
            else
            {
                if (verificarOpcoes())
                {
                    alterarVendas();
                    limparOpcoes();
                    ConsultarDados();
                    dataGridDaClasse();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IdVenda == 0)
            {
                MessageBox.Show("Selecione uma Venda!");
            }
            else
            {
                apagarVenda();
                limparOpcoes();
                ConsultarDados();
                dataGridDaClasse();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                IdVenda = int.Parse(textBox3.Text);
                if (textBox3.Text == string.Empty)
                    MessageBox.Show("Digite o Código de uma Venda");
                else
                    traserVendas();
            }
            catch
            {
                MessageBox.Show("Código Invalido!");
            }
        }
        private void Vendas_Load_1(object sender, EventArgs e)
        {
            CarregarQtd();
        }
        private void textBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TraserPreco();
        }

        private void textBox1_TextUpdate_1(object sender, EventArgs e)
        {
            TraserPreco();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                IdVenda = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch
            {

            }
            textBox3.Text = IdVenda.ToString();
            traserVendas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limparOpcoes();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consultarSeExisteCompra = "select  count(c.quantidade) from compra c join produto p on p.idProduto = c.codProduto where p.nome = @produto; ";
            string consultarSePossuiEstoque = "select  (coalesce(c.QuantidadeComprada, 0) - coalesce(v.QuantidadeVendida, 0)) as Estoque from produto p left join (select codProduto, coalesce(sum(quantidade), 0) as QuantidadeComprada  from compra group by codProduto ) c on  p.idProduto = c.codProduto left join( select  codProduto,  if(count(*) = 0, 0 , coalesce(sum(quantidade), 0))  as QuantidadeVendida  from vendas  group by codProduto ) v on  p.idProduto = v.codProduto where p.nome = @produto; ";
            string produto = comboBox1.Text;

            if (dados.retornarId(consultarSeExisteCompra, produto) == 0)
                MessageBox.Show("Não Existe Compra Referente a Esse Produto\nO Custo Unitário Não Poderá Ser Calculado e\nConsequentemente Deixará os Relatórios Inconsistentes!");
            else if (dados.retornarId(consultarSePossuiEstoque, produto) <= 0)
                MessageBox.Show("Produto Com Estoque Zerado!\nFaça Novas Compras Para Este Item");
        }
    }
}
