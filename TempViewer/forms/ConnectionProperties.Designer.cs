namespace TempViewer
{
	partial class ConnectionProperties
	{
		/// <summary>
		/// Требуется переменная конструктора.
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
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            this.lbAdress = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbDataBase = new System.Windows.Forms.Label();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbDatabase = new System.Windows.Forms.TextBox();
            this.btWriteToConf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbAdress
            // 
            this.lbAdress.AutoSize = true;
            this.lbAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAdress.Location = new System.Drawing.Point(12, 29);
            this.lbAdress.Name = "lbAdress";
            this.lbAdress.Size = new System.Drawing.Size(58, 16);
            this.lbAdress.TabIndex = 0;
            this.lbAdress.Text = "address";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLogin.Location = new System.Drawing.Point(12, 57);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(37, 16);
            this.lbLogin.TabIndex = 1;
            this.lbLogin.Text = "login";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPassword.Location = new System.Drawing.Point(12, 85);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(67, 16);
            this.lbPassword.TabIndex = 2;
            this.lbPassword.Text = "password";
            // 
            // lbDataBase
            // 
            this.lbDataBase.AutoSize = true;
            this.lbDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDataBase.Location = new System.Drawing.Point(12, 113);
            this.lbDataBase.Name = "lbDataBase";
            this.lbDataBase.Size = new System.Drawing.Size(66, 16);
            this.lbDataBase.TabIndex = 3;
            this.lbDataBase.Text = "database";
            // 
            // txbAddress
            // 
            this.txbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbAddress.Location = new System.Drawing.Point(94, 26);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(100, 22);
            this.txbAddress.TabIndex = 4;
            // 
            // txbLogin
            // 
            this.txbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbLogin.Location = new System.Drawing.Point(94, 54);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(100, 22);
            this.txbLogin.TabIndex = 5;
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbPassword.Location = new System.Drawing.Point(94, 82);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(100, 22);
            this.txbPassword.TabIndex = 6;
            // 
            // txbDatabase
            // 
            this.txbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbDatabase.Location = new System.Drawing.Point(94, 110);
            this.txbDatabase.Name = "txbDatabase";
            this.txbDatabase.Size = new System.Drawing.Size(100, 22);
            this.txbDatabase.TabIndex = 7;
            // 
            // btWriteToConf
            // 
            this.btWriteToConf.Location = new System.Drawing.Point(107, 153);
            this.btWriteToConf.Name = "btWriteToConf";
            this.btWriteToConf.Size = new System.Drawing.Size(87, 23);
            this.btWriteToConf.TabIndex = 8;
            this.btWriteToConf.Text = "Save to conf";
            this.btWriteToConf.UseVisualStyleBackColor = true;
            this.btWriteToConf.Click += new System.EventHandler(this.btWriteToConf_Click);
            // 
            // ConnectionProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 198);
            this.Controls.Add(this.btWriteToConf);
            this.Controls.Add(this.txbDatabase);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbLogin);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.lbDataBase);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.lbAdress);
            this.Name = "ConnectionProperties";
            this.Text = "Connection Properties";
            this.Load += new System.EventHandler(this.ConnectionProperties_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbAdress;
		private System.Windows.Forms.Label lbLogin;
		private System.Windows.Forms.Label lbPassword;
		private System.Windows.Forms.Label lbDataBase;
		private System.Windows.Forms.TextBox txbAddress;
		private System.Windows.Forms.TextBox txbLogin;
		private System.Windows.Forms.TextBox txbPassword;
		private System.Windows.Forms.TextBox txbDatabase;
        private System.Windows.Forms.Button btWriteToConf;
	}
}