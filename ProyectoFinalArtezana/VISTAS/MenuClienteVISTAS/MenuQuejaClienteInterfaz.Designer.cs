namespace VISTAS.MenuClienteVISTAS
{
    partial class MenuQuejaClienteInterfaz
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
            label5 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 221, 236);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(622, 102);
            panel1.TabIndex = 150;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Text", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Menu;
            label5.Location = new Point(33, 20);
            label5.Name = "label5";
            label5.Size = new Size(341, 47);
            label5.TabIndex = 0;
            label5.Text = "REPORTE DE QUEJA";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 225);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(581, 23);
            textBox1.TabIndex = 151;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Producto", "Servicio", "Soporte", "Otro" });
            comboBox1.Location = new Point(30, 144);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(229, 23);
            comboBox1.TabIndex = 152;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(33, 118);
            label1.Name = "label1";
            label1.Size = new Size(141, 23);
            label1.TabIndex = 153;
            label1.Text = "TIPO DE QUEJA:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(30, 188);
            label2.Name = "label2";
            label2.Size = new Size(221, 23);
            label2.TabIndex = 154;
            label2.Text = "COMENTE SU PROBLEMA:";
            // 
            // button1
            // 
            button1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(220, 285);
            button1.Name = "button1";
            button1.Size = new Size(183, 66);
            button1.TabIndex = 155;
            button1.Text = "CONFIRMAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MenuQuejaClienteInterfaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(623, 375);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Name = "MenuQuejaClienteInterfaz";
            Text = "MenuQuejaClienteInterfaz";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}