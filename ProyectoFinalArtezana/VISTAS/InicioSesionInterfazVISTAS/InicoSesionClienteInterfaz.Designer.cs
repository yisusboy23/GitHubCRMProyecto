namespace VISTAS.InicioSesionInterfazVISTAS
{
    partial class InicoSesionClienteInterfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicoSesionClienteInterfaz));
            panel1 = new Panel();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(127, 212, 249);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(348, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(423, 337);
            panel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 11.249999F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(100, 296);
            label1.Name = "label1";
            label1.Size = new Size(184, 21);
            label1.TabIndex = 14;
            label1.Text = "CREAR NUEVA CUENTA";
            label1.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(25, 109);
            label4.Name = "label4";
            label4.Size = new Size(121, 23);
            label4.TabIndex = 13;
            label4.Text = "CONTRASEÑA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(25, 30);
            label3.Name = "label3";
            label3.Size = new Size(85, 23);
            label3.TabIndex = 8;
            label3.Text = "USUARIO";
            // 
            // button1
            // 
            button1.BackColor = Color.Azure;
            button1.DialogResult = DialogResult.OK;
            button1.Font = new Font("Sitka Text", 11.249999F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(82, 231);
            button1.Name = "button1";
            button1.Size = new Size(254, 34);
            button1.TabIndex = 12;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(25, 149);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(351, 23);
            textBox2.TabIndex = 11;
            textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 23);
            textBox1.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 114);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(287, 167);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // InicoSesionClienteInterfaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Name = "InicoSesionClienteInterfaz";
            Text = "InicoSesionClienteInterfaz";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox2;
    }
}