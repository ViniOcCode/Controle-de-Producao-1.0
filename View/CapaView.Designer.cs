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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDataComeco = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.chartProducao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOkCustom = new System.Windows.Forms.Button();
            this.btnCustomDate = new System.Windows.Forms.Button();
            this.btn30dias = new System.Windows.Forms.Button();
            this.btn7dias = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.chartTop = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumProducao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNumMat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumProduto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProducao = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDataComeco = new System.Windows.Forms.Label();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.btnBlocos = new System.Windows.Forms.Button();
            this.btnMourao = new System.Windows.Forms.Button();
            this.btnPiso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartProducao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDataComeco
            // 
            this.dtpDataComeco.CustomFormat = "yyyy-MM-dd";
            this.dtpDataComeco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataComeco.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataComeco.Location = new System.Drawing.Point(267, 71);
            this.dtpDataComeco.Name = "dtpDataComeco";
            this.dtpDataComeco.Size = new System.Drawing.Size(94, 23);
            this.dtpDataComeco.TabIndex = 0;
            this.dtpDataComeco.ValueChanged += new System.EventHandler(this.dtpDataComeco_ValueChanged);
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.CustomFormat = "yyyy-MM-dd";
            this.dtpDataFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFinal.Location = new System.Drawing.Point(385, 71);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(94, 23);
            this.dtpDataFinal.TabIndex = 0;
            this.dtpDataFinal.ValueChanged += new System.EventHandler(this.dtpDataFinal_ValueChanged);
            // 
            // chartProducao
            // 
            this.chartProducao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            chartArea3.AxisX.MajorGrid.LineWidth = 0;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            chartArea3.AxisX.MajorTickMark.Size = 3F;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            chartArea3.AxisY.LineWidth = 0;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            chartArea3.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisY.MajorTickMark.LineWidth = 0;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            chartArea3.Name = "ChartArea1";
            this.chartProducao.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.ForeColor = System.Drawing.Color.WhiteSmoke;
            legend3.IsTextAutoFit = false;
            legend3.Name = "Produção";
            this.chartProducao.Legends.Add(legend3);
            this.chartProducao.Location = new System.Drawing.Point(12, 110);
            this.chartProducao.MinimumSize = new System.Drawing.Size(714, 240);
            this.chartProducao.Name = "chartProducao";
            series3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            series3.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(88)))), ((int)(((byte)(127)))));
            series3.Legend = "Produção";
            series3.MarkerColor = System.Drawing.Color.MediumPurple;
            series3.MarkerSize = 10;
            series3.Name = "Produção";
            this.chartProducao.Series.Add(series3);
            this.chartProducao.Size = new System.Drawing.Size(714, 240);
            this.chartProducao.TabIndex = 2;
            this.chartProducao.Text = "chart1";
            title3.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.ForeColor = System.Drawing.Color.WhiteSmoke;
            title3.Name = "Gráfico Produção";
            title3.Text = "Gráfico Produção";
            this.chartProducao.Titles.Add(title3);
            // 
            // btnOkCustom
            // 
            this.btnOkCustom.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btnOkCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkCustom.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOkCustom.Location = new System.Drawing.Point(521, 71);
            this.btnOkCustom.Name = "btnOkCustom";
            this.btnOkCustom.Size = new System.Drawing.Size(35, 30);
            this.btnOkCustom.TabIndex = 3;
            this.btnOkCustom.Text = "OK";
            this.btnOkCustom.UseVisualStyleBackColor = true;
            this.btnOkCustom.Click += new System.EventHandler(this.btnOkCustom_Click);
            // 
            // btnCustomDate
            // 
            this.btnCustomDate.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btnCustomDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomDate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomDate.Location = new System.Drawing.Point(556, 71);
            this.btnCustomDate.Name = "btnCustomDate";
            this.btnCustomDate.Size = new System.Drawing.Size(120, 30);
            this.btnCustomDate.TabIndex = 3;
            this.btnCustomDate.Text = "Customizado";
            this.btnCustomDate.UseVisualStyleBackColor = true;
            this.btnCustomDate.Click += new System.EventHandler(this.btnCustomDate_Click);
            // 
            // btn30dias
            // 
            this.btn30dias.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btn30dias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn30dias.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn30dias.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn30dias.Location = new System.Drawing.Point(795, 71);
            this.btn30dias.Name = "btn30dias";
            this.btn30dias.Size = new System.Drawing.Size(120, 30);
            this.btn30dias.TabIndex = 3;
            this.btn30dias.Text = "Últimos 30 dias";
            this.btn30dias.UseVisualStyleBackColor = true;
            this.btn30dias.Click += new System.EventHandler(this.btn30dias_Click);
            // 
            // btn7dias
            // 
            this.btn7dias.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btn7dias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7dias.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7dias.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn7dias.Location = new System.Drawing.Point(676, 71);
            this.btn7dias.Name = "btn7dias";
            this.btn7dias.Size = new System.Drawing.Size(120, 30);
            this.btn7dias.TabIndex = 3;
            this.btn7dias.Text = "Últimos 7 dias";
            this.btn7dias.UseVisualStyleBackColor = true;
            this.btn7dias.Click += new System.EventHandler(this.btn7dias_Click);
            // 
            // btnMes
            // 
            this.btnMes.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMes.Location = new System.Drawing.Point(915, 71);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(120, 30);
            this.btnMes.TabIndex = 3;
            this.btnMes.Text = "Este Mês";
            this.btnMes.UseVisualStyleBackColor = true;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // chartTop
            // 
            this.chartTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            chartArea4.Name = "ChartArea1";
            this.chartTop.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend4.ForeColor = System.Drawing.Color.White;
            legend4.Name = "Produção";
            this.chartTop.Legends.Add(legend4);
            this.chartTop.Location = new System.Drawing.Point(732, 110);
            this.chartTop.MinimumSize = new System.Drawing.Size(313, 435);
            this.chartTop.Name = "chartTop";
            series4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            series4.BackSecondaryColor = System.Drawing.Color.MidnightBlue;
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            series4.BorderWidth = 5;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series4.IsValueShownAsLabel = true;
            series4.LabelForeColor = System.Drawing.Color.White;
            series4.Legend = "Produção";
            series4.Name = "Series1";
            series4.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartTop.Series.Add(series4);
            this.chartTop.Size = new System.Drawing.Size(313, 435);
            this.chartTop.TabIndex = 2;
            this.chartTop.Text = "chart1";
            title4.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.ForeColor = System.Drawing.Color.WhiteSmoke;
            title4.Name = "Top Produtos";
            title4.Text = "Top Produtos";
            this.chartTop.Titles.Add(title4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.lblNumProducao);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblNumMat);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblNumProduto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 355);
            this.panel1.MinimumSize = new System.Drawing.Size(200, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 190);
            this.panel1.TabIndex = 4;
            // 
            // lblNumProducao
            // 
            this.lblNumProducao.AutoSize = true;
            this.lblNumProducao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumProducao.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNumProducao.Location = new System.Drawing.Point(4, 146);
            this.lblNumProducao.Name = "lblNumProducao";
            this.lblNumProducao.Size = new System.Drawing.Size(72, 21);
            this.lblNumProducao.TabIndex = 0;
            this.lblNumProducao.Text = "4bilhoes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(3, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Número de Produção";
            // 
            // lblNumMat
            // 
            this.lblNumMat.AutoSize = true;
            this.lblNumMat.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumMat.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNumMat.Location = new System.Drawing.Point(5, 98);
            this.lblNumMat.Name = "lblNumMat";
            this.lblNumMat.Size = new System.Drawing.Size(72, 21);
            this.lblNumMat.TabIndex = 0;
            this.lblNumMat.Text = "3bilhoes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Número de Mat. Primas";
            // 
            // lblNumProduto
            // 
            this.lblNumProduto.AutoSize = true;
            this.lblNumProduto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumProduto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNumProduto.Location = new System.Drawing.Point(4, 51);
            this.lblNumProduto.Name = "lblNumProduto";
            this.lblNumProduto.Size = new System.Drawing.Size(72, 21);
            this.lblNumProduto.TabIndex = 0;
            this.lblNumProduto.Text = "2bilhoes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número de Produtos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            this.panel2.Controls.Add(this.lblProducao);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 45);
            this.panel2.TabIndex = 4;
            // 
            // lblProducao
            // 
            this.lblProducao.AutoSize = true;
            this.lblProducao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducao.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblProducao.Location = new System.Drawing.Point(40, 19);
            this.lblProducao.Name = "lblProducao";
            this.lblProducao.Size = new System.Drawing.Size(72, 21);
            this.lblProducao.TabIndex = 0;
            this.lblProducao.Text = "4bilhoes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(33, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Produção";
            // 
            // dgvEstoque
            // 
            this.dgvEstoque.AllowUserToAddRows = false;
            this.dgvEstoque.AllowUserToDeleteRows = false;
            this.dgvEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEstoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstoque.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(42)))));
            this.dgvEstoque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEstoque.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEstoque.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(144)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEstoque.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEstoque.EnableHeadersVisualStyles = false;
            this.dgvEstoque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(144)))), ((int)(((byte)(173)))));
            this.dgvEstoque.Location = new System.Drawing.Point(3, 23);
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.ReadOnly = true;
            this.dgvEstoque.RowHeadersVisible = false;
            this.dgvEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstoque.Size = new System.Drawing.Size(502, 163);
            this.dgvEstoque.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            this.panel3.Controls.Add(this.dgvEstoque);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(218, 355);
            this.panel3.MinimumSize = new System.Drawing.Size(508, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 190);
            this.panel3.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(12, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Estoque Baixo";
            // 
            // lblDataComeco
            // 
            this.lblDataComeco.AutoSize = true;
            this.lblDataComeco.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataComeco.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDataComeco.Location = new System.Drawing.Point(268, 72);
            this.lblDataComeco.Name = "lblDataComeco";
            this.lblDataComeco.Size = new System.Drawing.Size(92, 21);
            this.lblDataComeco.TabIndex = 0;
            this.lblDataComeco.Text = "2024-10-24";
            this.lblDataComeco.Click += new System.EventHandler(this.lblDataComeco_Click);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFinal.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDataFinal.Location = new System.Drawing.Point(386, 72);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(92, 21);
            this.lblDataFinal.TabIndex = 0;
            this.lblDataFinal.Text = "2024-10-25";
            this.lblDataFinal.Click += new System.EventHandler(this.lblDataFinal_Click);
            // 
            // btnBlocos
            // 
            this.btnBlocos.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btnBlocos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlocos.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlocos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBlocos.Location = new System.Drawing.Point(12, 12);
            this.btnBlocos.Name = "btnBlocos";
            this.btnBlocos.Size = new System.Drawing.Size(120, 30);
            this.btnBlocos.TabIndex = 3;
            this.btnBlocos.Text = "Blocos";
            this.btnBlocos.UseVisualStyleBackColor = true;
            this.btnBlocos.Click += new System.EventHandler(this.btnBloco_Click);
            // 
            // btnMourao
            // 
            this.btnMourao.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btnMourao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMourao.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMourao.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMourao.Location = new System.Drawing.Point(132, 12);
            this.btnMourao.Name = "btnMourao";
            this.btnMourao.Size = new System.Drawing.Size(120, 30);
            this.btnMourao.TabIndex = 3;
            this.btnMourao.Text = "Mourão";
            this.btnMourao.UseVisualStyleBackColor = true;
            this.btnMourao.Click += new System.EventHandler(this.btnMourao_Click);
            // 
            // btnPiso
            // 
            this.btnPiso.FlatAppearance.BorderColor = System.Drawing.Color.Orchid;
            this.btnPiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPiso.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPiso.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPiso.Location = new System.Drawing.Point(251, 12);
            this.btnPiso.Name = "btnPiso";
            this.btnPiso.Size = new System.Drawing.Size(120, 30);
            this.btnPiso.TabIndex = 3;
            this.btnPiso.Text = "Piso";
            this.btnPiso.UseVisualStyleBackColor = true;
            this.btnPiso.Click += new System.EventHandler(this.btnPiso_Click);
            // 
            // CapaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1052, 648);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.lblDataComeco);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMes);
            this.Controls.Add(this.btn30dias);
            this.Controls.Add(this.btn7dias);
            this.Controls.Add(this.btnPiso);
            this.Controls.Add(this.btnMourao);
            this.Controls.Add(this.btnBlocos);
            this.Controls.Add(this.btnCustomDate);
            this.Controls.Add(this.btnOkCustom);
            this.Controls.Add(this.chartTop);
            this.Controls.Add(this.chartProducao);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.dtpDataComeco);
            this.MinimumSize = new System.Drawing.Size(1068, 541);
            this.Name = "CapaView";
            this.Text = "CapaView";
            this.Load += new System.EventHandler(this.CapaView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartProducao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDataComeco;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProducao;
        private System.Windows.Forms.Button btnOkCustom;
        private System.Windows.Forms.Button btnCustomDate;
        private System.Windows.Forms.Button btn30dias;
        private System.Windows.Forms.Button btn7dias;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumProducao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumMat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblProducao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDataComeco;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Button btnBlocos;
        private System.Windows.Forms.Button btnMourao;
        private System.Windows.Forms.Button btnPiso;
    }
}