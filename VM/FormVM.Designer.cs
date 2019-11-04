namespace VM
{
    partial class FormVM
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxUserPurse = new System.Windows.Forms.GroupBox();
            this.groupBoxVMPurse = new System.Windows.Forms.GroupBox();
            this.groupBoxGoods = new System.Windows.Forms.GroupBox();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBoxUserPurse
            // 
            this.groupBoxUserPurse.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUserPurse.Name = "groupBoxUserPurse";
            this.groupBoxUserPurse.Size = new System.Drawing.Size(221, 439);
            this.groupBoxUserPurse.TabIndex = 1;
            this.groupBoxUserPurse.TabStop = false;
            this.groupBoxUserPurse.Text = "Кошелек пользователя";
            // 
            // groupBoxVMPurse
            // 
            this.groupBoxVMPurse.Location = new System.Drawing.Point(540, 12);
            this.groupBoxVMPurse.Name = "groupBoxVMPurse";
            this.groupBoxVMPurse.Size = new System.Drawing.Size(108, 439);
            this.groupBoxVMPurse.TabIndex = 2;
            this.groupBoxVMPurse.TabStop = false;
            this.groupBoxVMPurse.Text = "Кошелек VM";
            // 
            // groupBoxGoods
            // 
            this.groupBoxGoods.Location = new System.Drawing.Point(239, 66);
            this.groupBoxGoods.Name = "groupBoxGoods";
            this.groupBoxGoods.Size = new System.Drawing.Size(286, 385);
            this.groupBoxGoods.TabIndex = 3;
            this.groupBoxGoods.TabStop = false;
            this.groupBoxGoods.Text = "Товары";
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeposit.Location = new System.Drawing.Point(239, 27);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(185, 16);
            this.labelDeposit.TabIndex = 4;
            this.labelDeposit.Text = "Внесенная сумма 0 руб.";
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(430, 17);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(95, 36);
            this.buttonChange.TabIndex = 5;
            this.buttonChange.Text = "Сдача";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // FormVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 460);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.labelDeposit);
            this.Controls.Add(this.groupBoxGoods);
            this.Controls.Add(this.groupBoxVMPurse);
            this.Controls.Add(this.groupBoxUserPurse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormVM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vending Machine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxUserPurse;
        private System.Windows.Forms.GroupBox groupBoxVMPurse;
        private System.Windows.Forms.GroupBox groupBoxGoods;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.Button buttonChange;
    }
}

