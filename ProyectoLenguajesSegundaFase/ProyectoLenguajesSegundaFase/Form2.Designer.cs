namespace ProyectoLenguajesSegundaFase
{
    partial class Form2
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
            this.pantalla1 = new System.Windows.Forms.ListBox();
            this.FLN1 = new System.Windows.Forms.DataGridView();
            this.Símbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nullable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.Follow = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.estado = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Expr = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FLN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Follow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estado)).BeginInit();
            this.SuspendLayout();
            // 
            // pantalla1
            // 
            this.pantalla1.FormattingEnabled = true;
            this.pantalla1.ItemHeight = 16;
            this.pantalla1.Location = new System.Drawing.Point(12, 58);
            this.pantalla1.Name = "pantalla1";
            this.pantalla1.Size = new System.Drawing.Size(386, 516);
            this.pantalla1.TabIndex = 0;
            // 
            // FLN1
            // 
            this.FLN1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FLN1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Símbolo,
            this.First,
            this.Last,
            this.Nullable});
            this.FLN1.Location = new System.Drawing.Point(404, 58);
            this.FLN1.Name = "FLN1";
            this.FLN1.RowHeadersWidth = 51;
            this.FLN1.Size = new System.Drawing.Size(851, 516);
            this.FLN1.TabIndex = 1;
            // 
            // Símbolo
            // 
            this.Símbolo.HeaderText = "Símbolo";
            this.Símbolo.MinimumWidth = 6;
            this.Símbolo.Name = "Símbolo";
            this.Símbolo.Width = 125;
            // 
            // First
            // 
            this.First.HeaderText = "First";
            this.First.MinimumWidth = 6;
            this.First.Name = "First";
            this.First.Width = 125;
            // 
            // Last
            // 
            this.Last.HeaderText = "Last";
            this.Last.MinimumWidth = 6;
            this.Last.Name = "Last";
            this.Last.Width = 125;
            // 
            // Nullable
            // 
            this.Nullable.HeaderText = "Nullable";
            this.Nullable.MinimumWidth = 6;
            this.Nullable.Name = "Nullable";
            this.Nullable.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tabla First - Last - Nullable";
            // 
            // Follow
            // 
            this.Follow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Follow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.Follow.Location = new System.Drawing.Point(1276, 58);
            this.Follow.Name = "Follow";
            this.Follow.RowHeadersWidth = 51;
            this.Follow.RowTemplate.Height = 24;
            this.Follow.Size = new System.Drawing.Size(491, 516);
            this.Follow.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Símbolo";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Follow";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1273, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tabla Follow";
            // 
            // estado
            // 
            this.estado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estado.Location = new System.Drawing.Point(12, 580);
            this.estado.Name = "estado";
            this.estado.RowHeadersWidth = 51;
            this.estado.RowTemplate.Height = 24;
            this.estado.Size = new System.Drawing.Size(1755, 411);
            this.estado.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1790, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "CrearArbol";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Expr
            // 
            this.Expr.AutoSize = true;
            this.Expr.Location = new System.Drawing.Point(12, 9);
            this.Expr.Name = "Expr";
            this.Expr.Size = new System.Drawing.Size(0, 17);
            this.Expr.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1773, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 68);
            this.button2.TabIndex = 8;
            this.button2.Text = "Retornar A Seleccionar Archivo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1773, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 72);
            this.button3.TabIndex = 20;
            this.button3.Text = "Ir A AFN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1773, 306);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 72);
            this.button4.TabIndex = 21;
            this.button4.Text = "Generar Scanner";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1019);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Expr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Follow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FLN1);
            this.Controls.Add(this.pantalla1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FLN1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Follow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox pantalla1;
        private System.Windows.Forms.DataGridView FLN1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Follow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Símbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn First;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView estado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Expr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}