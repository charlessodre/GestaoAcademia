namespace Interface
{
    partial class frmPrincipal
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
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuControle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAluno = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContasAReceber = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProfissao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCidade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPais = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuconfiguracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnSair = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnTrocarUsuario = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnContasReceber = new System.Windows.Forms.ToolStripButton();
            this.stPrincipal = new System.Windows.Forms.StatusStrip();
            this.stlblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.stDataAtual = new System.Windows.Forms.ToolStripStatusLabel();
            this.stlblUsuarioLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.imgFundoPrincipal = new System.Windows.Forms.PictureBox();
            this.tsBotoesPrincipais = new System.Windows.Forms.ToolStrip();
            this.btnContasReceber = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTrocarUsuario = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundoPrincipal)).BeginInit();
            this.tsBotoesPrincipais.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuControle,
            this.mnuconfiguracoes,
            this.mnuSair,
            this.mnuAjuda});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1018, 24);
            this.mnuPrincipal.TabIndex = 0;
            this.mnuPrincipal.Text = "mnuPrincipal";
            // 
            // mnuControle
            // 
            this.mnuControle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAluno,
            this.mnuContasAReceber,
            this.mnuProfissao,
            this.mnuEmpresa,
            this.mnuCidade,
            this.mnuEstado,
            this.mnuPais});
            this.mnuControle.Name = "mnuControle";
            this.mnuControle.Size = new System.Drawing.Size(65, 20);
            this.mnuControle.Text = "&Controle";
            // 
            // mnuAluno
            // 
            this.mnuAluno.Name = "mnuAluno";
            this.mnuAluno.Size = new System.Drawing.Size(165, 22);
            this.mnuAluno.Text = "&Aluno";
            this.mnuAluno.Click += new System.EventHandler(this.mnuAluno_Click);
            // 
            // mnuContasAReceber
            // 
            this.mnuContasAReceber.Name = "mnuContasAReceber";
            this.mnuContasAReceber.Size = new System.Drawing.Size(165, 22);
            this.mnuContasAReceber.Text = "Contas a &Receber";
            this.mnuContasAReceber.Click += new System.EventHandler(this.mnuContasAReceber_Click);
            // 
            // mnuProfissao
            // 
            this.mnuProfissao.Name = "mnuProfissao";
            this.mnuProfissao.Size = new System.Drawing.Size(165, 22);
            this.mnuProfissao.Text = "P&rofissão";
            this.mnuProfissao.Click += new System.EventHandler(this.mnuProfissao_Click);
            // 
            // mnuEmpresa
            // 
            this.mnuEmpresa.Name = "mnuEmpresa";
            this.mnuEmpresa.Size = new System.Drawing.Size(165, 22);
            this.mnuEmpresa.Text = "E&mpresa";
            this.mnuEmpresa.Click += new System.EventHandler(this.mnuEmpresa_Click);
            // 
            // mnuCidade
            // 
            this.mnuCidade.Name = "mnuCidade";
            this.mnuCidade.Size = new System.Drawing.Size(165, 22);
            this.mnuCidade.Text = "Ci&dade";
            this.mnuCidade.Click += new System.EventHandler(this.mnuCidade_Click);
            // 
            // mnuEstado
            // 
            this.mnuEstado.Name = "mnuEstado";
            this.mnuEstado.Size = new System.Drawing.Size(165, 22);
            this.mnuEstado.Text = "Estad&o";
            this.mnuEstado.Click += new System.EventHandler(this.mnuEstado_Click);
            // 
            // mnuPais
            // 
            this.mnuPais.Name = "mnuPais";
            this.mnuPais.Size = new System.Drawing.Size(165, 22);
            this.mnuPais.Text = "&País";
            this.mnuPais.Click += new System.EventHandler(this.mnuPais_Click);
            // 
            // mnuconfiguracoes
            // 
            this.mnuconfiguracoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSistema});
            this.mnuconfiguracoes.Name = "mnuconfiguracoes";
            this.mnuconfiguracoes.Size = new System.Drawing.Size(96, 20);
            this.mnuconfiguracoes.Text = "Con&figurações";
            // 
            // mnuSistema
            // 
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(115, 22);
            this.mnuSistema.Text = "Sis&tema";
            this.mnuSistema.Click += new System.EventHandler(this.mnuSistema_Click);
            // 
            // mnuSair
            // 
            this.mnuSair.Name = "mnuSair";
            this.mnuSair.Size = new System.Drawing.Size(38, 20);
            this.mnuSair.Text = "&Sair";
            this.mnuSair.Click += new System.EventHandler(this.mnuSair_Click);
            // 
            // mnuAjuda
            // 
            this.mnuAjuda.Name = "mnuAjuda";
            this.mnuAjuda.Size = new System.Drawing.Size(50, 20);
            this.mnuAjuda.Text = "A&juda";
            this.mnuAjuda.Click += new System.EventHandler(this.mnuAjuda_Click);
            // 
            // tsBtnSair
            // 
            this.tsBtnSair.Name = "tsBtnSair";
            this.tsBtnSair.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // tsBtnTrocarUsuario
            // 
            this.tsBtnTrocarUsuario.Name = "tsBtnTrocarUsuario";
            this.tsBtnTrocarUsuario.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // tsBtnContasReceber
            // 
            this.tsBtnContasReceber.Name = "tsBtnContasReceber";
            this.tsBtnContasReceber.Size = new System.Drawing.Size(23, 23);
            // 
            // stPrincipal
            // 
            this.stPrincipal.Location = new System.Drawing.Point(0, 714);
            this.stPrincipal.Name = "stPrincipal";
            this.stPrincipal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stPrincipal.Size = new System.Drawing.Size(1018, 22);
            this.stPrincipal.TabIndex = 2;
            // 
            // stlblHora
            // 
            this.stlblHora.Name = "stlblHora";
            this.stlblHora.Size = new System.Drawing.Size(0, 0);
            // 
            // stDataAtual
            // 
            this.stDataAtual.Name = "stDataAtual";
            this.stDataAtual.Size = new System.Drawing.Size(0, 0);
            // 
            // stlblUsuarioLogado
            // 
            this.stlblUsuarioLogado.Name = "stlblUsuarioLogado";
            this.stlblUsuarioLogado.Size = new System.Drawing.Size(0, 17);
            // 
            // imgFundoPrincipal
            // 
            this.imgFundoPrincipal.Location = new System.Drawing.Point(0, 61);
            this.imgFundoPrincipal.Name = "imgFundoPrincipal";
            this.imgFundoPrincipal.Size = new System.Drawing.Size(1018, 653);
            this.imgFundoPrincipal.TabIndex = 3;
            this.imgFundoPrincipal.TabStop = false;
            // 
            // tsBotoesPrincipais
            // 
            this.tsBotoesPrincipais.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContasReceber,
            this.toolStripSeparator3,
            this.btnTrocarUsuario,
            this.toolStripSeparator4,
            this.btnSair,
            this.toolStripSeparator5});
            this.tsBotoesPrincipais.Location = new System.Drawing.Point(0, 24);
            this.tsBotoesPrincipais.Name = "tsBotoesPrincipais";
            this.tsBotoesPrincipais.Size = new System.Drawing.Size(1018, 25);
            this.tsBotoesPrincipais.TabIndex = 4;
            // 
            // btnContasReceber
            // 
            this.btnContasReceber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnContasReceber.Image = global::Interface.rsxImagens.ContasReceber;
            this.btnContasReceber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContasReceber.Name = "btnContasReceber";
            this.btnContasReceber.Size = new System.Drawing.Size(23, 22);
            this.btnContasReceber.Text = "toolStripButton2";
            this.btnContasReceber.ToolTipText = "Contas a receber";
            this.btnContasReceber.Click += new System.EventHandler(this.btnContasReceber_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTrocarUsuario
            // 
            this.btnTrocarUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrocarUsuario.Image = global::Interface.rsxImagens.USERS_32;
            this.btnTrocarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrocarUsuario.Name = "btnTrocarUsuario";
            this.btnTrocarUsuario.Size = new System.Drawing.Size(23, 22);
            this.btnTrocarUsuario.ToolTipText = "Trocar de Usuário";
            this.btnTrocarUsuario.Click += new System.EventHandler(this.btnTrocarUsuario_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSair
            // 
            this.btnSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSair.Image = global::Interface.rsxImagens.door_in;
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(23, 22);
            this.btnSair.Text = "toolStripButton2";
            this.btnSair.ToolTipText = "Sair do sistema";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 736);
            this.Controls.Add(this.imgFundoPrincipal);
            this.Controls.Add(this.tsBotoesPrincipais);
            this.Controls.Add(this.stPrincipal);
            this.Controls.Add(this.mnuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundoPrincipal)).EndInit();
            this.tsBotoesPrincipais.ResumeLayout(false);
            this.tsBotoesPrincipais.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripButton tsBtnSair;
        private System.Windows.Forms.ToolStripButton tsBtnTrocarUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip stPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel stlblUsuarioLogado;
        private System.Windows.Forms.ToolStripStatusLabel stlblHora;
        private System.Windows.Forms.ToolStripStatusLabel stDataAtual;
        private System.Windows.Forms.PictureBox imgFundoPrincipal;
        private System.Windows.Forms.ToolStripButton tsBtnContasReceber;
        private System.Windows.Forms.ToolStripMenuItem mnuControle;
        private System.Windows.Forms.ToolStripMenuItem mnuAluno;
        private System.Windows.Forms.ToolStripMenuItem mnuContasAReceber;
        private System.Windows.Forms.ToolStripMenuItem mnuPais;
        private System.Windows.Forms.ToolStripMenuItem mnuEstado;
        private System.Windows.Forms.ToolStripMenuItem mnuCidade;
        private System.Windows.Forms.ToolStripMenuItem mnuSair;
        private System.Windows.Forms.ToolStripMenuItem mnuAjuda;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpresa;
        private System.Windows.Forms.ToolStripMenuItem mnuProfissao;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuconfiguracoes;
        private System.Windows.Forms.ToolStripMenuItem mnuSistema;
        private System.Windows.Forms.ToolStrip tsBotoesPrincipais;
        private System.Windows.Forms.ToolStripButton btnTrocarUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnContasReceber;

    }
}