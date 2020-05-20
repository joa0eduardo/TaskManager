namespace View
{
    partial class FrmUsuarioSelecao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarioSelecao));
            this.dataGridUsuario = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AcessoAdm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btInserir = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btConsultar = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridUsuario
            // 
            this.dataGridUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nome,
            this.Ativo,
            this.AcessoAdm});
            resources.ApplyResources(this.dataGridUsuario, "dataGridUsuario");
            this.dataGridUsuario.MultiSelect = false;
            this.dataGridUsuario.Name = "dataGridUsuario";
            this.dataGridUsuario.ReadOnly = true;
            this.dataGridUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnPesquisar
            // 
            resources.ApplyResources(this.btnPesquisar, "btnPesquisar");
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtCodigo
            // 
            resources.ApplyResources(this.txtCodigo, "txtCodigo");
            this.txtCodigo.Name = "txtCodigo";
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            // 
            // chkAtivo
            // 
            resources.ApplyResources(this.chkAtivo, "chkAtivo");
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.DataPropertyName = "IdUsuario";
            this.Codigo.Frozen = true;
            resources.ApplyResources(this.Codigo, "Codigo");
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.DataPropertyName = "NomeUsuario";
            resources.ApplyResources(this.Nome, "Nome");
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ativo.DataPropertyName = "AtivoUsuario";
            resources.ApplyResources(this.Ativo, "Ativo");
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ativo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AcessoAdm
            // 
            this.AcessoAdm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AcessoAdm.DataPropertyName = "AmbienteAdmUsuario";
            resources.ApplyResources(this.AcessoAdm, "AcessoAdm");
            this.AcessoAdm.Name = "AcessoAdm";
            this.AcessoAdm.ReadOnly = true;
            this.AcessoAdm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AcessoAdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btInserir
            // 
            resources.ApplyResources(this.btInserir, "btInserir");
            this.btInserir.Name = "btInserir";
            this.btInserir.UseVisualStyleBackColor = true;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // btFechar
            // 
            resources.ApplyResources(this.btFechar, "btFechar");
            this.btFechar.Name = "btFechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btConsultar
            // 
            resources.ApplyResources(this.btConsultar, "btConsultar");
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.UseVisualStyleBackColor = true;
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // btAlterar
            // 
            resources.ApplyResources(this.btAlterar, "btAlterar");
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // FrmUsuarioSelecao
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btAlterar);
            this.Controls.Add(this.btConsultar);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.btInserir);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dataGridUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsuarioSelecao";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsuario;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AcessoAdm;
        private System.Windows.Forms.Button btInserir;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btConsultar;
        private System.Windows.Forms.Button btAlterar;
    }
}