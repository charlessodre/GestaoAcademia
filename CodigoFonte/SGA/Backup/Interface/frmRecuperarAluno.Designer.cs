namespace Interface
{
    partial class frmRecuperarAluno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label32 = new System.Windows.Forms.Label();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.rbMatricula = new System.Windows.Forms.RadioButton();
            this.dgvConsutaAlunos = new System.Windows.Forms.DataGridView();
            this.colMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFoto = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pbxFotoAluno = new System.Windows.Forms.PictureBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsutaAlunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoAluno)).BeginInit();
            this.SuspendLayout();
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(28, 33);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(112, 17);
            this.label32.TabIndex = 0;
            this.label32.Text = "Procurar Aluno";
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Checked = true;
            this.rbNome.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNome.Location = new System.Drawing.Point(146, 59);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(59, 18);
            this.rbNome.TabIndex = 1;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "Nome";
            this.rbNome.UseVisualStyleBackColor = true;
            // 
            // rbMatricula
            // 
            this.rbMatricula.AutoSize = true;
            this.rbMatricula.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMatricula.Location = new System.Drawing.Point(233, 59);
            this.rbMatricula.Name = "rbMatricula";
            this.rbMatricula.Size = new System.Drawing.Size(81, 18);
            this.rbMatricula.TabIndex = 2;
            this.rbMatricula.TabStop = true;
            this.rbMatricula.Text = "Matrícula";
            this.rbMatricula.UseVisualStyleBackColor = true;
            // 
            // dgvConsutaAlunos
            // 
            this.dgvConsutaAlunos.AllowUserToAddRows = false;
            this.dgvConsutaAlunos.AllowUserToDeleteRows = false;
            this.dgvConsutaAlunos.AllowUserToResizeColumns = false;
            this.dgvConsutaAlunos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsutaAlunos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsutaAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsutaAlunos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatricula,
            this.colNome,
            this.colTelefone,
            this.colSituacao,
            this.colFoto});
            this.dgvConsutaAlunos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConsutaAlunos.Location = new System.Drawing.Point(0, 96);
            this.dgvConsutaAlunos.MultiSelect = false;
            this.dgvConsutaAlunos.Name = "dgvConsutaAlunos";
            this.dgvConsutaAlunos.RowHeadersWidth = 10;
            this.dgvConsutaAlunos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvConsutaAlunos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsutaAlunos.Size = new System.Drawing.Size(425, 299);
            this.dgvConsutaAlunos.StandardTab = true;
            this.dgvConsutaAlunos.TabIndex = 4;
            this.dgvConsutaAlunos.DoubleClick += new System.EventHandler(this.dgvConsutaAlunos_DoubleClick);
            this.dgvConsutaAlunos.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvConsutaAlunos_PreviewKeyDown);
            this.dgvConsutaAlunos.SelectionChanged += new System.EventHandler(this.dgvConsutaAlunos_SelectionChanged);
            // 
            // colMatricula
            // 
            this.colMatricula.DataPropertyName = "Codigo";
            this.colMatricula.HeaderText = "Matrícula";
            this.colMatricula.Name = "colMatricula";
            this.colMatricula.ReadOnly = true;
            this.colMatricula.Width = 90;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "Nome";
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 200;
            // 
            // colTelefone
            // 
            this.colTelefone.DataPropertyName = "TelefoneResidencial";
            this.colTelefone.HeaderText = "Telefone";
            this.colTelefone.Name = "colTelefone";
            this.colTelefone.ReadOnly = true;
            this.colTelefone.Width = 120;
            // 
            // colSituacao
            // 
            this.colSituacao.DataPropertyName = "Status";
            this.colSituacao.HeaderText = "Situação";
            this.colSituacao.Name = "colSituacao";
            this.colSituacao.ReadOnly = true;
            this.colSituacao.Visible = false;
            // 
            // colFoto
            // 
            this.colFoto.DataPropertyName = "Foto";
            this.colFoto.HeaderText = "Foto";
            this.colFoto.Name = "colFoto";
            this.colFoto.ReadOnly = true;
            this.colFoto.Visible = false;
            // 
            // txtProcurar
            // 
            this.txtProcurar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcurar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurar.Location = new System.Drawing.Point(146, 31);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(168, 22);
            this.txtProcurar.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::Interface.rsxImagens.door_in;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(473, 402);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 40);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pbxFotoAluno
            // 
            this.pbxFotoAluno.BackColor = System.Drawing.Color.Silver;
            this.pbxFotoAluno.Location = new System.Drawing.Point(433, 96);
            this.pbxFotoAluno.Name = "pbxFotoAluno";
            this.pbxFotoAluno.Size = new System.Drawing.Size(150, 150);
            this.pbxFotoAluno.TabIndex = 12;
            this.pbxFotoAluno.TabStop = false;
            // 
            // btnProcurar
            // 
            this.btnProcurar.AccessibleDescription = "";
            this.btnProcurar.BackgroundImage = global::Interface.rsxImagens.search_24x24;
            this.btnProcurar.FlatAppearance.BorderSize = 0;
            this.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcurar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcurar.Location = new System.Drawing.Point(320, 30);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(24, 24);
            this.btnProcurar.TabIndex = 3;
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // frmRecuperarAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 466);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.pbxFotoAluno);
            this.Controls.Add(this.dgvConsutaAlunos);
            this.Controls.Add(this.rbMatricula);
            this.Controls.Add(this.rbNome);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.label32);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmRecuperarAluno";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmRecuperarAluno_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRecuperarAluno_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecuperarAluno_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsutaAlunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoAluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.RadioButton rbMatricula;
        private System.Windows.Forms.DataGridView dgvConsutaAlunos;
        private System.Windows.Forms.PictureBox pbxFotoAluno;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSituacao;
        private System.Windows.Forms.DataGridViewImageColumn colFoto;
    }
}