using ControleDeEstoque;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class CadastroProdutos : UserControl
    {
        ConexaoBD conexao = new ConexaoBD();
        int controleId = 0;
        InserirDados dados = new InserirDados();
        bool verificaCampos()
        {
            string msg = "";

            if (nomeProduto.Text == "")
                msg += " Nome ";

            if (richTextBox1.Text == "")
                msg += " Descrição ";

            if (comboBox1.Text == "")
                msg += " Tipo ";

            try
            {
                double.Parse(precoProduto.Text);
            }
            catch
            {
                msg += " Preço ";
            }

            if (msg != "")
            {
                MessageBox.Show(msg + "Vazio ou Inválido");
                return false;
            }
            return true;
        }

        public void ConsultarDados()
        {
            comboBox2.Items.Clear();
            string consultaId = "select coalesce(MAX(idProduto), 0) from produto";
            int controle = (int)dados.retornarId(consultaId, "");
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
                        string nome = lista.GetString(0);
                        produtos.Add(nome);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Erro no metodo ConsultarDados()");
                    break;
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
        void traserProduto()
        {
            try
            {
                string consulta = "select nome, descricao, tipo, preco_venda, idProduto from produto where nome = '" + comboBox2.Text + "'";
                MySqlCommand comando = new MySqlCommand(consulta, conexao.sqlConnection);
                conexao.sqlConnection.Open();
                MySqlDataReader lista = comando.ExecuteReader();
                if (lista.Read())
                {
                    controleId = lista.GetInt32(4);
                    nomeProduto.Text = lista.GetString(0);
                    richTextBox1.Text = lista.GetString(1);
                    comboBox1.Text = lista.GetString(2);
                    precoProduto.Text = lista.GetDouble(3).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Erro no metodo EditarProdutos()");
            }
            finally
            {
                conexao.sqlConnection.Close();
            }
        }
        void LimparOpcoes()
        {
            comboBox2.Text = "";
            nomeProduto.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
            precoProduto.Text = "";
            controleId = 0;
        }

        bool VerificarSeJaExiste()
        {
            string buscarNome = "select count(*) from produto where nome = @produto";
            string produto = nomeProduto.Text.ToString();
            if (dados.retornarId(buscarNome, produto) > 0)
            {
                MessageBox.Show($"Já existe um cadastro para: {produto}!\nNão é permitido cadastro duplicado! ", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        void cadastrarProduto()
        {
            string inserir = "insert into produto (nome, descricao, tipo , preco_venda) values(@nome, @descricao, @tipo, @preco)";
            string msg = "Produto Cadastrado";
            MySqlCommand comando = new MySqlCommand(inserir);
            double precoProdu = double.Parse(precoProduto.Text);
            comando.Parameters.AddWithValue("@nome", nomeProduto.Text);
            comando.Parameters.AddWithValue("@descricao", richTextBox1.Text);
            comando.Parameters.AddWithValue("@tipo", comboBox1.Text);
            comando.Parameters.AddWithValue("@preco", precoProdu);
            comando.Parameters.AddWithValue("@idProduto", controleId);
            dados.Inserir(comando, msg);
        }
        void alterarProduto()
        {
            string update = "update produto set nome = @nome, descricao = @descricao, tipo = @tipo , preco_venda = @preco where idProduto = @idProduto";
            string msg = "Produto Alterado";

            MySqlCommand comando = new MySqlCommand(update);
            double precoProdu = double.Parse(precoProduto.Text);
            comando.Parameters.AddWithValue("@nome", nomeProduto.Text);
            comando.Parameters.AddWithValue("@descricao", richTextBox1.Text);
            comando.Parameters.AddWithValue("@tipo", comboBox1.Text);
            comando.Parameters.AddWithValue("@preco", precoProdu);
            comando.Parameters.AddWithValue("@idProduto", controleId);
            dados.Inserir(comando, msg);
        }
        void apagarProduto()
        {
            if (MessageBox.Show("Deseja Relmente Apagar o Produto?", "Atenção", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string delete = "delete from produto where idProduto = @idProduto";
                string msg = "Produto Apagado";
                MySqlCommand comando = new MySqlCommand(delete);
                comando.Parameters.AddWithValue("@idProduto", controleId);
                dados.Inserir(comando, msg);
            }
            else
                MessageBox.Show("Exclusão Cancelada");
        }

        public CadastroProdutos()
        {
            InitializeComponent();
        }

        private void CadastroProdutos_Load(object sender, EventArgs e)
        {
            ConsultarDados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarSeJaExiste())
            {
                if (verificaCampos())
                {
                    cadastrarProduto();
                    LimparOpcoes();
                    ConsultarDados();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            traserProduto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (controleId == 0)
            {
                MessageBox.Show("Selecione um produto!");
            }
            else
            {
                if (verificaCampos())
                {
                    alterarProduto();
                    LimparOpcoes();
                    ConsultarDados();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LimparOpcoes();
            ConsultarDados();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (controleId == 0)
            {
                MessageBox.Show("Selecione um produto!");
            }
            else
            {
                apagarProduto();
                LimparOpcoes();
                ConsultarDados();
            }
        }
    }
}
