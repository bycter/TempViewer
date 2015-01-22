namespace TemperatureGraphs_MySql
{
	partial class MainForm
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
			this.btViewTable = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txbTableTarget = new System.Windows.Forms.TextBox();
			this.txbDateTarget = new System.Windows.Forms.TextBox();
			this.lbTableTarget = new System.Windows.Forms.Label();
			this.lbDateTarget = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btViewTable
			// 
			this.btViewTable.Location = new System.Drawing.Point(541, 369);
			this.btViewTable.Name = "btViewTable";
			this.btViewTable.Size = new System.Drawing.Size(134, 36);
			this.btViewTable.TabIndex = 1;
			this.btViewTable.Text = "Отобразить график";
			this.btViewTable.UseVisualStyleBackColor = true;
			this.btViewTable.Click += new System.EventHandler(this.btnViewTable_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(10, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = ".";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = ".";
			// 
			// txbTableTarget
			// 
			this.txbTableTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txbTableTarget.Location = new System.Drawing.Point(12, 376);
			this.txbTableTarget.Name = "txbTableTarget";
			this.txbTableTarget.Size = new System.Drawing.Size(119, 22);
			this.txbTableTarget.TabIndex = 5;
			// 
			// txbDateTarget
			// 
			this.txbDateTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txbDateTarget.Location = new System.Drawing.Point(178, 376);
			this.txbDateTarget.Name = "txbDateTarget";
			this.txbDateTarget.Size = new System.Drawing.Size(119, 22);
			this.txbDateTarget.TabIndex = 6;
			// 
			// lbTableTarget
			// 
			this.lbTableTarget.AutoSize = true;
			this.lbTableTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbTableTarget.Location = new System.Drawing.Point(12, 357);
			this.lbTableTarget.Name = "lbTableTarget";
			this.lbTableTarget.Size = new System.Drawing.Size(44, 16);
			this.lbTableTarget.TabIndex = 7;
			this.lbTableTarget.Text = "Table";
			// 
			// lbDateTarget
			// 
			this.lbDateTarget.AutoSize = true;
			this.lbDateTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbDateTarget.Location = new System.Drawing.Point(175, 357);
			this.lbDateTarget.Name = "lbDateTarget";
			this.lbDateTarget.Size = new System.Drawing.Size(37, 16);
			this.lbDateTarget.TabIndex = 8;
			this.lbDateTarget.Text = "Date";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 417);
			this.Controls.Add(this.lbDateTarget);
			this.Controls.Add(this.lbTableTarget);
			this.Controls.Add(this.txbDateTarget);
			this.Controls.Add(this.txbTableTarget);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btViewTable);
			this.Name = "MainForm";
			this.Text = "График температуры";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btViewTable;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txbTableTarget;
		private System.Windows.Forms.TextBox txbDateTarget;
		private System.Windows.Forms.Label lbTableTarget;
		private System.Windows.Forms.Label lbDateTarget;
	}
}

