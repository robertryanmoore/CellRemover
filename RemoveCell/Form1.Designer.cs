namespace RemoveCell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmbEnviroList = new System.Windows.Forms.ComboBox();
            this.txbCellNum = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbEnviroList
            // 
            this.cmbEnviroList.AllowDrop = true;
            this.cmbEnviroList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnviroList.FormattingEnabled = true;
            this.cmbEnviroList.Items.AddRange(new object[] {
            "Lab",
            "Dev",
            "QA",
            "Pre-Prod",
            "Prod"});
            this.cmbEnviroList.Location = new System.Drawing.Point(18, 18);
            this.cmbEnviroList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEnviroList.Name = "cmbEnviroList";
            this.cmbEnviroList.Size = new System.Drawing.Size(180, 28);
            this.cmbEnviroList.TabIndex = 0;
            // 
            // txbCellNum
            // 
            this.txbCellNum.Location = new System.Drawing.Point(210, 18);
            this.txbCellNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCellNum.MaxLength = 15;
            this.txbCellNum.Name = "txbCellNum";
            this.txbCellNum.Size = new System.Drawing.Size(127, 26);
            this.txbCellNum.TabIndex = 1;
            this.txbCellNum.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(348, 18);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 35);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(18, 66);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(214, 42);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 98);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txbCellNum);
            this.Controls.Add(this.cmbEnviroList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(492, 154);
            this.MinimumSize = new System.Drawing.Size(492, 154);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Cell Remover - ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEnviroList;
        private System.Windows.Forms.TextBox txbCellNum;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblInfo;
    }
}

