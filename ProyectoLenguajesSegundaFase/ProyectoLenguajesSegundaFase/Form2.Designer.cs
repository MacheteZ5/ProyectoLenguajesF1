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
            ((System.ComponentModel.ISupportInitialize)(this.FLN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Follow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estado)).BeginInit();
            this.SuspendLayout();
            // 
            // pantalla1
            // 
            this.pantalla1.FormattingEnabled = true;
            this.pantalla1.ItemHeight = 16;
            this.pantalla1.Location = new System.Drawing.Point(12, 34);
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
            this.FLN1.Location = new System.Drawing.Point(404, 34);
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
            this.label1.Location = new System.Drawing.Point(497, 9);
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
            this.Follow.Location = new System.Drawing.Point(1276, 34);
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
            this.label2.Location = new System.Drawing.Point(1273, 9);
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1779, 1000);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Follow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FLN1);
            this.Controls.Add(this.pantalla1);
            this.Name = "Form2";
            this.Text = "Form2";
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
    }
}