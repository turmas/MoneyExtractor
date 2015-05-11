namespace MoneyExtractor.UI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UxTxtProductAmount = new System.Windows.Forms.TextBox();
            this.UxBtnPayment = new System.Windows.Forms.Button();
            this.UxTxtPaidAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UxTxtChange = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UxTxtProductAmount
            // 
            this.UxTxtProductAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UxTxtProductAmount.Location = new System.Drawing.Point(179, 24);
            this.UxTxtProductAmount.Name = "UxTxtProductAmount";
            this.UxTxtProductAmount.Size = new System.Drawing.Size(351, 26);
            this.UxTxtProductAmount.TabIndex = 0;
            // 
            // UxBtnPayment
            // 
            this.UxBtnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UxBtnPayment.Location = new System.Drawing.Point(179, 146);
            this.UxBtnPayment.Name = "UxBtnPayment";
            this.UxBtnPayment.Size = new System.Drawing.Size(351, 32);
            this.UxBtnPayment.TabIndex = 2;
            this.UxBtnPayment.Text = "Pagar";
            this.UxBtnPayment.UseVisualStyleBackColor = true;
            this.UxBtnPayment.Click += new System.EventHandler(this.UxBtnPayment_Click);
            // 
            // UxTxtPaidAmount
            // 
            this.UxTxtPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UxTxtPaidAmount.Location = new System.Drawing.Point(179, 83);
            this.UxTxtPaidAmount.Name = "UxTxtPaidAmount";
            this.UxTxtPaidAmount.Size = new System.Drawing.Size(351, 26);
            this.UxTxtPaidAmount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Valor do Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor Pago";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Troco";
            // 
            // UxTxtChange
            // 
            this.UxTxtChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UxTxtChange.Location = new System.Drawing.Point(179, 208);
            this.UxTxtChange.Multiline = true;
            this.UxTxtChange.Name = "UxTxtChange";
            this.UxTxtChange.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UxTxtChange.Size = new System.Drawing.Size(351, 118);
            this.UxTxtChange.TabIndex = 4;
            // 
            // Form1
            // 
            this.AcceptButton = this.UxBtnPayment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 349);
            this.Controls.Add(this.UxTxtChange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UxTxtPaidAmount);
            this.Controls.Add(this.UxBtnPayment);
            this.Controls.Add(this.UxTxtProductAmount);
            this.Name = "Form1";
            this.Text = "Money Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UxTxtProductAmount;
        private System.Windows.Forms.Button UxBtnPayment;
        private System.Windows.Forms.TextBox UxTxtPaidAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UxTxtChange;
    }
}

