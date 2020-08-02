using System;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            telaInicial1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cadastroProdutos1.BringToFront();
        }

        private void relatorios1_Load(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            relatorios1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vendas1.BringToFront();
            vendas1.ConsultarDados();
            vendas1.dataGridDaClasse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            compras1.BringToFront();
            compras1.ConsultarDados();
            compras1.dataGridDaClasse();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            estoque1.BringToFront();
            estoque1.dataGridDaClasse();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
