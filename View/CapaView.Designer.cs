namespace ControleProdForms.View
{
    partial class CapaView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpDataComeco = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOkCustom = new System.Windows.Forms.Button();
            this.btnCustomDate = new System.Windows.Forms.Button();
            this.btn30dias = new System.Windows.Forms.Button();
            this.btn7dias = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDataComeco
            // 
            this.dtpDataComeco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataComeco.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataComeco.Location = new System.Drawing.Point(116, 27);
            this.dtpDataComeco.Name = "dtpDataComeco";
            this.dtpDataComeco.Size = new System.Drawing.Size(80, 23);
            this.dtpDataComeco.TabIndex = 0;
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(202, 27);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(80, 23);
            this.dtpDataFinal.TabIndex = 0;
            // 
            // dgvEstoque
            // 
            this.dgvEstoque.AllowUserToAddRows = false;
            this.dgvEstoque.AllowUserToDeleteRows = false;
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstoque.Location = new System.Drawing.Point(116, 288);
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.ReadOnly = true;
            this.dgvEstoque.Size = new System.Drawing.Size(240, 150);
            this.dgvEstoque.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(46, 56);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(487, 226);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // btnOkCustom
            // 
            this.btnOkCustom.Location = new System.Drawing.Point(718, 118);
            this.btnOkCustom.Name = "btnOkCustom";
            this.btnOkCustom.Size = new System.Drawing.Size(31, 30);
            this.btnOkCustom.TabIndex = 3;
            this.btnOkCustom.Text = "OK";
            this.btnOkCustom.UseVisualStyleBackColor = true;
            // 
            // btnCustomDate
            // 
            this.btnCustomDate.Location = new System.Drawing.Point(592, 118);
            this.btnCustomDate.Name = "btnCustomDate";
            this.btnCustomDate.Size = new System.Drawing.Size(120, 30);
            this.btnCustomDate.TabIndex = 3;
            this.btnCustomDate.Text = "Customizado";
            this.btnCustomDate.UseVisualStyleBackColor = true;
            // 
            // btn30dias
            // 
            this.btn30dias.Location = new System.Drawing.Point(592, 46);
            this.btn30dias.Name = "btn30dias";
            this.btn30dias.Size = new System.Drawing.Size(120, 30);
            this.btn30dias.TabIndex = 3;
            this.btn30dias.Text = "Últimos 30 dias";
            this.btn30dias.UseVisualStyleBackColor = true;
            // 
            // btn7dias
            // 
            this.btn7dias.Location = new System.Drawing.Point(592, 82);
            this.btn7dias.Name = "btn7dias";
            this.btn7dias.Size = new System.Drawing.Size(120, 30);
            this.btn7dias.TabIndex = 3;
            this.btn7dias.Text = "Últimos 7 dias";
            this.btn7dias.UseVisualStyleBackColor = true;
            // 
            // btnMes
            // 
            this.btnMes.Location = new System.Drawing.Point(592, 12);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(120, 30);
            this.btnMes.TabIndex = 3;
            this.btnMes.Text = "Este Mês";
            this.btnMes.UseVisualStyleBackColor = true;
            // 
            // CapaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMes);
            this.Controls.Add(this.btn30dias);
            this.Controls.Add(this.btn7dias);
            this.Controls.Add(this.btnCustomDate);
            this.Controls.Add(this.btnOkCustom);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dgvEstoque);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.dtpDataComeco);
            this.Name = "CapaView";
            this.Text = "CapaView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDataComeco;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnOkCustom;
        private System.Windows.Forms.Button btnCustomDate;
        private System.Windows.Forms.Button btn30dias;
        private System.Windows.Forms.Button btn7dias;
        private System.Windows.Forms.Button btnMes;
    }
}