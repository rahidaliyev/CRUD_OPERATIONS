using DevExpress.Utils.Drawing.Animation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VBSQLHelper;

namespace CRUD_OPERATIONS
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
                var data_gender = SQLHelper.ExecQueryDataAsDataTable("select * from tbl_gender");
                cb_gender_field.Properties.DataSource = data_gender;
                cb_gender_field.Properties.ValueMember = "id";
                cb_gender_field.Properties.DisplayMember = "name";

               var marital_status = SQLHelper.ExecQueryDataAsDataTable("select * from marital_status");
               cb_family_field.Properties.DataSource = marital_status;
               cb_family_field.Properties.ValueMember = "id";
               cb_family_field.Properties.DisplayMember = "status";
                LoadDataToGridView();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var id = txt_id_field.Text;
            var firstname=txt_firstname_field.Text;
            var surname = txt_surname_field.Text;
            var fathername=txt_fathername_field.Text;
            var street=txt_street_field.Text;
            var age = Convert.ToInt32(spin_age_field.EditValue);
            var gender = Convert.ToBoolean(cb_gender_field.EditValue);
            var passportno = txt_passport_field.Text;
            var marital=Convert.ToBoolean(cb_family_field.EditValue);
            var start_work = start_date_field.DateTime;
            var end_work = end_date_field.DateTime;

            if (string.IsNullOrEmpty(id)) 
            {
                XtraMessageBox.Show("Id-ni daxil et!", "Information");
                txt_id_field.Focus();
                return;
            }
            if (string.IsNullOrEmpty(firstname))
            {
                XtraMessageBox.Show("Adinizi daxil edin!", "Information");
                txt_firstname_field.Focus();
                return;
            }
            if (string.IsNullOrEmpty(surname))
            {
                XtraMessageBox.Show("Soyadinizi daxil edin!", "Information");
                txt_surname_field.Focus();
                return;
            }
            if (string.IsNullOrEmpty(fathername))
            {
                XtraMessageBox.Show("Ata adini daxil edin!","Information");
                txt_fathername_field.Focus();
                return;
            }
            if (age<1)
            {
                XtraMessageBox.Show("Yasinizi daxil edin!", "Information");
                spin_age_field.Focus();
                return;
            }
            if (cb_gender_field.EditValue==null)
            {
                cb_gender_field.ShowPopup();
                return;
            }
            if (cb_family_field.EditValue == null)
            {
                cb_family_field.ShowPopup();
                return;
            }
            var employee = new Employee
            {
                id = Convert.ToInt32(id),
                name = firstname,
                surname = surname,
                father = fathername,
                street = street,
                passport_no = passportno,
                age=age,
                gender=gender,
                marital_status=marital,
                start_work=start_work,
                end_work=end_work

};

            var affectrow=SQLHelper.Insert(employee);
            if (affectrow > 0)
            {
                txt_id_field.Text = "";
                txt_firstname_field.Text = "";
                txt_surname_field.Text = "";
                txt_fathername_field.Text = "";
                spin_age_field.EditValue = 0;
                txt_street_field.Text = "";
                txt_passport_field.Text = "";
                cb_family_field.EditValue = null;
                start_date_field.DateTime = default;
                end_date_field.DateTime = default;
                cb_gender_field.EditValue = null;
                

            }
            else 
            {
                XtraMessageBox.Show("Insert Employee Fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataToGridView() 
        {
            var dataEmployee = SQLHelper.ExecQueryData<Employee>("select * from Employee_Table ");
            gridControl1.DataSource=  dataEmployee;
        }
    }
}
