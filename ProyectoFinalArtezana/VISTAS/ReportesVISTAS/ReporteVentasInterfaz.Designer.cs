﻿namespace VISTAS.ReportesVISTAS
{
    partial class ReporteVentasInterfaz
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
            panel1 = new Panel();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            checkBox1 = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 221, 236);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 102);
            panel1.TabIndex = 149;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Menu;
            label2.Location = new Point(33, 20);
            label2.Name = "label2";
            label2.Size = new Size(435, 47);
            label2.TabIndex = 0;
            label2.Text = "REPORTE DE PRODUCTOS";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(0, 86, 157);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 217);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(890, 329);
            dataGridView1.TabIndex = 150;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(373, 138);
            label4.Name = "label4";
            label4.Size = new Size(99, 23);
            label4.TabIndex = 196;
            label4.Text = "FECHA FIN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 138);
            label3.Name = "label3";
            label3.Size = new Size(123, 23);
            label3.TabIndex = 195;
            label3.Text = "FECHA INCIO ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(33, 110);
            label1.Name = "label1";
            label1.Size = new Size(174, 23);
            label1.TabIndex = 194;
            label1.Text = "FILTRAR SIN FECHA";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 117);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 193;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 164);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(274, 23);
            dateTimePicker1.TabIndex = 191;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(373, 164);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(285, 23);
            dateTimePicker2.TabIndex = 192;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(127, 212, 249);
            button1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(778, 154);
            button1.Name = "button1";
            button1.Size = new Size(124, 39);
            button1.TabIndex = 197;
            button1.Text = "BUSCAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ReporteVentasInterfaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(914, 558);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReporteVentasInterfaz";
            Text = "ReporteVentasInterfaz";
            Load += ReporteVentasInterfaz_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label3;
        private Label label1;
        private CheckBox checkBox1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button button1;
    }
}