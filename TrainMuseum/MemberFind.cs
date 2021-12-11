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
    public partial class MemberFind : Form
    {
        MemberDAC memDB = new MemberDAC();
        public FindUserID findid
        {
            get
            {
                return new FindUserID(txtName.Text, txtEmail.Text);
            }
            set
            {
                txtName.Text = value.Name;
                txtEmail.Text = value.Email;
            }
        }
        public FindUserPassWd resetPasswd
        {
            get
            {
                return new FindUserPassWd(txtEmailforPW.Text, txtID.Text);
            }
            set
            {
                txtEmailforPW.Text = value.Email;
                txtID.Text = value.ID;
            }
        }
        public MemberFind()
        {
            InitializeComponent();
        }
        private void btnFindID_Click(object sender, EventArgs e)
        {
            //이름과 이메일을 확인해서 아이디 찾기
            if (string.IsNullOrEmpty(memDB.AnswerUserID(findid)))
            {
                MessageBox.Show(string.Format("입력하신 정보가 없습니다."));
            }
            else
            {
                MessageBox.Show(string.Format("입력하신 정보의 아이디는 {0} 입니다.", memDB.AnswerUserID(findid)));
            }
        }
        
        private void btnResetPW_Click(object sender, EventArgs e)
        {
            //아이디와 이메일을 확인해서 비밀번호 초기화폼 호출
            ResetPassword reset = new ResetPassword();
            if (memDB.FindUserPW(txtID.Text, txtEmailforPW.Text) == false)
            {
                MessageBox.Show("입력하신 정보와 맞는 ID가 없습니다.");
            }
            else
            {
                reset.resetPw = new ResetUserPassword(txtID.Text, "");
                reset.Show();
            }
        }
    }
}
