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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(328, 168);
            label1.Name = "label1";
            label1.Size = new Size(323, 30);
            label1.TabIndex = 4;
            label1.Text = "RESTABLECER CONTRASEÑA:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(328, 267);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 23);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(328, 372);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(284, 23);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(328, 216);
            label2.Name = "label2";
            label2.Size = new Size(244, 30);
            label2.TabIndex = 9;
            label2.Text = "NUEVA CONTRASEÑA:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(328, 317);
            label3.Name = "label3";
            label3.Size = new Size(301, 30);
            label3.TabIndex = 10;
            label3.Text = "CONFIRMAR CONTRASEÑA:";
            // 
            // button1
            // 
            button1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(381, 432);
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
            label4.Location = new Point(328, 69);
            label4.Name = "label4";
            label4.Size = new Size(110, 35);
            label4.TabIndex = 6;
            label4.Text = "ECOLAB";
            // 
            // EditarCuenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 558);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditarCuenta";
            Text = "EditarCuenta";
            Load += EditarCuenta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
    }
}