using System;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Estoque : UserControl
    {
        public Estoque()
        {
            InitializeComponent();
        }
       public void dataGridDaClasse()
        {
            DataGrid grid = new DataGrid();
            string consulta = "select p.idProduto, p.nome as Produto, coalesce(c.QuantidadeComprada, 0) as 'Qtd Comprada', coalesce(v.QuantidadeVendida, 0) as 'Qtd Vendida', (coalesce(c.QuantidadeComprada, 0) - coalesce(v.QuantidadeVendida, 0)) as 'Em Estoque' from produto p left join ( select codProduto, coalesce(sum(quantidade), 0) as QuantidadeComprada from compra group by codProduto ) c on  p.idProduto = c.codProduto left join( select  codProduto, coalesce(sum(quantidade), 0) as QuantidadeVendida  from vendas  group by codProduto ) v on  v.codProduto = p.idProduto group by p.nome, p.idProduto order by p.nome; ";
            dataGridView1.DataSource = grid.preecherDataGrid(consulta);
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
        }
    }
}
