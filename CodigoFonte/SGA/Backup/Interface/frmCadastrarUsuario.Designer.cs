namespace Interface
{
    partial class frmCadastrarUsuario
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
            this.tbpDadosCadastrais = new System.Windows.Forms.TabPage();
            this.nupwNTentativasLogin = new System.Windows.Forms.NumericUpDown();
            this.dtpExpiracaoSenha = new System.Windows.Forms.DateTimePicker();
            this.btnNovoGrupoUsuario = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cboGrupoUsuario = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcCadastroEmpresa = new System.Windows.Forms.TabControl();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.tbpDadosCadastrais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupwNTentativasLogin)).BeginInit();
            this.tbcCadastroEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdFoto
            // 
            this.ofdFoto.Title = "Selecionar foto...";
            // 
            // tbpDadosCadastrais
            // 
            this.tbpDadosCadastrais.Controls.Add(this.nupwNTentativasLogin);
            this.tbpDadosCadastrais.Controls.Add(this.dtpExpiracaoSenha);
            this.tbpDadosCadastrais.Controls.Add(this.btnNovoGrupoUsuario);
            this.tbpDadosCadastrais.Controls.Add(this.button5);
            this.tbpDadosCadastrais.Controls.Add(this.button4);
            this.tbpDadosCadastrais.Controls.Add(this.cboGrupoUsuario);
            this.tbpDadosCadastrais.Controls.Add(this.cboStatus);
            this.tbpDadosCadastrais.Controls.Add(this.txtEmail);
            this.tbpDadosCadastrais.Controls.Add(this.txtLogin);
            this.tbpDadosCadastrais.Controls.Add(this.txtMatricula);
            this.tbpDadosCadastrais.Controls.Add(this.txtNome);
            this.tbpDadosCadastrais.Controls.Add(this.txtCodigo);
            this.tbpDadosCadastrais.Controls.Add(this.label13);
            this.tbpDadosCadastrais.Controls.Add(this.label5);
            this.tbpDadosCadastrais.Controls.Add(this.label6);
            this.tbpDadosCadastrais.Controls.Add(this.label17);
            this.tbpDadosCadastrais.Controls.Add(this.label7);
            this.tbpDadosCadastrais.Controls.Add(this.label4);
            this.tbpDadosCadastrais.Controls.Add(this.label3);
            this.tbpDadosCadastrais.Controls.Add(this.label2);
            this.tbpDadosCadastrais.Controls.Add(this.label1);
            this.tbpDadosCadastrais.Location = new System.Drawing.Point(4, 25);
            this.tbpDadosCadastrais.Name = "tbpDadosCadastrais";
            this.tbpDadosCadastrais.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDadosCadastrais.Size = new System.Drawing.Size(733, 300);
            this.tbpDadosCadastrais.TabIndex = 0;
            this.tbpDadosCadastrais.Text = "Dados Cadastrais";
            this.tbpDadosCadastrais.UseVisualStyleBackColor = true;
            // 
            // nupwNTentativasLogin
            // 
            this.nupwNTentativasLogin.Location = new System.Drawing.Point(275, 202);
            this.nupwNTentativasLogin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupwNTentativasLogin.Name = "nupwNTentativasLogin";
            this.nupwNTentativasLogin.Size = new System.Drawing.Size(75, 24);
            this.nupwNTentativasLogin.TabIndex = 10;
            this.nupwNTentativasLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupwNTentativasLogin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpExpiracaoSenha
            // 
            this.dtpExpiracaoSenha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiracaoSenha.Location = new System.Drawing.Point(529, 163);
            this.dtpExpiracaoSenha.Name = "dtpExpiracaoSenha";
            this.dtpExpiracaoSenha.Size = new System.Drawing.Size(121, 24);
            this.dtpExpiracaoSenha.TabIndex = 9;
            // 
            // btnNovoGrupoUsuario
            // 
            this.btnNovoGrupoUsuario.BackgroundImage = global::Interface.rsxImagens.add24;
            this.btnNovoGrupoUsuario.FlatAppearance.BorderSize = 0;
            this.btnNovoGrupoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoGrupoUsuario.Location = new System.Drawing.Point(356, 163);
            this.btnNovoGrupoUsuario.Name = "btnNovoGrupoUsuario";
            this.btnNovoGrupoUsuario.Size = new System.Drawing.Size(24, 24);
            this.btnNovoGrupoUsuario.TabIndex = 8;
            this.btnNovoGrupoUsuario.UseVisualStyleBackColor = true;
            this.btnNovoGrupoUsuario.Click += new System.EventHandler(this.btnNovoGrupoUsuario_Click);
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
            // cboGrupoUsuario
            // 
            this.cboGrupoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoUsuario.FormattingEnabled = true;
            this.cboGrupoUsuario.Location = new System.Drawing.Point(130, 164);
            this.cboGrupoUsuario.Name = "cboGrupoUsuario";
            this.cboGrupoUsuario.Size = new System.Drawing.Size(220, 24);
            this.cboGrupoUsuario.TabIndex = 7;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(475, 126);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(231, 24);
            this.cboStatus.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Location = new System.Drawing.Point(93, 129);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 24);
            this.txtEmail.TabIndex = 5;
            // 
            // txtLogin
            // 
            this.txtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogin.Location = new System.Drawing.Point(475, 93);
            this.txtLogin.MaxLength = 200;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(231, 24);
            this.txtLogin.TabIndex = 4;
            // 
            // txtMatricula
            // 
            this.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatricula.Location = new System.Drawing.Point(93, 93);
            this.txtMatricula.MaxLength = 200;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(278, 24);
            this.txtMatricula.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(93, 58);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(613, 24);
            this.txtNome.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(93, 23);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 24);
            this.txtCodigo.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "E-mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Grupo Usuário";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(399, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Expiração Senha";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(399, 132);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Quantidade de tentativas de Logins";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(399, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Matrícula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // tbcCadastroEmpresa
            // 
            this.tbcCadastroEmpresa.Controls.Add(this.tbpDadosCadastrais);
            this.tbcCadastroEmpresa.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcCadastroEmpresa.Location = new System.Drawing.Point(12, 12);
            this.tbcCadastroEmpresa.Name = "tbcCadastroEmpresa";
            this.tbcCadastroEmpresa.SelectedIndex = 0;
            this.tbcCadastroEmpresa.Size = new System.Drawing.Size(741, 329);
            this.tbcCadastroEmpresa.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::Interface.rsxImagens.door_in;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(654, 359);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 40);
            this.btnFechar.TabIndex = 2;
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
            this.btnGravar.Location = new System.Drawing.Point(553, 359);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(95, 40);
            this.btnGravar.TabIndex = 1;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // frmCadastrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 417);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.tbcCadastroEmpresa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCadastrarUsuario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmCadastrarUsuario_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCadastrarUsuario_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCadastrarUsuario_KeyDown);
            this.tbpDadosCadastrais.ResumeLayout(false);
            this.tbpDadosCadastrais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupwNTentativasLogin)).EndInit();
            this.tbcCadastroEmpresa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.OpenFileDialog ofdFoto;
        private System.Windows.Forms.TabPage tbpDadosCadastrais;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tbcCadastroEmpresa;
        private System.Windows.Forms.Button btnNovoGrupoUsuario;
        private System.Windows.Forms.ComboBox cboGrupoUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpExpiracaoSenha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nupwNTentativasLogin;
        private System.Windows.Forms.Label label7;
    }
}