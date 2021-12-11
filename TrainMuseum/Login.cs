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

    public partial class Login : Form
    {
        MemberDAC memDB = new MemberDAC();
        public Logins MemberInfo
        {
            get
            {
                return new Logins(txtID.Text, txtPW.Text);
            }
            set
            {
                txtID.Text = value.ID;
                txtPW.Text = value.PassWd;
            }
        }


        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //아이디 값확인
            if (memDB.IsCorrected(txtID.Text, txtPW.Text) == true)
            {
                GlobalClass.userid = txtID.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("로그인 정보가 올바르지 않습니다.");
            }
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            //회원가입 폼 호출
            Register reg = new Register();
            reg.Show();
        }
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            //아이디 비밀번호 폼 호출
            MemberFind frm = new MemberFind();
            frm.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //나가기
            this.Close();
        }
    }
}
