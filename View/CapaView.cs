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
            dtpDataFinal.Value = DateTime.Now;
            btn7dias.Select();
            // Obtendo a connection string do Repobase.cs
            this.connectionString = connectionString;
            LoadData();
        }

        private void LoadData()
        {
            CapaModel model = new CapaModel(connectionString);
            var refreshData = model.LoadData(dtpDataComeco.Value, dtpDataFinal.Value);
            if (refreshData == true)
            {

                //lblNumOrders.Text = model.NumOrders.ToString();;
                //lblNumCustomers.Text = model.NumCustomers.ToString();
                //lblNumSuppliers.Text = model.NumSuppliers.ToString();
                //lblNumProducts.Text = model.NumProducts.ToString();

                chart1.DataSource = model.GrossRevenueList;
                chart1.Series[0].XValueMember = "Data";
                chart1.Series[0].YValueMembers = "Total";
                chart1.DataBind();

                dgvEstoque.DataSource = model.UnderstockList;
                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded, same query");
        }

        private void DisableCustomDates()
        {
            dtpDataComeco.Enabled = false;
            dtpDataFinal.Enabled = false;
            btnOkCustom.Visible = false;
        }

    }
}
