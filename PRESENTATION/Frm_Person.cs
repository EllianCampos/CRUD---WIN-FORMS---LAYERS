using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITIES;
using LOGIC;

namespace PRESENTATION
{
    public partial class Frm_Person : Form
    {
        private PersonBLL personBLL = new PersonBLL();
        private int _personId;

        public Frm_Person()
        {
            InitializeComponent();
        }

        private void GenerateNickName()
        {
            string firstname = txtFirstName.Text.ToLower();

            string lastname = txtLastName.Text.ToLower();
            int spaceIndex = lastname.IndexOf(' ');
            lastname = spaceIndex >= 0 ? lastname.Substring(0, spaceIndex) : lastname;

            string nickname = (firstname.Length == 0 ? "" : firstname.Substring(0, 1)) + lastname;
            txtNickName.Text = nickname;
        }

        public void SearchPerson(int id)
        {
            var person = personBLL.GetById(id);
            _personId = person.Id;
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtNickName.Text = person.NickName;
            dtpDateOfBirth.Text = person.DateOfBirth.ToString();
            txtAge.Text = person.Age.ToString();
        }

        public void ShowFieldsErrors(Dictionary<string, string> errors)
        {
            string? error;
            errorProvider1.Clear();

            if (errors.TryGetValue("FirstName", out error))  
                errorProvider1.SetError(txtFirstName, error);

            if (errors.TryGetValue("LastName", out error))
                errorProvider1.SetError(txtLastName, error);
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var person = new Person
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                NickName = txtNickName.Text,
                DateOfBirth = DateOnly.Parse(dtpDateOfBirth.Text),
                Age = int.TryParse(txtAge.Text, out int age) ? age : 0,
            };

            var result = personBLL.Save(person);

            if (!result.Success)
            {
                ShowFieldsErrors(result.Errors);
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var person = new Person
            {
                Id = _personId,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                NickName = txtNickName.Text,
                DateOfBirth = DateOnly.Parse(dtpDateOfBirth.Text),
                Age = int.TryParse(txtAge.Text, out int age) ? age : 0,
            };

            var result = personBLL.Update(person);

            if (!result.Success)
            {
                ShowFieldsErrors(result.Errors);
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = personBLL.Delete(_personId);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            GenerateNickName();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            GenerateNickName();
        }        
    }
}
