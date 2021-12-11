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
using TrainMuseum.Service;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;

namespace TrainMuseum
{
    public partial class BoardInsUpForm : Form
    {
        UploadMuseumVO vo = new UploadMuseumVO();
        DataTable dt = new DataTable();
        MySqlConnection _SqlCon;

        public BoardInsUpForm(MySqlConnection sqlCon)
        {
            _SqlCon = sqlCon;
            _SqlCon.Open();
        }
        public BoardInsUpForm()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //만약 게시판의 제목이나 내용이 없으면 에러메시지 출력
            if (txtTitle.Text.Length < 1 || txtContent.Text.Length < 1)
            {
                MessageBox.Show("내용을 입력해 주세요");
                return;
            }
            //만약 게시판의 제목이나 내용이 있으면 업로드 실행
            else
            {
                txtPictureBinding(txtPictureLink1);
                txtPictureBinding(txtPictureLink2);
                txtPictureBinding(txtPictureLink3);
                txtPictureBinding(txtPictureLink4);
                txtPictureBinding(txtPictureLink5);

                UploadBoardVO item = new UploadBoardVO();
                TrainmuseumService ts = new TrainmuseumService();
                item.boardTitle = txtTitle.Text;
                item.userID = lblWriter.Text;
                item.boardContents = txtContent.Text;
                item.boardType = cbxBoardType.SelectedValue.ToString();
                item.photoFile1 = txtPictureLink1.Text;
                item.photoFile2 = txtPictureLink2.Text;
                item.photoFile3 = txtPictureLink3.Text;
                item.photoFile4 = txtPictureLink4.Text;
                item.photoFile5 = txtPictureLink5.Text;

                ts.InsertBoard(item);

                MessageBox.Show("업로드가 완료되었습니다.");
                ts.BoardSelectAll();
                this.Close();
            }
        }

        private void btnPictureUpload1_Click(object sender, EventArgs e)
        {
            PictrueUpload(txtPictureLink1);
        }

        private void btnPictureUpload2_Click(object sender, EventArgs e)
        {
            PictrueUpload(txtPictureLink2);
        }

        private void btnPictureUpload3_Click(object sender, EventArgs e)
        {
            PictrueUpload(txtPictureLink3);
        }

        private void btnPictureUpload4_Click(object sender, EventArgs e)
        {
            PictrueUpload(txtPictureLink4);
        }

        private void btnPictureUpload5_Click(object sender, EventArgs e)
        {
            PictrueUpload(txtPictureLink5);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PictrueUpload(TextBox text)
        {
            //이미지 파일 불러오기
            Cursor currentCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                openFileDialog1.Title = "Select a Image File";
                openFileDialog1.InitialDirectory = "C:";
                openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    text.Text = openFileDialog1.FileName.ToLower();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = currentCursor;
            }
        }
        private void txtPictureBinding(TextBox text)
        {
            //사진 저장할때 이름값과 폴더 저장하기
            Cursor currentCursor = this.Cursor;
            string destFile = string.Empty;
            string sPath = string.Empty;
            string sFileName = string.Empty;
            string sExt = string.Empty;

            if (text.Text.ToString() == "") return; // 이름 없으면 없는거
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string localFile = text.Text.ToString().Replace("\\", "/");
                sPath = string.Format("boardPhoto/{0}/", txtTitle.Text);
                sExt = localFile.Substring(localFile.LastIndexOf("."));
                sFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + text.Name.Substring(text.Name.Length-1) + sExt;

                DirectoryInfo di = new DirectoryInfo(sPath);
                if (di.Exists == false)
                {
                    di.Create();
                }

                //로컬에 파일 SaveAs()
                destFile = Path.Combine(Environment.CurrentDirectory, sPath, sFileName).Replace("\\", "/");
                File.Copy(text.Text, destFile, true);

                text.Text = sPath + sFileName;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = currentCursor;
            }
        }

        private void BoardInsUpForm_Load(object sender, EventArgs e)
        {
            //최초 로딩할때 정적으로 불러온 아이디와 콤보박스의 값 불러오기
            lblWriter.Text = GlobalClass.userid; 
            string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            _SqlCon = new MySqlConnection(strConn);

            string sql = " select codeNo, category, name from codetable ";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, _SqlCon);
            _SqlCon.Open();
            adpt.Fill(dt);

            DataView dv = new DataView(dt);
            dv.RowFilter = "category = 'boardType'";
            cbxBoardType.DataSource = dv.ToTable();
            cbxBoardType.DisplayMember = "name";
            cbxBoardType.ValueMember = "codeNo";
        }
    }
}
