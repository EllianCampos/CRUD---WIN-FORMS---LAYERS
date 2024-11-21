using LOGIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTATION
{
    public partial class Frm_People : Form
    {
        private readonly PersonBLL _personBLL;

        public Frm_People()
        {
            InitializeComponent();
            _personBLL = new PersonBLL();
        }

        private void LoadPeople()
        {
            dgvPeople.DataSource = null;
            dgvPeople.DataSource = _personBLL.GetAll();
        }

        private void Frm_People_Load(object sender, EventArgs e)
        {
            LoadPeople();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Person frm_Person = new Frm_Person();
            frm_Person.btnSave.Enabled = false;
            frm_Person.btnDelete.Enabled = false;
            frm_Person.ShowDialog();
            this.Show();
            LoadPeople();
        }        

        private void dgvPeople_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int personId = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells[0].Value);
            
            Frm_Person frm_Person = new Frm_Person();
            frm_Person.SearchPerson(personId);

            frm_Person.btnAdd.Enabled = false;

            this.Hide();
            frm_Person.ShowDialog();
            this.Show();
            LoadPeople();
        }
    }
}
