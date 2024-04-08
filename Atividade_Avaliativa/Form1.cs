using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_Avaliativa
{
    public partial class frmFutebol : Form
    {

        public frmFutebol()
        {
            InitializeComponent();
        }

        int id = 1;

        private void frmFutebol_Load(object sender, EventArgs e)
        {
            txtID.Text = id.ToString();
            dgvTabela.RowCount = 0;
        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTime.Text) || string.IsNullOrEmpty(txtVitoria.Text) ||
                string.IsNullOrEmpty(txtDerrota.Text) || string.IsNullOrEmpty(txtEmpate.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Campos obrigatórios não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvTabela.Rows.Add(txtID.Text, txtTime.Text, txtVitoria.Text, txtDerrota.Text, txtEmpate.Text);
            
            int vitoria = Convert.ToInt32(txtVitoria.Text);
            int derrota = Convert.ToInt32(txtDerrota.Text);
            int empate = Convert.ToInt32(txtEmpate.Text);

            id += 1;

            txtID.Text = id.ToString();
            txtTime.Focus();
            txtTime.Clear();
            txtVitoria.Clear();
            txtDerrota.Clear();
            txtEmpate.Clear();

        }
        private void dgvTabela_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTabela.RowCount > 0)
            {
                txtTime.Text = dgvTabela.CurrentRow.Cells[1].Value.ToString();
                txtVitoria.Text = dgvTabela.CurrentRow.Cells[2].Value.ToString();
                txtDerrota.Text = dgvTabela.CurrentRow.Cells[3].Value.ToString();
                txtEmpate.Text = dgvTabela.CurrentRow.Cells[4].Value.ToString();                
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvTabela.CurrentRow != null) 
            {
                dgvTabela.CurrentRow.Cells[1].Value = txtTime.Text;
                dgvTabela.CurrentRow.Cells[2].Value = txtVitoria.Text;
                dgvTabela.CurrentRow.Cells[3].Value = txtDerrota.Text;
                dgvTabela.CurrentRow.Cells[4].Value = txtEmpate.Text;
            }

            txtTime.Focus();
            txtTime.Clear();
            txtVitoria.Clear();
            txtDerrota.Clear();
            txtEmpate.Clear();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            id -= 1;

            if (dgvTabela.RowCount >0)
            {
                txtID.Text = "";
                int id = Convert.ToInt32(dgvTabela.CurrentRow.Cells[0].Value);
                string time = Convert.ToString(dgvTabela.CurrentRow.Cells[1].Value);
                int vitoria = Convert.ToInt32(dgvTabela.CurrentRow.Cells[2].Value);
                int derrota = Convert.ToInt32(dgvTabela.CurrentRow.Cells[3].Value);
                int empate = Convert.ToInt32(dgvTabela.CurrentRow.Cells[4].Value);
                dgvTabela.Rows.RemoveAt(dgvTabela.CurrentCell.RowIndex);
            }

            txtID.Clear();
            txtTime.Focus();
            txtTime.Clear();
            txtVitoria.Clear();
            txtDerrota.Clear();
            txtEmpate.Clear();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTabela.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

            string pesquisa = txtPesquisa.Text;

            foreach (DataGridViewRow row in dgvTabela.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Contains(pesquisa))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    }
                }
            }
        }
    }
}
