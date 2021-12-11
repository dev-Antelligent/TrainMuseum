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
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;

namespace TrainMuseum
{
    public partial class MuseumInsUpForm : Form
    {
        UploadMuseumVO vo = new UploadMuseumVO();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        MySqlConnection _SqlCon;

        public MuseumInsUpForm(MySqlConnection sqlCon)
        {
            _SqlCon = sqlCon;
            _SqlCon.Open();
        }
        public MuseumInsUpForm()
        {
            InitializeComponent();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MuseumInsUpForm_Load(object sender, EventArgs e)
        {
            lblWriter.Text = GlobalClass.userid;
            string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            _SqlCon = new MySqlConnection(strConn);

            string sql = "  select codeNo, category, name from codetable  ";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, _SqlCon);
            _SqlCon.Open();
            adpt.Fill(dt);

            DataView dv = new DataView(dt);
            dv.RowFilter = "category = 'carType'";
            cbxCarType.DataSource = dv.ToTable();
            cbxCarType.DisplayMember = "name";
            cbxCarType.ValueMember = "codeNo";
            
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sql, _SqlCon);
            adpt.Fill(dt1);

            DataView dv1 = new DataView(dt1);
            dv1.RowFilter = "category = 'status'";
            cbxStatus.DataSource = dv1.ToTable();
            cbxStatus.DisplayMember = "name";
            cbxStatus.ValueMember = "codeNo";

            MySqlDataAdapter adpt2 = new MySqlDataAdapter(sql, _SqlCon);
            adpt.Fill(dt2);

            DataView dv2 = new DataView(dt2);
            dv2.RowFilter = "category = 'fuelType'";
            cbxFuelType.DataSource = dv2.ToTable();
            cbxFuelType.DisplayMember = "name";
            cbxFuelType.ValueMember = "codeNo"; 
            
            MySqlDataAdapter adpt3 = new MySqlDataAdapter(sql, _SqlCon);
            adpt.Fill(dt3);

            DataView dv3 = new DataView(dt3);
            dv3.RowFilter = "category = 'carSize'";
            cbxCarSize.DataSource = dv3.ToTable();
            cbxCarSize.DisplayMember = "name";
            cbxCarSize.ValueMember = "codeNo";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //만약 제목이나 내용의 값이 없으면 에러메시지 출력하고 업로드 취소
                if (txtTitle.Text.Length < 1 || txtSpectation.Text.Length <1 || txtContents.Text.Length <1)
                {
                    MessageBox.Show("내용을 입력해 주세요");
                    return;
                }
                else
                {
                    //파일을 /bin/debug/ 폴더에 업로드하고 텍스트박스의 파일명을 DB에 저장할 이름으로 변경하는 기능
                    txtPictureBinding(txtPictureLink1);
                    txtPictureBinding(txtPictureLink2);
                    txtPictureBinding(txtPictureLink3);

                    UploadMuseumVO item = new UploadMuseumVO();
                    TrainmuseumService ts = new TrainmuseumService();
                    item.museumTitle = txtTitle.Text;
                    item.userID = lblWriter.Text;
                    item.spectation = txtSpectation.Text;
                    item.museumContents = txtContents.Text;
                    item.carType = cbxCarType.SelectedValue.ToString();
                    item.status = cbxStatus.SelectedValue.ToString();
                    item.fuelType = cbxFuelType.SelectedValue.ToString();
                    item.carSize = cbxCarSize.SelectedValue.ToString();
                    item.photoFile1 = txtPictureLink1.Text;
                    item.photoFile2 = txtPictureLink2.Text;
                    item.photoFile3 = txtPictureLink3.Text;

                    ts.Insert(item);

                    MessageBox.Show("업로드가 완료되었습니다.");
                    this.Close();
                    ts.SelectAll();
                }
            }
            catch
            {
                MessageBox.Show("업로드가 실패했습니다.");
                return;
            }
        }
        private void cbxCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCarType.SelectedIndex == 1 && cbxFuelType.SelectedIndex == 1)
            {
                cbxCarSize.Enabled = true;
            }
            else
            {
                cbxCarSize.Enabled = false;
            }

            if(cbxCarType.SelectedIndex == 2)
            {
                cbxFuelType.Enabled = false;
            }
            else
            {
                cbxFuelType.Enabled = true;
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
        private void PictrueUpload(TextBox text)
        {
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
            Cursor currentCursor = this.Cursor;
            string destFile = string.Empty;
            string sPath = string.Empty;
            string sFileName = string.Empty;
            string sExt = string.Empty;

            if (text.Text.ToString() == "") return;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string localFile = text.Text.ToString().Replace("\\", "/");
                sPath = string.Format("museumPhoto/{0}/", txtTitle.Text);
                sExt = localFile.Substring(localFile.LastIndexOf("."));
                sFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + text.Name.Substring(text.Name.Length - 1) + sExt;

                DirectoryInfo di = new DirectoryInfo(sPath);
                if (di.Exists == false)
                {
                    di.Create();
                }

                //로컬에 파일 SaveAs()
                destFile = Path.Combine(Environment.CurrentDirectory, sPath, sFileName).Replace("\\", "/");
                File.Copy(text.Text.ToString(), destFile, true);

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
    }
}
