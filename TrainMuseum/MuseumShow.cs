using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainMuseum.DAC;
using static TrainMuseum.DAC.MuseumShowDAC;

namespace TrainMuseum
{
    public partial class MuseumShow : Form
    {
        MemberDAC memDAC = new MemberDAC();
        UploadMuseumDAC uploadDAC = new UploadMuseumDAC();
        MuseumShowDAC dac = new MuseumShowDAC();
        public MuseumShow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MuseumShow_Load(object sender, EventArgs e)
        {
            lblTitle.Text = GlobalClass.museumtitle;
            DataTable dt = dac.SelectMuseum(lblTitle.Text);

            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("자료가 없습니다.");
                this.Close();
            }
            else
            {
                txtSpectation.Text = dt.Rows[0]["spectation"].ToString();
                txtContents.Text = dt.Rows[0]["museumContents"].ToString();
                pictureBox1.ImageLocation = dt.Rows[0]["photoFile1"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = dac.SelectMuseum(lblTitle.Text);

            if (dt.Rows[0]["photoFile1"].ToString() == pictureBox1.ImageLocation)
             {
                 pictureBox1.Refresh();
                 pictureBox1.ImageLocation = dt.Rows[0]["photoFile2"].ToString();

             }
             else if(dt.Rows[0]["photoFile2"].ToString() == pictureBox1.ImageLocation)
             {
                 pictureBox1.Refresh();
                 pictureBox1.ImageLocation = dt.Rows[0]["photoFile3"].ToString();
             }
             else
             {
                 pictureBox1.Refresh();
                 pictureBox1.ImageLocation = dt.Rows[0]["photoFile1"].ToString();
             }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*
            if (memDAC.IsManager(GlobalClass.userid) == true)
            {
                DataTable dt = dac.SelectMuseum(lblTitle.Text);
                string MuseumNo = dt.Rows[0]["boardNo"].ToString();
                if (MessageBox.Show("정말로 글을 삭제하시겠습니까?","삭제확인",MessageBoxButtons.YesNo) == DialogResult.Yes);
                {
                    uploadDAC.Delete(MuseumNo);
                }
            }*/
        }
    }
}
