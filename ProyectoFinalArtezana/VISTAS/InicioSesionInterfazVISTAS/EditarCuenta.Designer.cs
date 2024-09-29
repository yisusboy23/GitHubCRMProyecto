namespace VISTAS.InicioSesionInterfazVISTAS
{
    partial class EditarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarCuenta));
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(111, 51);
            label1.Name = "label1";
            label1.Size = new Size(323, 30);
            label1.TabIndex = 4;
            label1.Text = "RESTABLECER CONTRASEÑA:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(111, 150);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 23);
            textBox1.TabIndex = 7;
            textBox1.Validating += textBox1_Validating;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(111, 255);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(284, 23);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(111, 100);
            label2.Name = "label2";
            label2.Size = new Size(244, 30);
            label2.TabIndex = 9;
            label2.Text = "NUEVA CONTRASEÑA:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(111, 200);
            label3.Name = "label3";
            label3.Size = new Size(301, 30);
            label3.TabIndex = 10;
            label3.Text = "CONFIRMAR CONTRASEÑA:";
            // 
            // button1
            // 
            button1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(164, 315);
            button1.Name = "button1";
            button1.Size = new Size(183, 66);
            button1.TabIndex = 11;
            button1.Text = "CONFIRMAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(111, 16);
            label4.Name = "label4";
            label4.Size = new Size(110, 35);
            label4.TabIndex = 6;
            label4.Text = "ECOLAB";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 221, 236);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 102);
            panel1.TabIndex = 149;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Text", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Menu;
            label5.Location = new Point(33, 20);
            label5.Name = "label5";
            label5.Size = new Size(507, 47);
            label5.TabIndex = 0;
            label5.Text = "REESTABLECER CONTRASEÑA";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(127, 212, 249);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(367, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 396);
            panel2.TabIndex = 150;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(34, 225);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(287, 167);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 151;
            pictureBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // EditarCuenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(914, 558);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditarCuenta";
            Text = "EditarCuenta";
            Load += EditarCuenta_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private Panel panel2;
        private PictureBox pictureBox2;
        private ErrorProvider errorProvider1;
    }
}