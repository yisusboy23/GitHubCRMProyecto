namespace VISTAS.AuditoriaClieVISTAS
{
    partial class PersonaInterfaz
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonaInterfaz));
            panel1 = new Panel();
            label2 = new Label();
            textBox5 = new TextBox();
            label10 = new Label();
            textBox3 = new TextBox();
            label8 = new Label();
            textBox2 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            textBox4 = new TextBox();
            label9 = new Label();
            label11 = new Label();
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            button5 = new Button();
            button6 = new Button();
            textBox6 = new TextBox();
            button7 = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 221, 236);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(920, 102);
            panel1.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Menu;
            label2.Location = new Point(30, 29);
            label2.Name = "label2";
            label2.Size = new Size(174, 47);
            label2.TabIndex = 0;
            label2.Text = "PERSONA";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(619, 235);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(221, 23);
            textBox5.TabIndex = 59;
            textBox5.Validating += textBox5_Validating;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(513, 235);
            label10.Name = "label10";
            label10.Size = new Size(77, 23);
            label10.TabIndex = 58;
            label10.Text = "CORREO";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(619, 199);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(221, 23);
            textBox3.TabIndex = 55;
            textBox3.KeyPress += textBox3_KeyPress;
            textBox3.Validating += textBox3_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(513, 199);
            label8.Name = "label8";
            label8.Size = new Size(99, 23);
            label8.TabIndex = 54;
            label8.Text = "TELEFONO";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(619, 163);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(221, 23);
            textBox2.TabIndex = 53;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(513, 163);
            label7.Name = "label7";
            label7.Size = new Size(93, 23);
            label7.TabIndex = 52;
            label7.Text = "APELLIDO";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(251, 38);
            label6.Name = "label6";
            label6.Size = new Size(94, 23);
            label6.TabIndex = 51;
            label6.Text = "ELIMINAR";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(119, 38);
            label5.Name = "label5";
            label5.Size = new Size(114, 23);
            label5.TabIndex = 50;
            label5.Text = "ACTUALIZAR";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(351, 38);
            label4.Name = "label4";
            label4.Size = new Size(81, 23);
            label4.TabIndex = 49;
            label4.Text = "LIMPIAR";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(20, 38);
            label3.Name = "label3";
            label3.Size = new Size(93, 23);
            label3.TabIndex = 48;
            label3.Text = "INSERTAR";
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Location = new Point(37, 69);
            button3.Name = "button3";
            button3.Size = new Size(45, 45);
            button3.TabIndex = 47;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.DialogResult = DialogResult.OK;
            button4.Location = new Point(269, 69);
            button4.Name = "button4";
            button4.Size = new Size(45, 45);
            button4.TabIndex = 46;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.DialogResult = DialogResult.OK;
            button2.Location = new Point(361, 64);
            button2.Name = "button2";
            button2.Size = new Size(45, 45);
            button2.TabIndex = 45;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(152, 69);
            button1.Name = "button1";
            button1.Size = new Size(45, 45);
            button1.TabIndex = 44;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(619, 123);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 23);
            textBox1.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(513, 123);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 42;
            label1.Text = "NOMBRE";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(0, 86, 157);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(437, 338);
            dataGridView1.TabIndex = 41;
            dataGridView1.Click += dataGridView1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Masculino ", "Femenino" });
            comboBox1.Location = new Point(619, 264);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 23);
            comboBox1.TabIndex = 174;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(619, 293);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(221, 23);
            textBox4.TabIndex = 175;
            textBox4.Validating += textBox4_Validating;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(513, 264);
            label9.Name = "label9";
            label9.Size = new Size(54, 23);
            label9.TabIndex = 176;
            label9.Text = "SEXO";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(513, 293);
            label11.Name = "label11";
            label11.Size = new Size(56, 23);
            label11.TabIndex = 177;
            label11.Text = "EDAD";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(127, 212, 249);
            button5.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.Location = new Point(12, 475);
            button5.Name = "button5";
            button5.Size = new Size(437, 34);
            button5.TabIndex = 182;
            button5.Text = "VER DETALLES";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.Location = new Point(391, 103);
            button6.Name = "button6";
            button6.Size = new Size(25, 23);
            button6.TabIndex = 194;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(12, 103);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(380, 23);
            textBox6.TabIndex = 193;
            // 
            // button7
            // 
            button7.BackgroundImage = (Image)resources.GetObject("button7.BackgroundImage");
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.Location = new Point(422, 102);
            button7.Name = "button7";
            button7.Size = new Size(27, 23);
            button7.TabIndex = 192;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(128, 221, 236);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(467, 355);
            panel2.Name = "panel2";
            panel2.Size = new Size(435, 154);
            panel2.TabIndex = 195;
            // 
            // PersonaInterfaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(914, 558);
            Controls.Add(panel2);
            Controls.Add(button6);
            Controls.Add(textBox6);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(textBox4);
            Controls.Add(comboBox1);
            Controls.Add(textBox5);
            Controls.Add(label10);
            Controls.Add(textBox3);
            Controls.Add(label8);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PersonaInterfaz";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private TextBox textBox5;
        private Label label10;
        private TextBox textBox3;
        private Label label8;
        private TextBox textBox2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button3;
        private Button button4;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private TextBox textBox4;
        private Label label9;
        private Label label11;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private Button button5;
        private Button button6;
        private TextBox textBox6;
        private Button button7;
        private Panel panel2;
    }
}