namespace Interface
{
    partial class frmReceberPagamento
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
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorAPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtmCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtmTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboFormasPagamentos = new System.Windows.Forms.ComboBox();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.txtValorRecebido = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbxFotoAluno = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentosReceber)).BeginInit();
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
            this.colDescricao,
            this.colDataVencimento,
            this.colValorAPagar});
            this.dgvPagamentosReceber.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPagamentosReceber.Location = new System.Drawing.Point(12, 253);
            this.dgvPagamentosReceber.MultiSelect = false;
            this.dgvPagamentosReceber.Name = "dgvPagamentosReceber";
            this.dgvPagamentosReceber.RowHeadersWidth = 10;
            this.dgvPagamentosReceber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPagamentosReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagamentosReceber.Size = new System.Drawing.Size(684, 100);
            this.dgvPagamentosReceber.StandardTab = true;
            this.dgvPagamentosReceber.TabIndex = 4;
            // 
            // colDescricao
            // 
            this.colDescricao.DataPropertyName = "Descricao";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 400;
            // 
            // colDataVencimento
            // 
            this.colDataVencimento.DataPropertyName = "DataVencimento";
            this.colDataVencimento.HeaderText = "Data Vencimento";
            this.colDataVencimento.Name = "colDataVencimento";
            this.colDataVencimento.ReadOnly = true;
            this.colDataVencimento.Width = 150;
            // 
            // colValorAPagar
            // 
            this.colValorAPagar.DataPropertyName = "ValorLancamento";
            this.colValorAPagar.HeaderText = "Valor a Pagar";
            this.colValorAPagar.Name = "colValorAPagar";
            this.colValorAPagar.ReadOnly = true;
            this.colValorAPagar.Width = 110;
            // 
            // txtmCelular
            // 
            this.txtmCelular.Location = new System.Drawing.Point(291, 182);
            this.txtmCelular.Mask = "(999) 0000-0000";
            this.txtmCelular.Name = "txtmCelular";
            this.txtmCelular.ReadOnly = true;
            this.txtmCelular.Size = new System.Drawing.Size(127, 20);
            this.txtmCelular.TabIndex = 3;
            this.txtmCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtmTelefone
            // 
            this.txtmTelefone.Location = new System.Drawing.Point(88, 182);
            this.txtmTelefone.Mask = "(999) 0000-0000";
            this.txtmTelefone.Name = "txtmTelefone";
            this.txtmTelefone.ReadOnly = true;
            this.txtmTelefone.Size = new System.Drawing.Size(127, 20);
            this.txtmTelefone.TabIndex = 2;
            this.txtmTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Telefone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(459, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Troco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Valor Recebido";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(230, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Celular";
            // 
            // cboFormasPagamentos
            // 
            this.cboFormasPagamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormasPagamentos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormasPagamentos.FormattingEnabled = true;
            this.cboFormasPagamentos.Location = new System.Drawing.Point(12, 450);
            this.cboFormasPagamentos.Name = "cboFormasPagamentos";
            this.cboFormasPagamentos.Size = new System.Drawing.Size(220, 27);
            this.cboFormasPagamentos.TabIndex = 6;
            // 
            // txtTroco
            // 
            this.txtTroco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTroco.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroco.Location = new System.Drawing.Point(513, 450);
            this.txtTroco.MaxLength = 200;
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.ReadOnly = true;
            this.txtTroco.Size = new System.Drawing.Size(77, 27);
            this.txtTroco.TabIndex = 8;
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorRecebido.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorRecebido.Location = new System.Drawing.Point(371, 450);
            this.txtValorRecebido.MaxLength = 200;
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.Size = new System.Drawing.Size(77, 27);
            this.txtValorRecebido.TabIndex = 7;
            // 
            // txtMatricula
            // 
            this.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatricula.Location = new System.Drawing.Point(88, 156);
            this.txtMatricula.MaxLength = 200;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.ReadOnly = true;
            this.txtMatricula.Size = new System.Drawing.Size(123, 20);
            this.txtMatricula.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(88, 130);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(399, 20);
            this.txtNome.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Forma de Pagamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Matrícula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nome";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.Location = new System.Drawing.Point(607, 374);
            this.txtValorTotal.MaxLength = 200;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(77, 27);
            this.txtValorTotal.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(465, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Valor total à pagar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "Pagamentos a receber";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(230, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(252, 19);
            this.label10.TabIndex = 31;
            this.label10.Text = "Recebimento de  Pagamentos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Interface.rsxImagens.ReceberPagamento;
            this.pictureBox1.Location = new System.Drawing.Point(14, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pbxFotoAluno
            // 
            this.pbxFotoAluno.BackColor = System.Drawing.Color.Silver;
            this.pbxFotoAluno.Location = new System.Drawing.Point(546, 74);
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
            this.btnFechar.Location = new System.Drawing.Point(589, 507);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 40);
            this.btnFechar.TabIndex = 10;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnReceber
            // 
            this.btnReceber.BackgroundImage = global::Interface.rsxImagens.ok;
            this.btnReceber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReceber.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceber.Location = new System.Drawing.Point(462, 507);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(101, 40);
            this.btnReceber.TabIndex = 9;
            this.btnReceber.Text = "&Receber";
            this.btnReceber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // frmReceberPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 568);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvPagamentosReceber);
            this.Controls.Add(this.txtmCelular);
            this.Controls.Add(this.txtmTelefone);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pbxFotoAluno);
            this.Controls.Add(this.cboFormasPagamentos);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.txtTroco);
            this.Controls.Add(this.txtValorRecebido);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnReceber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmReceberPagamento";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmReceberPagamento_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReceberPagamento_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReceberPagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentosReceber)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbxFotoAluno;
        private System.Windows.Forms.ComboBox cboFormasPagamentos;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.TextBox txtValorRecebido;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorAPagar;
    }
}