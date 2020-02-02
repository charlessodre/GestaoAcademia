namespace Interface
{
    partial class frmConfigurarSistema
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
            this.ofdFoto = new System.Windows.Forms.OpenFileDialog();
            this.tbpConfiguracoesGerais = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbxImgFundoTela = new System.Windows.Forms.PictureBox();
            this.btnProcurarImgFundoTela = new System.Windows.Forms.Button();
            this.btnExcluirImgFundoTela = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbcConfiguracoesSistema = new System.Windows.Forms.TabControl();
            this.tbpDadosEmpresa = new System.Windows.Forms.TabPage();
            this.btnNovoEstado = new System.Windows.Forms.Button();
            this.btnNovaCidade = new System.Windows.Forms.Button();
            this.txtmCEP = new System.Windows.Forms.MaskedTextBox();
            this.txtmFax = new System.Windows.Forms.MaskedTextBox();
            this.txtmTelefone = new System.Windows.Forms.MaskedTextBox();
            this.cboCidade = new System.Windows.Forms.ComboBox();
            this.cboUF = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcurarImagem = new System.Windows.Forms.Button();
            this.btnExcluirImagem = new System.Windows.Forms.Button();
            this.pbxLogoEmpresa = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtmCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.txtInscricaoEstadual = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.tbpConfiguracoesGerais.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImgFundoTela)).BeginInit();
            this.tbcConfiguracoesSistema.SuspendLayout();
            this.tbpDadosEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdFoto
            // 
            this.ofdFoto.Title = "Selecionar foto...";
            // 
            // tbpConfiguracoesGerais
            // 
            this.tbpConfiguracoesGerais.Controls.Add(this.groupBox1);
            this.tbpConfiguracoesGerais.Controls.Add(this.button5);
            this.tbpConfiguracoesGerais.Controls.Add(this.button4);
            this.tbpConfiguracoesGerais.Location = new System.Drawing.Point(4, 25);
            this.tbpConfiguracoesGerais.Name = "tbpConfiguracoesGerais";
            this.tbpConfiguracoesGerais.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConfiguracoesGerais.Size = new System.Drawing.Size(852, 337);
            this.tbpConfiguracoesGerais.TabIndex = 0;
            this.tbpConfiguracoesGerais.Text = "Configurações Gerais";
            this.tbpConfiguracoesGerais.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbxImgFundoTela);
            this.groupBox1.Controls.Add(this.btnProcurarImgFundoTela);
            this.groupBox1.Controls.Add(this.btnExcluirImgFundoTela);
            this.groupBox1.Location = new System.Drawing.Point(648, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 238);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fundo da Tela Principal";
            // 
            // pbxImgFundoTela
            // 
            this.pbxImgFundoTela.Image = global::Interface.rsxImagens.indisponivel200x200;
            this.pbxImgFundoTela.Location = new System.Drawing.Point(20, 30);
            this.pbxImgFundoTela.Name = "pbxImgFundoTela";
            this.pbxImgFundoTela.Size = new System.Drawing.Size(150, 150);
            this.pbxImgFundoTela.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImgFundoTela.TabIndex = 32;
            this.pbxImgFundoTela.TabStop = false;
            // 
            // btnProcurarImgFundoTela
            // 
            this.btnProcurarImgFundoTela.AccessibleDescription = "";
            this.btnProcurarImgFundoTela.BackgroundImage = global::Interface.rsxImagens.PastaFotos24;
            this.btnProcurarImgFundoTela.FlatAppearance.BorderSize = 0;
            this.btnProcurarImgFundoTela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcurarImgFundoTela.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcurarImgFundoTela.Location = new System.Drawing.Point(55, 190);
            this.btnProcurarImgFundoTela.Name = "btnProcurarImgFundoTela";
            this.btnProcurarImgFundoTela.Size = new System.Drawing.Size(24, 24);
            this.btnProcurarImgFundoTela.TabIndex = 34;
            this.btnProcurarImgFundoTela.UseVisualStyleBackColor = true;
            // 
            // btnExcluirImgFundoTela
            // 
            this.btnExcluirImgFundoTela.AccessibleDescription = "";
            this.btnExcluirImgFundoTela.BackgroundImage = global::Interface.rsxImagens.delete24;
            this.btnExcluirImgFundoTela.FlatAppearance.BorderSize = 0;
            this.btnExcluirImgFundoTela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirImgFundoTela.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirImgFundoTela.Location = new System.Drawing.Point(96, 190);
            this.btnExcluirImgFundoTela.Name = "btnExcluirImgFundoTela";
            this.btnExcluirImgFundoTela.Size = new System.Drawing.Size(24, 24);
            this.btnExcluirImgFundoTela.TabIndex = 33;
            this.btnExcluirImgFundoTela.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1223, 76);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1076, 177);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tbcConfiguracoesSistema
            // 
            this.tbcConfiguracoesSistema.Controls.Add(this.tbpDadosEmpresa);
            this.tbcConfiguracoesSistema.Controls.Add(this.tbpConfiguracoesGerais);
            this.tbcConfiguracoesSistema.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcConfiguracoesSistema.Location = new System.Drawing.Point(12, 12);
            this.tbcConfiguracoesSistema.Name = "tbcConfiguracoesSistema";
            this.tbcConfiguracoesSistema.SelectedIndex = 0;
            this.tbcConfiguracoesSistema.Size = new System.Drawing.Size(860, 366);
            this.tbcConfiguracoesSistema.TabIndex = 0;
            // 
            // tbpDadosEmpresa
            // 
            this.tbpDadosEmpresa.Controls.Add(this.btnNovoEstado);
            this.tbpDadosEmpresa.Controls.Add(this.btnNovaCidade);
            this.tbpDadosEmpresa.Controls.Add(this.txtmCEP);
            this.tbpDadosEmpresa.Controls.Add(this.txtmFax);
            this.tbpDadosEmpresa.Controls.Add(this.txtmTelefone);
            this.tbpDadosEmpresa.Controls.Add(this.cboCidade);
            this.tbpDadosEmpresa.Controls.Add(this.cboUF);
            this.tbpDadosEmpresa.Controls.Add(this.txtEmail);
            this.tbpDadosEmpresa.Controls.Add(this.txtBairro);
            this.tbpDadosEmpresa.Controls.Add(this.txtEndereco);
            this.tbpDadosEmpresa.Controls.Add(this.label13);
            this.tbpDadosEmpresa.Controls.Add(this.label9);
            this.tbpDadosEmpresa.Controls.Add(this.label8);
            this.tbpDadosEmpresa.Controls.Add(this.label7);
            this.tbpDadosEmpresa.Controls.Add(this.label17);
            this.tbpDadosEmpresa.Controls.Add(this.label5);
            this.tbpDadosEmpresa.Controls.Add(this.label4);
            this.tbpDadosEmpresa.Controls.Add(this.label3);
            this.tbpDadosEmpresa.Controls.Add(this.btnProcurarImagem);
            this.tbpDadosEmpresa.Controls.Add(this.btnExcluirImagem);
            this.tbpDadosEmpresa.Controls.Add(this.pbxLogoEmpresa);
            this.tbpDadosEmpresa.Controls.Add(this.button3);
            this.tbpDadosEmpresa.Controls.Add(this.button6);
            this.tbpDadosEmpresa.Controls.Add(this.txtmCNPJ);
            this.tbpDadosEmpresa.Controls.Add(this.txtSite);
            this.tbpDadosEmpresa.Controls.Add(this.txtInscricaoEstadual);
            this.tbpDadosEmpresa.Controls.Add(this.label14);
            this.tbpDadosEmpresa.Controls.Add(this.txtRazaoSocial);
            this.tbpDadosEmpresa.Controls.Add(this.txtNomeFantasia);
            this.tbpDadosEmpresa.Controls.Add(this.label22);
            this.tbpDadosEmpresa.Controls.Add(this.label15);
            this.tbpDadosEmpresa.Controls.Add(this.label1);
            this.tbpDadosEmpresa.Controls.Add(this.label30);
            this.tbpDadosEmpresa.Location = new System.Drawing.Point(4, 25);
            this.tbpDadosEmpresa.Name = "tbpDadosEmpresa";
            this.tbpDadosEmpresa.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDadosEmpresa.Size = new System.Drawing.Size(852, 337);
            this.tbpDadosEmpresa.TabIndex = 1;
            this.tbpDadosEmpresa.Text = "Empresa";
            this.tbpDadosEmpresa.UseVisualStyleBackColor = true;
            // 
            // btnNovoEstado
            // 
            this.btnNovoEstado.BackgroundImage = global::Interface.rsxImagens.add24;
            this.btnNovoEstado.FlatAppearance.BorderSize = 0;
            this.btnNovoEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoEstado.Location = new System.Drawing.Point(601, 216);
            this.btnNovoEstado.Name = "btnNovoEstado";
            this.btnNovoEstado.Size = new System.Drawing.Size(24, 24);
            this.btnNovoEstado.TabIndex = 10;
            this.btnNovoEstado.UseVisualStyleBackColor = true;
            this.btnNovoEstado.Click += new System.EventHandler(this.btnNovoEstado_Click);
            // 
            // btnNovaCidade
            // 
            this.btnNovaCidade.BackgroundImage = global::Interface.rsxImagens.add24;
            this.btnNovaCidade.FlatAppearance.BorderSize = 0;
            this.btnNovaCidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaCidade.Location = new System.Drawing.Point(374, 216);
            this.btnNovaCidade.Name = "btnNovaCidade";
            this.btnNovaCidade.Size = new System.Drawing.Size(24, 24);
            this.btnNovaCidade.TabIndex = 8;
            this.btnNovaCidade.UseVisualStyleBackColor = true;
            this.btnNovaCidade.Click += new System.EventHandler(this.btnNovaCidade_Click);
            // 
            // txtmCEP
            // 
            this.txtmCEP.Location = new System.Drawing.Point(463, 179);
            this.txtmCEP.Mask = "00000-000";
            this.txtmCEP.Name = "txtmCEP";
            this.txtmCEP.Size = new System.Drawing.Size(132, 24);
            this.txtmCEP.TabIndex = 6;
            this.txtmCEP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtmFax
            // 
            this.txtmFax.Location = new System.Drawing.Point(293, 256);
            this.txtmFax.Mask = "(999) 0000-0000";
            this.txtmFax.Name = "txtmFax";
            this.txtmFax.Size = new System.Drawing.Size(127, 24);
            this.txtmFax.TabIndex = 14;
            this.txtmFax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtmTelefone
            // 
            this.txtmTelefone.Location = new System.Drawing.Point(90, 256);
            this.txtmTelefone.Mask = "(999) 0000-0000";
            this.txtmTelefone.Name = "txtmTelefone";
            this.txtmTelefone.Size = new System.Drawing.Size(127, 24);
            this.txtmTelefone.TabIndex = 13;
            this.txtmTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cboCidade
            // 
            this.cboCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCidade.FormattingEnabled = true;
            this.cboCidade.Location = new System.Drawing.Point(90, 215);
            this.cboCidade.Name = "cboCidade";
            this.cboCidade.Size = new System.Drawing.Size(278, 24);
            this.cboCidade.TabIndex = 7;
            // 
            // cboUF
            // 
            this.cboUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUF.FormattingEnabled = true;
            this.cboUF.Location = new System.Drawing.Point(463, 216);
            this.cboUF.Name = "cboUF";
            this.cboUF.Size = new System.Drawing.Size(132, 24);
            this.cboUF.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Location = new System.Drawing.Point(90, 297);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(308, 24);
            this.txtEmail.TabIndex = 15;
            // 
            // txtBairro
            // 
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Location = new System.Drawing.Point(90, 179);
            this.txtBairro.MaxLength = 200;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(278, 24);
            this.txtBairro.TabIndex = 5;
            // 
            // txtEndereco
            // 
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Location = new System.Drawing.Point(90, 146);
            this.txtEndereco.MaxLength = 200;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(505, 24);
            this.txtEndereco.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 17);
            this.label13.TabIndex = 34;
            this.label13.Text = "E-mail";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Telefone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(239, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Fax";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(424, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "UF";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 218);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 17);
            this.label17.TabIndex = 39;
            this.label17.Text = "Cidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(424, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "CEP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Bairro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Endereço";
            // 
            // btnProcurarImagem
            // 
            this.btnProcurarImagem.AccessibleDescription = "";
            this.btnProcurarImagem.BackgroundImage = global::Interface.rsxImagens.PastaFotos24;
            this.btnProcurarImagem.FlatAppearance.BorderSize = 0;
            this.btnProcurarImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcurarImagem.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcurarImagem.Location = new System.Drawing.Point(774, 226);
            this.btnProcurarImagem.Name = "btnProcurarImagem";
            this.btnProcurarImagem.Size = new System.Drawing.Size(24, 24);
            this.btnProcurarImagem.TabIndex = 11;
            this.btnProcurarImagem.UseVisualStyleBackColor = true;
            this.btnProcurarImagem.Click += new System.EventHandler(this.btnProcurarImagem_Click);
            // 
            // btnExcluirImagem
            // 
            this.btnExcluirImagem.AccessibleDescription = "";
            this.btnExcluirImagem.BackgroundImage = global::Interface.rsxImagens.delete24;
            this.btnExcluirImagem.FlatAppearance.BorderSize = 0;
            this.btnExcluirImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirImagem.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirImagem.Location = new System.Drawing.Point(804, 225);
            this.btnExcluirImagem.Name = "btnExcluirImagem";
            this.btnExcluirImagem.Size = new System.Drawing.Size(24, 24);
            this.btnExcluirImagem.TabIndex = 12;
            this.btnExcluirImagem.UseVisualStyleBackColor = true;
            this.btnExcluirImagem.Click += new System.EventHandler(this.btnExcluirImagem_Click);
            // 
            // pbxLogoEmpresa
            // 
            this.pbxLogoEmpresa.Image = global::Interface.rsxImagens.indisponivel200x200;
            this.pbxLogoEmpresa.Location = new System.Drawing.Point(639, 21);
            this.pbxLogoEmpresa.Name = "pbxLogoEmpresa";
            this.pbxLogoEmpresa.Size = new System.Drawing.Size(200, 200);
            this.pbxLogoEmpresa.TabIndex = 29;
            this.pbxLogoEmpresa.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1223, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1076, 177);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // txtmCNPJ
            // 
            this.txtmCNPJ.Location = new System.Drawing.Point(130, 94);
            this.txtmCNPJ.Mask = "00.000.000/0000-00";
            this.txtmCNPJ.Name = "txtmCNPJ";
            this.txtmCNPJ.Size = new System.Drawing.Size(152, 24);
            this.txtmCNPJ.TabIndex = 2;
            this.txtmCNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtSite
            // 
            this.txtSite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSite.Location = new System.Drawing.Point(464, 297);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(320, 24);
            this.txtSite.TabIndex = 16;
            // 
            // txtInscricaoEstadual
            // 
            this.txtInscricaoEstadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInscricaoEstadual.Location = new System.Drawing.Point(444, 94);
            this.txtInscricaoEstadual.MaxLength = 200;
            this.txtInscricaoEstadual.Name = "txtInscricaoEstadual";
            this.txtInscricaoEstadual.Size = new System.Drawing.Size(166, 24);
            this.txtInscricaoEstadual.TabIndex = 3;
            this.txtInscricaoEstadual.Text = "ISENTO";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(424, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Site";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazaoSocial.Location = new System.Drawing.Point(130, 58);
            this.txtRazaoSocial.MaxLength = 200;
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(480, 24);
            this.txtRazaoSocial.TabIndex = 1;
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeFantasia.Location = new System.Drawing.Point(130, 24);
            this.txtNomeFantasia.MaxLength = 200;
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(480, 24);
            this.txtNomeFantasia.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(14, 97);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "CNPJ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(304, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "Inscrição Estadual";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razão Social";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(14, 27);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(110, 17);
            this.label30.TabIndex = 0;
            this.label30.Text = "Nome Fantasia";
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::Interface.rsxImagens.door_in;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(773, 393);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 40);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.BackgroundImage = global::Interface.rsxImagens.floppy32;
            this.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGravar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.Location = new System.Drawing.Point(664, 393);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(95, 40);
            this.btnGravar.TabIndex = 0;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // frmConfigurarSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 448);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.tbcConfiguracoesSistema);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmConfigurarSistema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmCadastroEmpresa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmConfigurarSistema_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCadastroEmpresa_FormClosing);
            this.tbpConfiguracoesGerais.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImgFundoTela)).EndInit();
            this.tbcConfiguracoesSistema.ResumeLayout(false);
            this.tbpDadosEmpresa.ResumeLayout(false);
            this.tbpDadosEmpresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.OpenFileDialog ofdFoto;
        private System.Windows.Forms.TabPage tbpConfiguracoesGerais;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tbcConfiguracoesSistema;
        private System.Windows.Forms.TabPage tbpDadosEmpresa;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MaskedTextBox txtmCNPJ;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnProcurarImagem;
        private System.Windows.Forms.Button btnExcluirImagem;
        private System.Windows.Forms.PictureBox pbxLogoEmpresa;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInscricaoEstadual;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnNovoEstado;
        private System.Windows.Forms.Button btnNovaCidade;
        private System.Windows.Forms.MaskedTextBox txtmCEP;
        private System.Windows.Forms.MaskedTextBox txtmFax;
        private System.Windows.Forms.MaskedTextBox txtmTelefone;
        private System.Windows.Forms.ComboBox cboCidade;
        private System.Windows.Forms.ComboBox cboUF;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcurarImgFundoTela;
        private System.Windows.Forms.Button btnExcluirImgFundoTela;
        private System.Windows.Forms.PictureBox pbxImgFundoTela;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}