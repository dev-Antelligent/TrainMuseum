namespace TrainMuseum
{
    partial class MuseumInsUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuseumInsUpForm));
            this.btnPictureUpload1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpectation = new System.Windows.Forms.TextBox();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.cbxCarType = new System.Windows.Forms.ComboBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.cbxFuelType = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPictureLink1 = new System.Windows.Forms.TextBox();
            this.txtPictureLink2 = new System.Windows.Forms.TextBox();
            this.txtPictureLink3 = new System.Windows.Forms.TextBox();
            this.btnPictureUpload2 = new System.Windows.Forms.Button();
            this.btnPictureUpload3 = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxCarSize = new System.Windows.Forms.ComboBox();
            this.lblWriter = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnPictureUpload1
            // 
            this.btnPictureUpload1.Location = new System.Drawing.Point(473, 421);
            this.btnPictureUpload1.Name = "btnPictureUpload1";
            this.btnPictureUpload1.Size = new System.Drawing.Size(75, 23);
            this.btnPictureUpload1.TabIndex = 8;
            this.btnPictureUpload1.Text = "사진찾기";
            this.btnPictureUpload1.UseVisualStyleBackColor = true;
            this.btnPictureUpload1.Click += new System.EventHandler(this.btnPictureUpload1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "이름(호대)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "제원";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "설명";
            // 
            // txtSpectation
            // 
            this.txtSpectation.Location = new System.Drawing.Point(81, 39);
            this.txtSpectation.Multiline = true;
            this.txtSpectation.Name = "txtSpectation";
            this.txtSpectation.Size = new System.Drawing.Size(467, 145);
            this.txtSpectation.TabIndex = 2;
            // 
            // txtContents
            // 
            this.txtContents.Location = new System.Drawing.Point(81, 189);
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.Size = new System.Drawing.Size(467, 223);
            this.txtContents.TabIndex = 3;
            // 
            // cbxCarType
            // 
            this.cbxCarType.FormattingEnabled = true;
            this.cbxCarType.Location = new System.Drawing.Point(81, 423);
            this.cbxCarType.Name = "cbxCarType";
            this.cbxCarType.Size = new System.Drawing.Size(121, 20);
            this.cbxCarType.TabIndex = 4;
            this.cbxCarType.SelectedIndexChanged += new System.EventHandler(this.cbxCarType_SelectedIndexChanged);
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(81, 449);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 20);
            this.cbxStatus.TabIndex = 5;
            // 
            // cbxFuelType
            // 
            this.cbxFuelType.FormattingEnabled = true;
            this.cbxFuelType.Location = new System.Drawing.Point(81, 475);
            this.cbxFuelType.Name = "cbxFuelType";
            this.cbxFuelType.Size = new System.Drawing.Size(121, 20);
            this.cbxFuelType.TabIndex = 6;
            this.cbxFuelType.SelectedIndexChanged += new System.EventHandler(this.cbxCarType_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(81, 6);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(188, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "차량종류";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "운행여부";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "연료타입";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "사진 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "사진 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 480);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "사진 3";
            // 
            // txtPictureLink1
            // 
            this.txtPictureLink1.Enabled = false;
            this.txtPictureLink1.Location = new System.Drawing.Point(286, 423);
            this.txtPictureLink1.Name = "txtPictureLink1";
            this.txtPictureLink1.Size = new System.Drawing.Size(181, 21);
            this.txtPictureLink1.TabIndex = 17;
            // 
            // txtPictureLink2
            // 
            this.txtPictureLink2.Enabled = false;
            this.txtPictureLink2.Location = new System.Drawing.Point(286, 450);
            this.txtPictureLink2.Name = "txtPictureLink2";
            this.txtPictureLink2.Size = new System.Drawing.Size(181, 21);
            this.txtPictureLink2.TabIndex = 18;
            // 
            // txtPictureLink3
            // 
            this.txtPictureLink3.Enabled = false;
            this.txtPictureLink3.Location = new System.Drawing.Point(286, 477);
            this.txtPictureLink3.Name = "txtPictureLink3";
            this.txtPictureLink3.Size = new System.Drawing.Size(181, 21);
            this.txtPictureLink3.TabIndex = 19;
            // 
            // btnPictureUpload2
            // 
            this.btnPictureUpload2.Location = new System.Drawing.Point(474, 448);
            this.btnPictureUpload2.Name = "btnPictureUpload2";
            this.btnPictureUpload2.Size = new System.Drawing.Size(75, 23);
            this.btnPictureUpload2.TabIndex = 9;
            this.btnPictureUpload2.Text = "사진찾기";
            this.btnPictureUpload2.UseVisualStyleBackColor = true;
            this.btnPictureUpload2.Click += new System.EventHandler(this.btnPictureUpload2_Click);
            // 
            // btnPictureUpload3
            // 
            this.btnPictureUpload3.Location = new System.Drawing.Point(473, 475);
            this.btnPictureUpload3.Name = "btnPictureUpload3";
            this.btnPictureUpload3.Size = new System.Drawing.Size(75, 23);
            this.btnPictureUpload3.TabIndex = 10;
            this.btnPictureUpload3.Text = "사진찾기";
            this.btnPictureUpload3.UseVisualStyleBackColor = true;
            this.btnPictureUpload3.Click += new System.EventHandler(this.btnPictureUpload3_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpload.Location = new System.Drawing.Point(140, 527);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 11;
            this.btnUpload.Text = "업로드";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(314, 527);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 504);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "차량크기";
            // 
            // cbxCarSize
            // 
            this.cbxCarSize.Enabled = false;
            this.cbxCarSize.FormattingEnabled = true;
            this.cbxCarSize.Location = new System.Drawing.Point(81, 501);
            this.cbxCarSize.Name = "cbxCarSize";
            this.cbxCarSize.Size = new System.Drawing.Size(121, 20);
            this.cbxCarSize.TabIndex = 7;
            // 
            // lblWriter
            // 
            this.lblWriter.AutoSize = true;
            this.lblWriter.Location = new System.Drawing.Point(408, 15);
            this.lblWriter.Name = "lblWriter";
            this.lblWriter.Size = new System.Drawing.Size(56, 12);
            this.lblWriter.TabIndex = 27;
            this.lblWriter.Text = "작성자 ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(344, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "작성자 : ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MuseumInsUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 557);
            this.Controls.Add(this.lblWriter);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxCarSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnPictureUpload3);
            this.Controls.Add(this.btnPictureUpload2);
            this.Controls.Add(this.txtPictureLink3);
            this.Controls.Add(this.txtPictureLink2);
            this.Controls.Add(this.txtPictureLink1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cbxFuelType);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.cbxCarType);
            this.Controls.Add(this.txtContents);
            this.Controls.Add(this.txtSpectation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPictureUpload1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MuseumInsUpForm";
            this.Text = "박물관 글 올리기";
            this.Load += new System.EventHandler(this.MuseumInsUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPictureUpload1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpectation;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.ComboBox cbxCarType;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.ComboBox cbxFuelType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPictureLink1;
        private System.Windows.Forms.TextBox txtPictureLink2;
        private System.Windows.Forms.TextBox txtPictureLink3;
        private System.Windows.Forms.Button btnPictureUpload2;
        private System.Windows.Forms.Button btnPictureUpload3;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxCarSize;
        private System.Windows.Forms.Label lblWriter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}