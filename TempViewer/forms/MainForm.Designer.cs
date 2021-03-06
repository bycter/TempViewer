﻿namespace TempViewer
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
            this.txbTableTarget = new System.Windows.Forms.TextBox();
            this.txbDateTarget = new System.Windows.Forms.TextBox();
            this.lbTableTarget = new System.Windows.Forms.Label();
            this.lbDateTarget = new System.Windows.Forms.Label();
            this.txbStep = new System.Windows.Forms.TextBox();
            this.lbStep = new System.Windows.Forms.Label();
            this.lbOffset = new System.Windows.Forms.Label();
            this.txbOffset = new System.Windows.Forms.TextBox();
            this.btConnProperties = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПодключенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLog1 = new System.Windows.Forms.Label();
            this.btConn = new System.Windows.Forms.Button();
            this.lbLog2 = new System.Windows.Forms.Label();
            this.btTest = new System.Windows.Forms.Button();
            this.lbTest2 = new System.Windows.Forms.Label();
            this.lbTest1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btViewTable
            // 
            this.btViewTable.Location = new System.Drawing.Point(476, 369);
            this.btViewTable.Name = "btViewTable";
            this.btViewTable.Size = new System.Drawing.Size(134, 36);
            this.btViewTable.TabIndex = 1;
            this.btViewTable.Text = "Отобразить график";
            this.btViewTable.UseVisualStyleBackColor = true;
            this.btViewTable.Click += new System.EventHandler(this.btnViewTable_Click);
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
            // txbStep
            // 
            this.txbStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbStep.Location = new System.Drawing.Point(328, 376);
            this.txbStep.Name = "txbStep";
            this.txbStep.Size = new System.Drawing.Size(66, 22);
            this.txbStep.TabIndex = 9;
            // 
            // lbStep
            // 
            this.lbStep.AutoSize = true;
            this.lbStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStep.Location = new System.Drawing.Point(325, 357);
            this.lbStep.Name = "lbStep";
            this.lbStep.Size = new System.Drawing.Size(36, 16);
            this.lbStep.TabIndex = 10;
            this.lbStep.Text = "Step";
            // 
            // lbOffset
            // 
            this.lbOffset.AutoSize = true;
            this.lbOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOffset.Location = new System.Drawing.Point(397, 357);
            this.lbOffset.Name = "lbOffset";
            this.lbOffset.Size = new System.Drawing.Size(42, 16);
            this.lbOffset.TabIndex = 12;
            this.lbOffset.Text = "Offset";
            // 
            // txbOffset
            // 
            this.txbOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbOffset.Location = new System.Drawing.Point(400, 376);
            this.txbOffset.Name = "txbOffset";
            this.txbOffset.Size = new System.Drawing.Size(66, 22);
            this.txbOffset.TabIndex = 11;
            // 
            // btConnProperties
            // 
            this.btConnProperties.Location = new System.Drawing.Point(476, 322);
            this.btConnProperties.Name = "btConnProperties";
            this.btConnProperties.Size = new System.Drawing.Size(134, 41);
            this.btConnProperties.TabIndex = 13;
            this.btConnProperties.Text = "Настройки подключения";
            this.btConnProperties.UseVisualStyleBackColor = true;
            this.btConnProperties.Click += new System.EventHandler(this.btConnProperties_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(616, 369);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 36);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкаToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиПодключенияToolStripMenuItem});
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            // 
            // настройкиПодключенияToolStripMenuItem
            // 
            this.настройкиПодключенияToolStripMenuItem.Name = "настройкиПодключенияToolStripMenuItem";
            this.настройкиПодключенияToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.настройкиПодключенияToolStripMenuItem.Text = "Настройки подключения";
            this.настройкиПодключенияToolStripMenuItem.Click += new System.EventHandler(this.настройкиПодключенияToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.справкаToolStripMenuItem1});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // справкаToolStripMenuItem1
            // 
            this.справкаToolStripMenuItem1.Name = "справкаToolStripMenuItem1";
            this.справкаToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.справкаToolStripMenuItem1.Text = "Справка";
            // 
            // lbLog1
            // 
            this.lbLog1.AutoSize = true;
            this.lbLog1.Location = new System.Drawing.Point(12, 38);
            this.lbLog1.Name = "lbLog1";
            this.lbLog1.Size = new System.Drawing.Size(39, 13);
            this.lbLog1.TabIndex = 16;
            this.lbLog1.Text = "lbLog1";
            // 
            // btConn
            // 
            this.btConn.Location = new System.Drawing.Point(15, 106);
            this.btConn.Name = "btConn";
            this.btConn.Size = new System.Drawing.Size(75, 23);
            this.btConn.TabIndex = 17;
            this.btConn.Text = "conn";
            this.btConn.UseVisualStyleBackColor = true;
            this.btConn.Click += new System.EventHandler(this.btConn_Click);
            // 
            // lbLog2
            // 
            this.lbLog2.AutoSize = true;
            this.lbLog2.Location = new System.Drawing.Point(12, 67);
            this.lbLog2.Name = "lbLog2";
            this.lbLog2.Size = new System.Drawing.Size(39, 13);
            this.lbLog2.TabIndex = 18;
            this.lbLog2.Text = "lbLog2";
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(33, 212);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 19;
            this.btTest.Text = "Test Button";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // lbTest2
            // 
            this.lbTest2.AutoSize = true;
            this.lbTest2.Location = new System.Drawing.Point(30, 180);
            this.lbTest2.Name = "lbTest2";
            this.lbTest2.Size = new System.Drawing.Size(66, 13);
            this.lbTest2.TabIndex = 20;
            this.lbTest2.Text = "Label Test 2";
            // 
            // lbTest1
            // 
            this.lbTest1.AutoSize = true;
            this.lbTest1.Location = new System.Drawing.Point(30, 156);
            this.lbTest1.Name = "lbTest1";
            this.lbTest1.Size = new System.Drawing.Size(66, 13);
            this.lbTest1.TabIndex = 22;
            this.lbTest1.Text = "Label Test 1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 417);
            this.Controls.Add(this.lbTest1);
            this.Controls.Add(this.lbTest2);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.lbLog2);
            this.Controls.Add(this.btConn);
            this.Controls.Add(this.lbLog1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btConnProperties);
            this.Controls.Add(this.lbOffset);
            this.Controls.Add(this.txbOffset);
            this.Controls.Add(this.lbStep);
            this.Controls.Add(this.txbStep);
            this.Controls.Add(this.lbDateTarget);
            this.Controls.Add(this.lbTableTarget);
            this.Controls.Add(this.txbDateTarget);
            this.Controls.Add(this.txbTableTarget);
            this.Controls.Add(this.btViewTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "График температуры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btViewTable;
		private System.Windows.Forms.TextBox txbTableTarget;
		private System.Windows.Forms.TextBox txbDateTarget;
		private System.Windows.Forms.Label lbTableTarget;
		private System.Windows.Forms.Label lbDateTarget;
		private System.Windows.Forms.TextBox txbStep;
		private System.Windows.Forms.Label lbStep;
		private System.Windows.Forms.Label lbOffset;
		private System.Windows.Forms.TextBox txbOffset;
		private System.Windows.Forms.Button btConnProperties;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem настройкиПодключенияToolStripMenuItem;
        private System.Windows.Forms.Label lbLog1;
        private System.Windows.Forms.Button btConn;
		private System.Windows.Forms.Label lbLog2;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Label lbTest2;
        private System.Windows.Forms.Label lbTest1;
	}
}

