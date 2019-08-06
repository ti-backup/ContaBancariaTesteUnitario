using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContaBancariaTesteUnitario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (dgvContas.Rows.Count == 0)
            {
                dgvContas.ColumnCount = 2;
                dgvContas.Columns[0].Name = "Nome";
                dgvContas.Columns[1].Name = "Saldo (R$)";
            }

            string[] linha = new string[]
            {
                txtNome.Text,
                nudSaldo.Value.ToString()
            };
            dgvContas.Rows.Add(linha);
            ResetCampos();
        }

        private void ResetCampos()
        {
            txtNome.Clear();
            nudSaldo.Value = 0;
            txtNome.Focus();
        }

        private void btnCreditar_Click(object sender, EventArgs e)
        {
            ContaBancaria cb;
            foreach(DataGridViewRow r in dgvContas.SelectedRows)
            {
                cb = new ContaBancaria(r.Cells[0].Value.ToString(), Convert.ToDouble(r.Cells[1].Value));
                cb.Credito(Convert.ToDouble(nudValor.Value));
                r.Cells[1].Value = cb.Saldo;
            }
        }

        private void btnDebitar_Click(object sender, EventArgs e)
        {
            ContaBancaria cb;
            foreach (DataGridViewRow r in dgvContas.SelectedRows)
            {
                cb = new ContaBancaria(r.Cells[0].Value.ToString(), Convert.ToDouble(r.Cells[1].Value));
                cb.Debito(Convert.ToDouble(nudValor.Value));
                r.Cells[1].Value = cb.Saldo;
            }
        }
    }
}
