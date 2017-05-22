namespace CarWash
{
    partial class TabTemplate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCurrentProcess = new System.Windows.Forms.Label();
            this.txtInfoWash = new System.Windows.Forms.TextBox();
            this.btnSendStatistic = new System.Windows.Forms.Button();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.progBarWash = new System.Windows.Forms.ProgressBar();
            this.btnCancelWash = new System.Windows.Forms.Button();
            this.btnStartWash = new System.Windows.Forms.Button();
            this.rdbtnGoldWash = new System.Windows.Forms.RadioButton();
            this.rdbtnSilverWash = new System.Windows.Forms.RadioButton();
            this.rdbtnStandardWash = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblCurrentProcess
            // 
            this.lblCurrentProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentProcess.Location = new System.Drawing.Point(209, 464);
            this.lblCurrentProcess.Name = "lblCurrentProcess";
            this.lblCurrentProcess.Size = new System.Drawing.Size(343, 44);
            this.lblCurrentProcess.TabIndex = 19;
            this.lblCurrentProcess.Text = "label1";
            this.lblCurrentProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentProcess.Visible = false;
            // 
            // txtInfoWash
            // 
            this.txtInfoWash.Location = new System.Drawing.Point(209, 55);
            this.txtInfoWash.Multiline = true;
            this.txtInfoWash.Name = "txtInfoWash";
            this.txtInfoWash.Size = new System.Drawing.Size(544, 113);
            this.txtInfoWash.TabIndex = 18;
            this.txtInfoWash.Visible = false;
            // 
            // btnSendStatistic
            // 
            this.btnSendStatistic.Location = new System.Drawing.Point(612, 511);
            this.btnSendStatistic.Name = "btnSendStatistic";
            this.btnSendStatistic.Size = new System.Drawing.Size(141, 64);
            this.btnSendStatistic.TabIndex = 17;
            this.btnSendStatistic.Text = "Send statistics";
            this.btnSendStatistic.UseVisualStyleBackColor = true;
            this.btnSendStatistic.Click += new System.EventHandler(this.btnSendStatistic_Click);
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(209, 349);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(343, 44);
            this.lblCurrentStatus.TabIndex = 16;
            this.lblCurrentStatus.Text = "label1";
            this.lblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentStatus.Visible = false;
            // 
            // progBarWash
            // 
            this.progBarWash.Location = new System.Drawing.Point(209, 410);
            this.progBarWash.Name = "progBarWash";
            this.progBarWash.Size = new System.Drawing.Size(343, 31);
            this.progBarWash.TabIndex = 15;
            // 
            // btnCancelWash
            // 
            this.btnCancelWash.Enabled = false;
            this.btnCancelWash.Location = new System.Drawing.Point(308, 511);
            this.btnCancelWash.Name = "btnCancelWash";
            this.btnCancelWash.Size = new System.Drawing.Size(141, 64);
            this.btnCancelWash.TabIndex = 14;
            this.btnCancelWash.Text = "Cancel wash";
            this.btnCancelWash.UseVisualStyleBackColor = true;
            this.btnCancelWash.Click += new System.EventHandler(this.btnCancelWash_Click);
            // 
            // btnStartWash
            // 
            this.btnStartWash.Location = new System.Drawing.Point(308, 282);
            this.btnStartWash.Name = "btnStartWash";
            this.btnStartWash.Size = new System.Drawing.Size(141, 64);
            this.btnStartWash.TabIndex = 13;
            this.btnStartWash.Text = "Start wash";
            this.btnStartWash.UseVisualStyleBackColor = true;
            this.btnStartWash.Click += new System.EventHandler(this.btnStartWash_Click);
            // 
            // rdbtnGoldWash
            // 
            this.rdbtnGoldWash.AutoSize = true;
            this.rdbtnGoldWash.Location = new System.Drawing.Point(33, 125);
            this.rdbtnGoldWash.Name = "rdbtnGoldWash";
            this.rdbtnGoldWash.Size = new System.Drawing.Size(75, 17);
            this.rdbtnGoldWash.TabIndex = 12;
            this.rdbtnGoldWash.Text = "Gold wash";
            this.rdbtnGoldWash.UseVisualStyleBackColor = true;
            this.rdbtnGoldWash.CheckedChanged += new System.EventHandler(this.rdbtnGoldWash_CheckedChanged);
            // 
            // rdbtnSilverWash
            // 
            this.rdbtnSilverWash.AutoSize = true;
            this.rdbtnSilverWash.Location = new System.Drawing.Point(33, 89);
            this.rdbtnSilverWash.Name = "rdbtnSilverWash";
            this.rdbtnSilverWash.Size = new System.Drawing.Size(79, 17);
            this.rdbtnSilverWash.TabIndex = 11;
            this.rdbtnSilverWash.Text = "Silver wash";
            this.rdbtnSilverWash.UseVisualStyleBackColor = true;
            this.rdbtnSilverWash.CheckedChanged += new System.EventHandler(this.rdbtnSilverWash_CheckedChanged);
            // 
            // rdbtnStandardWash
            // 
            this.rdbtnStandardWash.AutoSize = true;
            this.rdbtnStandardWash.Checked = true;
            this.rdbtnStandardWash.Location = new System.Drawing.Point(33, 56);
            this.rdbtnStandardWash.Name = "rdbtnStandardWash";
            this.rdbtnStandardWash.Size = new System.Drawing.Size(96, 17);
            this.rdbtnStandardWash.TabIndex = 10;
            this.rdbtnStandardWash.TabStop = true;
            this.rdbtnStandardWash.Text = "Standard wash";
            this.rdbtnStandardWash.UseVisualStyleBackColor = true;
            this.rdbtnStandardWash.CheckedChanged += new System.EventHandler(this.rdbtnStandardWash_CheckedChanged);
            // 
            // TabTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCurrentProcess);
            this.Controls.Add(this.txtInfoWash);
            this.Controls.Add(this.btnSendStatistic);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.progBarWash);
            this.Controls.Add(this.btnCancelWash);
            this.Controls.Add(this.btnStartWash);
            this.Controls.Add(this.rdbtnGoldWash);
            this.Controls.Add(this.rdbtnSilverWash);
            this.Controls.Add(this.rdbtnStandardWash);
            this.Name = "TabTemplate";
            this.Size = new System.Drawing.Size(811, 684);
            this.Load += new System.EventHandler(this.TabTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentProcess;
        private System.Windows.Forms.TextBox txtInfoWash;
        private System.Windows.Forms.Button btnSendStatistic;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.ProgressBar progBarWash;
        private System.Windows.Forms.Button btnCancelWash;
        private System.Windows.Forms.Button btnStartWash;
        private System.Windows.Forms.RadioButton rdbtnGoldWash;
        private System.Windows.Forms.RadioButton rdbtnSilverWash;
        private System.Windows.Forms.RadioButton rdbtnStandardWash;
    }
}
