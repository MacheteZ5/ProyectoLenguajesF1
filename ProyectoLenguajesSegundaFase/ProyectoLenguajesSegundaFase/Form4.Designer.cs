namespace ProyectoLenguajesSegundaFase
{
    partial class Form4
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
            this.button2 = new System.Windows.Forms.Button();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.pantalla1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 35);
            this.button2.TabIndex = 20;
            this.button2.Text = "Validar Expresión";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(38, 36);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(226, 22);
            this.txtBox1.TabIndex = 21;
            // 
            // pantalla1
            // 
            this.pantalla1.FormattingEnabled = true;
            this.pantalla1.ItemHeight = 16;
            this.pantalla1.Location = new System.Drawing.Point(38, 157);
            this.pantalla1.Name = "pantalla1";
            this.pantalla1.Size = new System.Drawing.Size(226, 340);
            this.pantalla1.TabIndex = 22;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 529);
            this.Controls.Add(this.pantalla1);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.button2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.ListBox pantalla1;
    }
}