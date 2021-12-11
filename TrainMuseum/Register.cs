using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainMuseum
{
    public partial class Register : Form
    {
        MemberDAC memDB = new MemberDAC();
        public Members MembersInfo
        {
            get
            {
                return new Members (txtID.Text, txtPW.Text, txtName.Text, txtEmail.Text);
            }
            set
            {
                txtID.Text = value.ID;
                txtPW.Text = value.PassWd;
                txtName.Text = value.Name;
                txtEmail.Text = value.Email;
            }
        }

        public Register()
        {
            InitializeComponent();
        }
        private void txtPWCheck_Validating(object sender, CancelEventArgs e)
        {
            if (txtPW.Text != txtPWCheck.Text)
            {
                errorProvider1.SetError(txtPWCheck, "비밀번호가 일치하지 않습니다.");
            }
            else
            {
                errorProvider1.SetError(txtPWCheck, "");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (memDB.IsDuplicated(txtID.Text) == true || txtPW.Text != txtPWCheck.Text || txtName.Text.Length < 1 || txtEmail.Text.Length < 1)
            {
                MessageBox.Show("회원가입이 완료되지 않았습니다.");
                return;
            }
            else
            {
                MessageBox.Show("회원가입에 성공 하셨습니다.");
                memDB.Register(MembersInfo);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (memDB.IsDuplicated(txtID.Text) == true)
            {
                errorProvider1.SetError(txtID, "해당 아이디는 이미 사용중입니다.");
            }
            else
            {
                errorProvider1.SetError(txtID, "");
            }
        }
    }
}