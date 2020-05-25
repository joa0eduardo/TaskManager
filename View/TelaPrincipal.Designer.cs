namespace View
{
    partial class FrmTelaPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTelaPrincipal));
            this.taskManagerDataSet = new View.TaskManagerDataSet();
            this.taskManagerDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barraStatusPrincipal = new System.Windows.Forms.StatusStrip();
            this.lbVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbUsuarioConectado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadGrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadTipoAtividade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.gRUPOATIVIDADEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gRUPO_ATIVIDADETableAdapter = new View.TaskManagerDataSetTableAdapters.GRUPO_ATIVIDADETableAdapter();
            this.opcaoUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.opcaoPerfil = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.taskManagerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskManagerDataSetBindingSource)).BeginInit();
            this.barraStatusPrincipal.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRUPOATIVIDADEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // taskManagerDataSet
            // 
            this.taskManagerDataSet.DataSetName = "TaskManagerDataSet";
            this.taskManagerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taskManagerDataSetBindingSource
            // 
            this.taskManagerDataSetBindingSource.DataSource = this.taskManagerDataSet;
            this.taskManagerDataSetBindingSource.Position = 0;
            // 
            // barraStatusPrincipal
            // 
            this.barraStatusPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbVersao,
            this.lbUsuario,
            this.lbUsuarioConectado});
            this.barraStatusPrincipal.Location = new System.Drawing.Point(0, 494);
            this.barraStatusPrincipal.Name = "barraStatusPrincipal";
            this.barraStatusPrincipal.Size = new System.Drawing.Size(1005, 22);
            this.barraStatusPrincipal.TabIndex = 0;
            this.barraStatusPrincipal.Text = "statusStrip1";
            // 
            // lbVersao
            // 
            this.lbVersao.Name = "lbVersao";
            this.lbVersao.Size = new System.Drawing.Size(68, 17);
            this.lbVersao.Text = "Versão 1.0.0";
            // 
            // lbUsuario
            // 
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(64, 17);
            this.lbUsuario.Text = "Bem vindo";
            // 
            // lbUsuarioConectado
            // 
            this.lbUsuarioConectado.Name = "lbUsuarioConectado";
            this.lbUsuarioConectado.Size = new System.Drawing.Size(47, 17);
            this.lbUsuarioConectado.Text = "Usuário";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastro,
            this.relatórioToolStripMenuItem,
            this.menuSair});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1005, 24);
            this.menuPrincipal.TabIndex = 1;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuCadastro
            // 
            this.menuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadGrupo,
            this.menuCadTipoAtividade,
            this.menuCadUsuario});
            this.menuCadastro.Name = "menuCadastro";
            this.menuCadastro.Size = new System.Drawing.Size(66, 20);
            this.menuCadastro.Text = "Cadastro";
            // 
            // menuCadGrupo
            // 
            this.menuCadGrupo.Name = "menuCadGrupo";
            this.menuCadGrupo.Size = new System.Drawing.Size(180, 22);
            this.menuCadGrupo.Text = "Grupo";
            // 
            // menuCadTipoAtividade
            // 
            this.menuCadTipoAtividade.Name = "menuCadTipoAtividade";
            this.menuCadTipoAtividade.Size = new System.Drawing.Size(180, 22);
            this.menuCadTipoAtividade.Text = "Tipo Atividade";
            // 
            // menuCadUsuario
            // 
            this.menuCadUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcaoUsuario,
            this.opcaoPerfil});
            this.menuCadUsuario.Name = "menuCadUsuario";
            this.menuCadUsuario.Size = new System.Drawing.Size(180, 22);
            this.menuCadUsuario.Text = "Usuário";
            // 
            // relatórioToolStripMenuItem
            // 
            this.relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
            this.relatórioToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatórioToolStripMenuItem.Text = "Relatórios";
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(38, 20);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // gRUPOATIVIDADEBindingSource
            // 
            this.gRUPOATIVIDADEBindingSource.DataMember = "GRUPO_ATIVIDADE";
            this.gRUPOATIVIDADEBindingSource.DataSource = this.taskManagerDataSetBindingSource;
            // 
            // gRUPO_ATIVIDADETableAdapter
            // 
            this.gRUPO_ATIVIDADETableAdapter.ClearBeforeFill = true;
            // 
            // opcaoUsuario
            // 
            this.opcaoUsuario.Name = "opcaoUsuario";
            this.opcaoUsuario.Size = new System.Drawing.Size(180, 22);
            this.opcaoUsuario.Text = "Usuário";
            this.opcaoUsuario.Click += new System.EventHandler(this.opcaoUsuario_Click);
            // 
            // opcaoPerfil
            // 
            this.opcaoPerfil.Name = "opcaoPerfil";
            this.opcaoPerfil.Size = new System.Drawing.Size(180, 22);
            this.opcaoPerfil.Text = "Perfil";
            // 
            // FrmTelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 516);
            this.Controls.Add(this.barraStatusPrincipal);
            this.Controls.Add(this.menuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuPrincipal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atividades";
            this.Load += new System.EventHandler(this.FrmTelaPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskManagerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskManagerDataSetBindingSource)).EndInit();
            this.barraStatusPrincipal.ResumeLayout(false);
            this.barraStatusPrincipal.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRUPOATIVIDADEBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource taskManagerDataSetBindingSource;
        private TaskManagerDataSet taskManagerDataSet;
        private System.Windows.Forms.StatusStrip barraStatusPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel lbVersao;
        private System.Windows.Forms.ToolStripStatusLabel lbUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lbUsuarioConectado;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuCadastro;
        private System.Windows.Forms.ToolStripMenuItem relatórioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.ToolStripMenuItem menuCadGrupo;
        private System.Windows.Forms.ToolStripMenuItem menuCadTipoAtividade;
        private System.Windows.Forms.ToolStripMenuItem menuCadUsuario;
        private System.Windows.Forms.BindingSource gRUPOATIVIDADEBindingSource;
        private TaskManagerDataSetTableAdapters.GRUPO_ATIVIDADETableAdapter gRUPO_ATIVIDADETableAdapter;
        private System.Windows.Forms.ToolStripMenuItem opcaoUsuario;
        private System.Windows.Forms.ToolStripMenuItem opcaoPerfil;
    }
}