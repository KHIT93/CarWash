namespace CarWash
{
    partial class StatisticForm
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
            this.dgvStatistic = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStatistic
            // 
            this.dgvStatistic.AllowUserToAddRows = false;
            this.dgvStatistic.AllowUserToDeleteRows = false;
            this.dgvStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistic.Location = new System.Drawing.Point(12, 12);
            this.dgvStatistic.Name = "dgvStatistic";
            this.dgvStatistic.ReadOnly = true;
            this.dgvStatistic.Size = new System.Drawing.Size(744, 503);
            this.dgvStatistic.TabIndex = 0;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 527);
            this.Controls.Add(this.dgvStatistic);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStatistic;
    }
}