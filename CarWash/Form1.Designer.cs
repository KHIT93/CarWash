﻿namespace CarWash
{
    partial class Form1
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtInfoWash = new System.Windows.Forms.TextBox();
            this.btnSendStatistic = new System.Windows.Forms.Button();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.progBarWash = new System.Windows.Forms.ProgressBar();
            this.btnCancelWash = new System.Windows.Forms.Button();
            this.btnStartWash = new System.Windows.Forms.Button();
            this.rdbtnGoldWash = new System.Windows.Forms.RadioButton();
            this.rdbtnSilverWash = new System.Windows.Forms.RadioButton();
            this.rdbtnStandardWash = new System.Windows.Forms.RadioButton();
            this.tcCarWash = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tcCarWash.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtInfoWash);
            this.tabPage1.Controls.Add(this.btnSendStatistic);
            this.tabPage1.Controls.Add(this.lblCurrentStatus);
            this.tabPage1.Controls.Add(this.progBarWash);
            this.tabPage1.Controls.Add(this.btnCancelWash);
            this.tabPage1.Controls.Add(this.btnStartWash);
            this.tabPage1.Controls.Add(this.rdbtnGoldWash);
            this.tabPage1.Controls.Add(this.rdbtnSilverWash);
            this.tabPage1.Controls.Add(this.rdbtnStandardWash);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(795, 616);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bilvask 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtInfoWash
            // 
            this.txtInfoWash.Location = new System.Drawing.Point(207, 40);
            this.txtInfoWash.Multiline = true;
            this.txtInfoWash.Name = "txtInfoWash";
            this.txtInfoWash.Size = new System.Drawing.Size(544, 113);
            this.txtInfoWash.TabIndex = 8;
            this.txtInfoWash.Visible = false;
            // 
            // btnSendStatistic
            // 
            this.btnSendStatistic.Location = new System.Drawing.Point(610, 496);
            this.btnSendStatistic.Name = "btnSendStatistic";
            this.btnSendStatistic.Size = new System.Drawing.Size(141, 64);
            this.btnSendStatistic.TabIndex = 7;
            this.btnSendStatistic.Text = "Send statistik";
            this.btnSendStatistic.UseVisualStyleBackColor = true;
            this.btnSendStatistic.Click += new System.EventHandler(this.btnSendStatistic_Click);
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(317, 347);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(51, 20);
            this.lblCurrentStatus.TabIndex = 6;
            this.lblCurrentStatus.Text = "label1";
            this.lblCurrentStatus.Visible = false;
            // 
            // progBarWash
            // 
            this.progBarWash.Location = new System.Drawing.Point(207, 395);
            this.progBarWash.Name = "progBarWash";
            this.progBarWash.Size = new System.Drawing.Size(343, 31);
            this.progBarWash.TabIndex = 5;
            // 
            // btnCancelWash
            // 
            this.btnCancelWash.Location = new System.Drawing.Point(300, 496);
            this.btnCancelWash.Name = "btnCancelWash";
            this.btnCancelWash.Size = new System.Drawing.Size(141, 64);
            this.btnCancelWash.TabIndex = 4;
            this.btnCancelWash.Text = "Anuller vask";
            this.btnCancelWash.UseVisualStyleBackColor = true;
            this.btnCancelWash.Click += new System.EventHandler(this.btnCancelWash_Click);
            // 
            // btnStartWash
            // 
            this.btnStartWash.Location = new System.Drawing.Point(300, 255);
            this.btnStartWash.Name = "btnStartWash";
            this.btnStartWash.Size = new System.Drawing.Size(141, 64);
            this.btnStartWash.TabIndex = 3;
            this.btnStartWash.Text = "Start vask";
            this.btnStartWash.UseVisualStyleBackColor = true;
            this.btnStartWash.Click += new System.EventHandler(this.btnStartWash_Click);
            // 
            // rdbtnGoldWash
            // 
            this.rdbtnGoldWash.AutoSize = true;
            this.rdbtnGoldWash.Location = new System.Drawing.Point(31, 110);
            this.rdbtnGoldWash.Name = "rdbtnGoldWash";
            this.rdbtnGoldWash.Size = new System.Drawing.Size(70, 17);
            this.rdbtnGoldWash.TabIndex = 2;
            this.rdbtnGoldWash.Text = "Guldvask";
            this.rdbtnGoldWash.UseVisualStyleBackColor = true;
            this.rdbtnGoldWash.CheckedChanged += new System.EventHandler(this.rdbtnGoldWash_CheckedChanged);
            // 
            // rdbtnSilverWash
            // 
            this.rdbtnSilverWash.AutoSize = true;
            this.rdbtnSilverWash.Location = new System.Drawing.Point(31, 74);
            this.rdbtnSilverWash.Name = "rdbtnSilverWash";
            this.rdbtnSilverWash.Size = new System.Drawing.Size(69, 17);
            this.rdbtnSilverWash.TabIndex = 1;
            this.rdbtnSilverWash.Text = "Sølvvask";
            this.rdbtnSilverWash.UseVisualStyleBackColor = true;
            this.rdbtnSilverWash.CheckedChanged += new System.EventHandler(this.rdbtnSilverWash_CheckedChanged);
            // 
            // rdbtnStandardWash
            // 
            this.rdbtnStandardWash.AutoSize = true;
            this.rdbtnStandardWash.Checked = true;
            this.rdbtnStandardWash.Location = new System.Drawing.Point(31, 41);
            this.rdbtnStandardWash.Name = "rdbtnStandardWash";
            this.rdbtnStandardWash.Size = new System.Drawing.Size(94, 17);
            this.rdbtnStandardWash.TabIndex = 0;
            this.rdbtnStandardWash.TabStop = true;
            this.rdbtnStandardWash.Text = "Standard vask";
            this.rdbtnStandardWash.UseVisualStyleBackColor = true;
            this.rdbtnStandardWash.CheckedChanged += new System.EventHandler(this.rdbtnStandardWash_CheckedChanged);
            // 
            // tcCarWash
            // 
            this.tcCarWash.Controls.Add(this.tabPage1);
            this.tcCarWash.Location = new System.Drawing.Point(12, 12);
            this.tcCarWash.Name = "tcCarWash";
            this.tcCarWash.SelectedIndex = 0;
            this.tcCarWash.Size = new System.Drawing.Size(803, 642);
            this.tcCarWash.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 666);
            this.Controls.Add(this.tcCarWash);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tcCarWash.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tcCarWash;
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

