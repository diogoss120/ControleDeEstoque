using System;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Relatorios : UserControl
    {
        public Relatorios()
        {
            InitializeComponent();
        }
        void dataGridDaClasse()
        {
            DateTime data1 = DateTime.Parse(dateTimePicker1.Value.ToString());
            DateTime data2 = DateTime.Parse(dateTimePicker2.Value.ToString());
            string consulta = "";
            if (data1 > data2)
            {
                MessageBox.Show("A data inicial está maior que a data final", "Atenção");
            }
            else
            {
                if (radioButton3.Checked)
                {
                    consulta = "select	v.dataVenda, sum(v.TotalVenda) as 'Total de Vendas', sum(v.Custo) as 'Custo total', sum(v.TotalVenda - v.Custo) as 'Lucro total' from produto p join ( select v.codProduto , v.dataVenda, coalesce(sum(v.custo), 0) as Custo, coalesce(sum(v.quantidade), 0) as Quantidade , coalesce(sum(v.valorVenda), 0) as TotalVenda from vendas v group by v.codProduto,v.dataVenda having v.dataVenda between '" + data1.ToString("yyyy/MM/dd") + "' and '" + data2.ToString("yyyy/MM/dd") + "' ) v on v.codProduto = p.idProduto group by v.dataVenda";
                }
                else if (radioButton2.Checked)
                {
                    consulta = "select sum(v.TotalVenda) as 'Total de Vendas', sum(v.Custo) as 'Custo total', sum(v.TotalVenda - v.Custo) as 'Lucro total' from produto p join ( select v.codProduto , v.dataVenda, coalesce(sum(v.custo), 0) as Custo, coalesce(sum(v.quantidade), 0) as Quantidade , coalesce(sum(v.valorVenda), 0) as TotalVenda from vendas v group by v.codProduto,v.dataVenda having v.dataVenda between '" + data1.ToString("yyyy/MM/dd") + "' and '" + data2.ToString("yyyy/MM/dd") + "' ) v on v.codProduto = p.idProduto";
                }
                else if (radioButton1.Checked)
                {
                    consulta = "select 	v.codProduto as 'Código', p.nome as 'Nome', coalesce(sum(v.quantidade),0) as 'Quantidade' from vendas v join produto p on v.codProduto = p.idProduto where v.dataVenda between '" + data1.ToString("yyyy/MM/dd") + "' and '" + data2.ToString("yyyy/MM/dd") + "' group by v.codProduto order by Quantidade desc; ";
                }
                DataGrid grid = new DataGrid();
                dataGridView1.DataSource = grid.preecherDataGrid(consulta);
            }
        }
        private void Relatorios_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridDaClasse();
        }
    }
}
