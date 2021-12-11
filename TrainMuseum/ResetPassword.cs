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
    public partial class ResetPassword : Form
    {
        MemberDAC memDB = new MemberDAC();
        MemberFind memFind = new MemberFind();
        public ResetUserPassword resetPw
        {
            get
            {
                return new ResetUserPassword(lblID.Text, txtPW.Text);
            }
            set
            {
                lblID.Text = value.ID;
                txtPW.Text = value.Password;
            }
        }
        public ResetPassword()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPW.Text != txtPWCheck.Text)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }
            else
            {
                MessageBox.Show("비밀번호가 변경되었습니다.");
                memDB.ResetPasswd(resetPw);
                this.Close();
            }
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            lblID.Text = resetPw.ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
