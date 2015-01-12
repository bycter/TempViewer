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
			this.btConnectDB = new System.Windows.Forms.Button();
			this.btViewTable = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// btConnectDB
			// 
			this.btConnectDB.Location = new System.Drawing.Point(12, 293);
			this.btConnectDB.Name = "btConnectDB";
			this.btConnectDB.Size = new System.Drawing.Size(113, 36);
			this.btConnectDB.TabIndex = 0;
			this.btConnectDB.Text = "Подключение к БД";
			this.btConnectDB.UseVisualStyleBackColor = true;
			this.btConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
			// 
			// btViewTable
			// 
			this.btViewTable.Location = new System.Drawing.Point(364, 293);
			this.btViewTable.Name = "btViewTable";
			this.btViewTable.Size = new System.Drawing.Size(134, 36);
			this.btViewTable.TabIndex = 1;
			this.btViewTable.Text = "Отобразить таблицу";
			this.btViewTable.UseVisualStyleBackColor = true;
			this.btViewTable.Click += new System.EventHandler(this.btnViewTable_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 256);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(10, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = ".";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 277);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = ".";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(486, 241);
			this.dataGridView1.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 341);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btViewTable);
			this.Controls.Add(this.btConnectDB);
			this.Name = "MainForm";
			this.Text = "График температуры";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btConnectDB;
		private System.Windows.Forms.Button btViewTable;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}

