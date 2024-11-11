using ControleProdForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms.View
{
    public partial class CapaView : Form
    {
        private static CapaView instance;
        private string connectionString;
        private Button currentButton;
        private string nomeAtual;
        private bool IgnoraLoadData = false;

        // Método estático para garantir instância única da CapaView
        public static CapaView Instancia(Form parentContainer, string connectionString)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CapaView(connectionString);
                instance.MdiParent = parentContainer;  // Define o contêiner pai como MDI
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        public CapaView(string connectionString)
        {
            InitializeComponent();
            dtpDataComeco.Value = DateTime.Today.AddDays(-7);
            dtpDataFinal.Value = DateTime.Today.AddDays(+1);
            BotaoMenu(btn7dias);
            btn7dias.Select();
            // Obtendo a connection string do Repobase.cs
            this.connectionString = connectionString;
            nomeAtual = "1";
            LoadData(nomeAtual);
        }

        private void LoadData(string nome)
        {

            if (IgnoraLoadData) return;

            CapaModel model = new CapaModel(connectionString);
            var refreshData = model.LoadData(dtpDataComeco.Value, dtpDataFinal.Value, nome);
            if (refreshData == true)
            {

                lblProducao.Text = model.TotalProducao.ToString();
                lblNumProduto.Text = model.NumProdutos.ToString();
                lblNumMat.Text = model.NumMat.ToString();
                lblNumProducao.Text = model.NumProducao.ToString();

                //Top Produtos
                chartTop.DataSource = model.TopProdutos;
                chartTop.Series[0].XValueMember = "Key";
                chartTop.Series[0].YValueMembers = "Value";
                chartTop.DataBind();

                //Grafico de produção
                chartProducao.DataSource = model.ProducaoLista;
                chartProducao.Series[0].XValueMember = "Data";
                chartProducao.Series[0].YValueMembers = "Total";
                chartProducao.DataBind();

                //Baixo Estoque
                dgvEstoque.DataSource = model.UnderstockList;
                dgvEstoque.Columns[0].HeaderText = "Item";
                dgvEstoque.Columns[1].HeaderText = "Unidades";
                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded, same query");
        }

        private void btnBloco_Click(object sender, EventArgs e)
        {
            nomeAtual = "1";
            LoadData(nomeAtual);
            CarregaAnaliseMp(nomeAtual);
        }

        private void btnMourao_Click(object sender, EventArgs e)
        {
            nomeAtual = "2";
            LoadData(nomeAtual);
            CarregaAnaliseMp(nomeAtual);
        }

        private void btnPiso_Click(object sender, EventArgs e)
        {
            nomeAtual = "3";
            LoadData(nomeAtual);
            CarregaAnaliseMp(nomeAtual);
        }

        private void BotaoMenu(object button)
        {
            var btn = (Button)button;

            btn.BackColor = btn30dias.FlatAppearance.BorderColor;
            btn.ForeColor = Color.White;

            if (currentButton != null && currentButton != btn)
            {
                currentButton.BackColor = this.BackColor;
                currentButton.ForeColor = Color.WhiteSmoke;
            }
            currentButton = btn;

            if (currentButton == btnCustomDate)
            {
                dtpDataComeco.Enabled = true;
                dtpDataFinal.Enabled = true;
                btnOkCustom.Visible = true;
                lblDataComeco.Cursor = Cursors.Hand;
                lblDataFinal.Cursor = Cursors.Hand;
            }
            else
            {
                dtpDataComeco.Enabled = false;
                dtpDataFinal.Enabled = false;
                btnOkCustom.Visible = false;
                lblDataComeco.Cursor = Cursors.Default;
                lblDataFinal.Cursor = Cursors.Default;
            }
        }

        private void btn7dias_Click(object sender, EventArgs e)
        {
            dtpDataComeco.Value = DateTime.Today.AddDays(-7);
            dtpDataFinal.Value = DateTime.Today.AddDays(+1);
            LoadData(nomeAtual);
            BotaoMenu(sender);
        }

        private void btn30dias_Click(object sender, EventArgs e)
        {
            dtpDataComeco.Value = DateTime.Today.AddDays(-30);
            dtpDataFinal.Value = DateTime.Today.AddDays(+1);
            BotaoMenu(sender);
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            dtpDataComeco.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDataFinal.Value = DateTime.Today.AddDays(+1);
            LoadData(nomeAtual);
            BotaoMenu(sender);
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            BotaoMenu(sender);
        }

        private void btnOkCustom_Click(object sender, EventArgs e)
        {
            LoadData(nomeAtual);
        }

        private void CapaView_Load(object sender, EventArgs e)
        {
            lblDataComeco.Text = dtpDataComeco.Text;
            lblDataFinal.Text = dtpDataFinal.Text;

            dgvEstoque.Columns[0].Width = 400;
        }

        private void lblDataComeco_Click(object sender, EventArgs e)
        {
            if (currentButton == btnCustomDate)
            {
                dtpDataComeco.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void lblDataFinal_Click(object sender, EventArgs e)
        {
            if (currentButton == btnCustomDate)
            {
                dtpDataFinal.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void dtpDataComeco_ValueChanged(object sender, EventArgs e)
        {
            lblDataComeco.Text = dtpDataComeco.Text;
        }

        private void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            lblDataFinal.Text = dtpDataFinal.Text;
        }

        private void btnAnalisemp_Click(object sender, EventArgs e)
        {
            IgnoraLoadData = true;
            CarregaAnaliseMp(nomeAtual);
        }

        private void CarregaAnaliseMp(string nome)
        {

            if (!IgnoraLoadData) return;

            CapaModel model = new CapaModel(connectionString);
            var refreshData = model.LoadData(dtpDataComeco.Value, dtpDataFinal.Value, nome);
            if (refreshData == true)
            {

                //Top Produtos
                chartTop.Titles[0].Visible = false;
                chartTop.Titles[1].Visible = true;
                chartTop.DataSource = model.TopMateriaPrima;
                chartTop.Series[0].XValueMember = "Key";
                chartTop.Series[0].YValueMembers = "Value";
                chartTop.DataBind();

                //Baixo Estoque
                dgvEstoque.DataSource = model.UnderstockListMp;
                dgvEstoque.Columns[0].HeaderText = "Item";
                dgvEstoque.Columns[1].HeaderText = "Unidades";
                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded");
        }

        private void btnAnalisePd_Click(object sender, EventArgs e)
        {
            IgnoraLoadData = false;
            LoadData(nomeAtual);
            chartTop.Titles[0].Visible = true;
            chartTop.Titles[1].Visible = false;
        }
    }
}
