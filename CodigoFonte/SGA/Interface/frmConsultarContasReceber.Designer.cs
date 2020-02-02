namespace Interface
{
    partial class frmConsultarContasReceber
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
            this.dgvPagamentosReceber = new System.Windows.Forms.DataGridView();
            this.txtmCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtmTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.rbAluno = new System.Windows.Forms.RadioButton();
            this.rbPeriodo = new System.Windows.Forms.RadioButton();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebito = new System.Windows.Forms.TextBox();
            this.pnlPeriodo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.pnlMatricula = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConsultarMatricula = new System.Windows.Forms.Button();
            this.btnRecibo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbxFotoAluno = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNovoLancamento = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorAPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPagoTexto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentosReceber)).BeginInit();
            this.pnlPeriodo.SuspendLayout();
            this.pnlMatricula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoAluno)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdFoto
            // 
            this.ofdFoto.Title = "Selecionar foto...";
            // 
            // dgvPagamentosReceber
            // 
            this.dgvPagamentosReceber.AllowUserToAddRows = false;
            this.dgvPagamentosReceber.AllowUserToDeleteRows = false;
            this.dgvPagamentosReceber.AllowUserToResizeColumns = false;
            this.dgvPagamentosReceber.AllowUserToResizeRows = false;
            this.dgvPagamentosReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagamentosReceber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNome,
            this.colDescricaoPagamento,
            this.colDataVencimento,
            this.colValorAPagar,
            this.colDataPagamento,
            this.colValorPago,
            this.colRecibo,
            this.colPagoTexto,
            this.colPago});
            this.dgvPagamentosReceber.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPagamentosReceber.Location = new System.Drawing.Point(12, 231);
            this.dgvPagamentosReceber.MultiSelect = false;
            this.dgvPagamentosReceber.Name = "dgvPagamentosReceber";
            this.dgvPagamentosReceber.RowHeadersWidth = 10;
            this.dgvPagamentosReceber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPagamentosReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagamentosReceber.Size = new System.Drawing.Size(870, 332);
            this.dgvPagamentosReceber.StandardTab = true;
            this.dgvPagamentosReceber.TabIndex = 6;
            this.dgvPagamentosReceber.DoubleClick += new System.EventHandler(this.dgvPagamentosReceber_DoubleClick);
            this.dgvPagamentosReceber.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvPagamentosReceber_PreviewKeyDown);
            this.dgvPagamentosReceber.SelectionChanged += new System.EventHandler(this.dgvPagamentosReceber_SelectionChanged);
            // 
            // txtmCelular
            // 
            this.txtmCelular.Location = new System.Drawing.Point(528, 191);
            this.txtmCelular.Mask = "(999) 0000-0000";
            this.txtmCelular.Name = "txtmCelular";
            this.txtmCelular.ReadOnly = true;
            this.txtmCelular.Size = new System.Drawing.Size(127, 20);
            this.txtmCelular.TabIndex = 5;
            this.txtmCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtmTelefone
            // 
            this.txtmTelefone.Location = new System.Drawing.Point(293, 191);
            this.txtmTelefone.Mask = "(999) 0000-0000";
            this.txtmTelefone.Name = "txtmTelefone";
            this.txtmTelefone.ReadOnly = true;
            this.txtmTelefone.Size = new System.Drawing.Size(127, 20);
            this.txtmTelefone.TabIndex = 4;
            this.txtmTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(217, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Telefone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(467, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Celular";
            // 
            // txtMatricula
            // 
            this.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatricula.Location = new System.Drawing.Point(88, 193);
            this.txtMatricula.MaxLength = 200;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.ReadOnly = true;
            this.txtMatricula.Size = new System.Drawing.Size(123, 20);
            this.txtMatricula.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(88, 156);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(332, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Matrícula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Aluno";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(152, 19);
            this.lblTitulo.TabIndex = 31;
            this.lblTitulo.Text = "Contas a Receber";
            // 
            // rbAluno
            // 
            this.rbAluno.AutoSize = true;
            this.rbAluno.Location = new System.Drawing.Point(140, 62);
            this.rbAluno.Name = "rbAluno";
            this.rbAluno.Size = new System.Drawing.Size(71, 17);
            this.rbAluno.TabIndex = 32;
            this.rbAluno.TabStop = true;
            this.rbAluno.Text = "Por Aluno";
            this.rbAluno.UseVisualStyleBackColor = true;
            this.rbAluno.CheckedChanged += new System.EventHandler(this.rbAluno_CheckedChanged);
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.AutoSize = true;
            this.rbPeriodo.Location = new System.Drawing.Point(231, 62);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(82, 17);
            this.rbPeriodo.TabIndex = 32;
            this.rbPeriodo.TabStop = true;
            this.rbPeriodo.Text = "Por Período";
            this.rbPeriodo.UseVisualStyleBackColor = true;
            this.rbPeriodo.CheckedChanged += new System.EventHandler(this.rbPeriodo_CheckedChanged);
            // 
            // txtProcurar
            // 
            this.txtProcurar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcurar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurar.Location = new System.Drawing.Point(79, 10);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(168, 22);
            this.txtProcurar.TabIndex = 1;
            this.txtProcurar.TextChanged += new System.EventHandler(this.txtProcurar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(467, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Débito";
            // 
            // txtDebito
            // 
            this.txtDebito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebito.Location = new System.Drawing.Point(526, 154);
            this.txtDebito.MaxLength = 200;
            this.txtDebito.Name = "txtDebito";
            this.txtDebito.ReadOnly = true;
            this.txtDebito.Size = new System.Drawing.Size(129, 20);
            this.txtDebito.TabIndex = 2;
            // 
            // pnlPeriodo
            // 
            this.pnlPeriodo.Controls.Add(this.label5);
            this.pnlPeriodo.Controls.Add(this.label4);
            this.pnlPeriodo.Controls.Add(this.dtpFim);
            this.pnlPeriodo.Controls.Add(this.dtpInicio);
            this.pnlPeriodo.Location = new System.Drawing.Point(318, 49);
            this.pnlPeriodo.Name = "pnlPeriodo";
            this.pnlPeriodo.Size = new System.Drawing.Size(330, 42);
            this.pnlPeriodo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "De";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "até";
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(198, 8);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(121, 20);
            this.dtpFim.TabIndex = 2;
            this.dtpFim.Validated += new System.EventHandler(this.dtpFim_Validated);
            this.dtpFim.CloseUp += new System.EventHandler(this.dtpFim_CloseUp);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(35, 8);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(121, 20);
            this.dtpInicio.TabIndex = 1;
            this.dtpInicio.Validated += new System.EventHandler(this.dtpInicio_Validated);
            this.dtpInicio.CloseUp += new System.EventHandler(this.dtpInicio_CloseUp);
            // 
            // pnlMatricula
            // 
            this.pnlMatricula.Controls.Add(this.label6);
            this.pnlMatricula.Controls.Add(this.btnConsultarMatricula);
            this.pnlMatricula.Controls.Add(this.txtProcurar);
            this.pnlMatricula.Location = new System.Drawing.Point(318, 49);
            this.pnlMatricula.Name = "pnlMatricula";
            this.pnlMatricula.Size = new System.Drawing.Size(286, 42);
            this.pnlMatricula.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Matrícula";
            // 
            // btnConsultarMatricula
            // 
            this.btnConsultarMatricula.AccessibleDescription = "";
            this.btnConsultarMatricula.BackgroundImage = global::Interface.rsxImagens.search_24x24;
            this.btnConsultarMatricula.FlatAppearance.BorderSize = 0;
            this.btnConsultarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarMatricula.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarMatricula.Location = new System.Drawing.Point(253, 8);
            this.btnConsultarMatricula.Name = "btnConsultarMatricula";
            this.btnConsultarMatricula.Size = new System.Drawing.Size(24, 24);
            this.btnConsultarMatricula.TabIndex = 2;
            this.btnConsultarMatricula.UseVisualStyleBackColor = true;
            this.btnConsultarMatricula.Click += new System.EventHandler(this.btnConsultarMatricula_Click);
            // 
            // btnRecibo
            // 
            this.btnRecibo.BackgroundImage = global::Interface.rsxImagens.btnRecibo;
            this.btnRecibo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRecibo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecibo.Location = new System.Drawing.Point(325, 600);
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.Size = new System.Drawing.Size(95, 40);
            this.btnRecibo.TabIndex = 10;
            this.btnRecibo.Text = "Reci&bo";
            this.btnRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecibo.UseVisualStyleBackColor = true;
            this.btnRecibo.Click += new System.EventHandler(this.btnRecibo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Interface.rsxImagens.ContasReceber;
            this.pictureBox1.Location = new System.Drawing.Point(15, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pbxFotoAluno
            // 
            this.pbxFotoAluno.BackColor = System.Drawing.Color.Silver;
            this.pbxFotoAluno.Location = new System.Drawing.Point(732, 61);
            this.pbxFotoAluno.Name = "pbxFotoAluno";
            this.pbxFotoAluno.Size = new System.Drawing.Size(150, 150);
            this.pbxFotoAluno.TabIndex = 27;
            this.pbxFotoAluno.TabStop = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::Interface.rsxImagens.door_in;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(772, 600);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 40);
            this.btnFechar.TabIndex = 12;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnNovoLancamento
            // 
            this.btnNovoLancamento.BackgroundImage = global::Interface.rsxImagens.btnLancar;
            this.btnNovoLancamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNovoLancamento.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoLancamento.Location = new System.Drawing.Point(22, 600);
            this.btnNovoLancamento.Name = "btnNovoLancamento";
            this.btnNovoLancamento.Size = new System.Drawing.Size(95, 40);
            this.btnNovoLancamento.TabIndex = 7;
            this.btnNovoLancamento.Text = "&Lançar";
            this.btnNovoLancamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoLancamento.UseVisualStyleBackColor = true;
            this.btnNovoLancamento.Click += new System.EventHandler(this.btnNovoLancamento_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackgroundImage = global::Interface.rsxImagens.caneta32;
            this.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAlterar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(123, 600);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(95, 40);
            this.btnAlterar.TabIndex = 8;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackgroundImage = global::Interface.rsxImagens.delete321;
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExcluir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(224, 600);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(95, 40);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnReceber
            // 
            this.btnReceber.BackgroundImage = global::Interface.rsxImagens.dinheiro32;
            this.btnReceber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReceber.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceber.Location = new System.Drawing.Point(542, 600);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(113, 40);
            this.btnReceber.TabIndex = 11;
            this.btnReceber.Text = "&Receber";
            this.btnReceber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "Codigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Visible = false;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "NomeAluno";
            this.colNome.HeaderText = "Aluno";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 130;
            // 
            // colDescricaoPagamento
            // 
            this.colDescricaoPagamento.DataPropertyName = "NomeServicoRealizado";
            this.colDescricaoPagamento.HeaderText = "Descrição Conta";
            this.colDescricaoPagamento.Name = "colDescricaoPagamento";
            this.colDescricaoPagamento.ReadOnly = true;
            this.colDescricaoPagamento.Width = 150;
            // 
            // colDataVencimento
            // 
            this.colDataVencimento.DataPropertyName = "DataVencimento";
            this.colDataVencimento.HeaderText = "Data Vencimento";
            this.colDataVencimento.Name = "colDataVencimento";
            this.colDataVencimento.ReadOnly = true;
            this.colDataVencimento.Width = 115;
            // 
            // colValorAPagar
            // 
            this.colValorAPagar.DataPropertyName = "ValorLancamento";
            this.colValorAPagar.HeaderText = "Valor a Pagar";
            this.colValorAPagar.Name = "colValorAPagar";
            this.colValorAPagar.ReadOnly = true;
            // 
            // colDataPagamento
            // 
            this.colDataPagamento.DataPropertyName = "DataPagamento";
            this.colDataPagamento.HeaderText = "Data Pagamento";
            this.colDataPagamento.Name = "colDataPagamento";
            this.colDataPagamento.ReadOnly = true;
            this.colDataPagamento.Width = 115;
            // 
            // colValorPago
            // 
            this.colValorPago.DataPropertyName = "ValorPagamento";
            this.colValorPago.HeaderText = "Valor Pago";
            this.colValorPago.Name = "colValorPago";
            this.colValorPago.ReadOnly = true;
            this.colValorPago.Width = 90;
            // 
            // colRecibo
            // 
            this.colRecibo.DataPropertyName = "CodigoRecibo";
            this.colRecibo.HeaderText = "Num. Recibo";
            this.colRecibo.Name = "colRecibo";
            this.colRecibo.ReadOnly = true;
            // 
            // colPagoTexto
            // 
            this.colPagoTexto.DataPropertyName = "PagoTexto";
            this.colPagoTexto.HeaderText = "Pago";
            this.colPagoTexto.Name = "colPagoTexto";
            this.colPagoTexto.ReadOnly = true;
            // 
            // colPago
            // 
            this.colPago.DataPropertyName = "Pago";
            this.colPago.HeaderText = "Pago Status";
            this.colPago.Name = "colPago";
            this.colPago.ReadOnly = true;
            this.colPago.Visible = false;
            this.colPago.Width = 50;
            // 
            // frmConsultarContasReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 675);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlMatricula);
            this.Controls.Add(this.pnlPeriodo);
            this.Controls.Add(this.rbPeriodo);
            this.Controls.Add(this.rbAluno);
            this.Controls.Add(this.dgvPagamentosReceber);
            this.Controls.Add(this.txtmCelular);
            this.Controls.Add(this.txtmTelefone);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pbxFotoAluno);
            this.Controls.Add(this.txtDebito);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnNovoLancamento);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnRecibo);
            this.Controls.Add(this.btnReceber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmConsultarContasReceber";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmConsultarContasReceber_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsultarContasReceber_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultarContasReceber_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentosReceber)).EndInit();
            this.pnlPeriodo.ResumeLayout(false);
            this.pnlPeriodo.PerformLayout();
            this.pnlMatricula.ResumeLayout(false);
            this.pnlMatricula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoAluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.OpenFileDialog ofdFoto;
        private System.Windows.Forms.DataGridView dgvPagamentosReceber;

        private System.Windows.Forms.MaskedTextBox txtmCelular;
        private System.Windows.Forms.MaskedTextBox txtmTelefone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbxFotoAluno;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.RadioButton rbAluno;
        private System.Windows.Forms.RadioButton rbPeriodo;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebito;
        private System.Windows.Forms.Panel pnlPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlMatricula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConsultarMatricula;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRecibo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovoLancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorAPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagoTexto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPago;
    }
}