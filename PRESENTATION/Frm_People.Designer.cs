namespace PRESENTATION
{
    partial class Frm_People
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
            label1 = new Label();
            btnAddPerson = new Button();
            dgvPeople = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPeople).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(204, 9);
            label1.Name = "label1";
            label1.Size = new Size(393, 25);
            label1.TabIndex = 0;
            label1.Text = "CRUD of People in WIN FORMS using LAYERS";
            // 
            // btnAddPerson
            // 
            btnAddPerson.Location = new Point(696, 13);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new Size(92, 23);
            btnAddPerson.TabIndex = 1;
            btnAddPerson.Text = "Add Person";
            btnAddPerson.UseVisualStyleBackColor = true;
            btnAddPerson.Click += btnAddPerson_Click;
            // 
            // dgvPeople
            // 
            dgvPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeople.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeople.Location = new Point(12, 81);
            dgvPeople.Name = "dgvPeople";
            dgvPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeople.Size = new Size(776, 357);
            dgvPeople.TabIndex = 2;
            dgvPeople.RowHeaderMouseDoubleClick += dgvPeople_RowHeaderMouseDoubleClick;
            // 
            // Frm_People
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPeople);
            Controls.Add(btnAddPerson);
            Controls.Add(label1);
            Name = "Frm_People";
            Text = "Frm_People";
            Load += Frm_People_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPeople).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAddPerson;
        private DataGridView dgvPeople;
    }
}