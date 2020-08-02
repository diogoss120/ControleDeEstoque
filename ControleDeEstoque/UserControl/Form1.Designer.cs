namespace ControleDeEstoque
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.telaInicial1 = new ControleDeEstoque.TelaInicial();
            this.estoque1 = new ControleDeEstoque.Estoque();
            this.relatorios1 = new ControleDeEstoque.Relatorios();
            this.vendas1 = new ControleDeEstoque.Vendas();
            this.compras1 = new ControleDeEstoque.Compras();
            this.cadastroProdutos1 = new ControleDeEstoque.CadastroProdutos();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 827);
            this.panel1.TabIndex = 26;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ControleDeEstoque.Properties.Resources.lealAcessorios;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(-3, 412);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 57);
            this.button2.TabIndex = 6;
            this.button2.Text = "Estoque";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(-3, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Compras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(-3, 177);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(203, 50);
            this.button7.TabIndex = 4;
            this.button7.Text = "Produtos";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(-3, 354);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(203, 53);
            this.button6.TabIndex = 2;
            this.button6.Text = "Relatórios";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(-3, 292);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(203, 58);
            this.button5.TabIndex = 1;
            this.button5.Text = "Vendas";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // telaInicial1
            // 
            this.telaInicial1.Location = new System.Drawing.Point(205, 14);
            this.telaInicial1.Margin = new System.Windows.Forms.Padding(5);
            this.telaInicial1.Name = "telaInicial1";
            this.telaInicial1.Size = new System.Drawing.Size(1635, 612);
            this.telaInicial1.TabIndex = 33;
            // 
            // estoque1
            // 
            this.estoque1.Location = new System.Drawing.Point(205, 11);
            this.estoque1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.estoque1.Name = "estoque1";
            this.estoque1.Size = new System.Drawing.Size(1637, 645);
            this.estoque1.TabIndex = 31;
            // 
            // relatorios1
            // 
            this.relatorios1.Location = new System.Drawing.Point(205, 11);
            this.relatorios1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.relatorios1.Name = "relatorios1";
            this.relatorios1.Size = new System.Drawing.Size(1637, 648);
            this.relatorios1.TabIndex = 30;
            this.relatorios1.Load += new System.EventHandler(this.relatorios1_Load);
            // 
            // vendas1
            // 
            this.vendas1.Location = new System.Drawing.Point(205, 1);
            this.vendas1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vendas1.Name = "vendas1";
            this.vendas1.Size = new System.Drawing.Size(1524, 688);
            this.vendas1.TabIndex = 29;
            // 
            // compras1
            // 
            this.compras1.Location = new System.Drawing.Point(205, 11);
            this.compras1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.compras1.Name = "compras1";
            this.compras1.Size = new System.Drawing.Size(1637, 678);
            this.compras1.TabIndex = 28;
            // 
            // cadastroProdutos1
            // 
            this.cadastroProdutos1.Location = new System.Drawing.Point(205, 14);
            this.cadastroProdutos1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cadastroProdutos1.Name = "cadastroProdutos1";
            this.cadastroProdutos1.Size = new System.Drawing.Size(1619, 739);
            this.cadastroProdutos1.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1854, 827);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.telaInicial1);
            this.Controls.Add(this.estoque1);
            this.Controls.Add(this.relatorios1);
            this.Controls.Add(this.vendas1);
            this.Controls.Add(this.compras1);
            this.Controls.Add(this.cadastroProdutos1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Leal Acessórios";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private CadastroProdutos cadastroProdutos1;
        private Compras compras1;
        private Vendas vendas1;
        private Relatorios relatorios1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Estoque estoque1;
        private TelaInicial telaInicial1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

