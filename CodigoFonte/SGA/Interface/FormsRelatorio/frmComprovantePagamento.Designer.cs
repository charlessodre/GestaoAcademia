namespace Interface.FormsRelatorio
{
    partial class frmComprovantePagamento
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
            this.crvComprovantePagamento = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crComprovantePagamento1 = new Interface.Relatorios.crComprovantePagamento();
            this.SuspendLayout();
            // 
            // crvComprovantePagamento
            // 
            this.crvComprovantePagamento.ActiveViewIndex = -1;
            this.crvComprovantePagamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvComprovantePagamento.DisplayGroupTree = false;
            this.crvComprovantePagamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvComprovantePagamento.Location = new System.Drawing.Point(0, 0);
            this.crvComprovantePagamento.Name = "crvComprovantePagamento";
            this.crvComprovantePagamento.ShowCloseButton = false;
            this.crvComprovantePagamento.ShowGotoPageButton = false;
            this.crvComprovantePagamento.ShowGroupTreeButton = false;
            this.crvComprovantePagamento.ShowRefreshButton = false;
            this.crvComprovantePagamento.ShowTextSearchButton = false;
            this.crvComprovantePagamento.Size = new System.Drawing.Size(792, 566);
            this.crvComprovantePagamento.TabIndex = 0;
            // 
            // frmComprovantePagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.crvComprovantePagamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmComprovantePagamento";
            this.Text = "frmComprovantePagamento";
            this.Load += new System.EventHandler(this.frmComprovantePagamento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Interface.Relatorios.crComprovantePagamento crComprovantePagamento1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvComprovantePagamento;
    }
}