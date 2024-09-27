namespace VISTAS.AuditoriaVISTAS
{
    partial class FiltroAuditoriaInterfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroAuditoriaInterfaz));
            panel1 = new Panel();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button5 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 100);
            panel1.TabIndex = 157;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Menu;
            label2.Location = new Point(33, 20);
            label2.Name = "label2";
            label2.Size = new Size(405, 47);
            label2.TabIndex = 0;
            label2.Text = "FILTRO DE AUDITORIAS";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(33, 217);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 158;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(266, 217);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(196, 23);
            dateTimePicker2.TabIndex = 159;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(35, 136);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 160;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(35, 278);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 161;
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 353);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(370, 23);
            textBox1.TabIndex = 162;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "creado", "actualizado", "eliminado", "inició sesión", "cerro sesión" });
            comboBox1.Location = new Point(33, 440);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(427, 23);
            comboBox1.TabIndex = 163;
            // 
            // button1
            // 
            button1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(182, 494);
            button1.Name = "button1";
            button1.Size = new Size(124, 39);
            button1.TabIndex = 164;
            button1.Text = "BUSCAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(486, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(416, 409);
            dataGridView1.TabIndex = 165;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(69, 129);
            label1.Name = "label1";
            label1.Size = new Size(174, 23);
            label1.TabIndex = 166;
            label1.Text = "FILTRAR SIN FECHA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(35, 180);
            label3.Name = "label3";
            label3.Size = new Size(123, 23);
            label3.TabIndex = 167;
            label3.Text = "FECHA INCIO ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(266, 180);
            label4.Name = "label4";
            label4.Size = new Size(99, 23);
            label4.TabIndex = 168;
            label4.Text = "FECHA FIN";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(60, 271);
            label5.Name = "label5";
            label5.Size = new Size(207, 23);
            label5.TabIndex = 169;
            label5.Text = "FILTRADO SIN USUARIO";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(33, 314);
            label6.Name = "label6";
            label6.Size = new Size(234, 23);
            label6.TabIndex = 170;
            label6.Text = "SELECCIONAR UN USUARIO";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(33, 395);
            label7.Name = "label7";
            label7.Size = new Size(171, 23);
            label7.TabIndex = 171;
            label7.Text = "ACCION REALIZADA";
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(412, 345);
            button5.Name = "button5";
            button5.Size = new Size(50, 36);
            button5.TabIndex = 172;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // FiltroAuditoriaInterfaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 558);
            Controls.Add(button5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FiltroAuditoriaInterfaz";
            Text = "FiltroAuditoriaInterfaz";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button5;
    }
}