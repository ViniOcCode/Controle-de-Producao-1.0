namespace ControleProdForms.View
{
    partial class Form1
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
            this.txtConversaoEntrada = new System.Windows.Forms.TextBox();
            this.cbUnidadeEntrada = new System.Windows.Forms.ComboBox();
            this.btnConverter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConversaoSaida = new System.Windows.Forms.TextBox();
            this.cbUnidadeSaida = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtConversaoEntrada
            // 
            this.txtConversaoEntrada.Location = new System.Drawing.Point(44, 104);
            this.txtConversaoEntrada.Name = "txtConversaoEntrada";
            this.txtConversaoEntrada.Size = new System.Drawing.Size(100, 20);
            this.txtConversaoEntrada.TabIndex = 0;
            // 
            // cbUnidadeEntrada
            // 
            this.cbUnidadeEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidadeEntrada.FormattingEnabled = true;
            this.cbUnidadeEntrada.Location = new System.Drawing.Point(44, 77);
            this.cbUnidadeEntrada.Name = "cbUnidadeEntrada";
            this.cbUnidadeEntrada.Size = new System.Drawing.Size(121, 21);
            this.cbUnidadeEntrada.TabIndex = 1;
            // 
            // btnConverter
            // 
            this.btnConverter.Location = new System.Drawing.Point(44, 187);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(75, 23);
            this.btnConverter.TabIndex = 3;
            this.btnConverter.Text = "Coverter";
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(41, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Conversão";
            // 
            // txtConversaoSaida
            // 
            this.txtConversaoSaida.Location = new System.Drawing.Point(44, 161);
            this.txtConversaoSaida.Name = "txtConversaoSaida";
            this.txtConversaoSaida.Size = new System.Drawing.Size(100, 20);
            this.txtConversaoSaida.TabIndex = 0;
            // 
            // cbUnidadeSaida
            // 
            this.cbUnidadeSaida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidadeSaida.FormattingEnabled = true;
            this.cbUnidadeSaida.Location = new System.Drawing.Point(44, 134);
            this.cbUnidadeSaida.Name = "cbUnidadeSaida";
            this.cbUnidadeSaida.Size = new System.Drawing.Size(121, 21);
            this.cbUnidadeSaida.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 423);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUnidadeSaida);
            this.Controls.Add(this.cbUnidadeEntrada);
            this.Controls.Add(this.txtConversaoSaida);
            this.Controls.Add(this.txtConversaoEntrada);
            this.Name = "Form1";
            this.Text = "ConversaoView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConversaoEntrada;
        private System.Windows.Forms.ComboBox cbUnidadeEntrada;
        private System.Windows.Forms.Button btnConverter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConversaoSaida;
        private System.Windows.Forms.ComboBox cbUnidadeSaida;
    }
}