using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text; 

namespace SymmetricAlgorithms
{

	public class SymmetricAlgorithms : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonEncrypt;
		private System.Windows.Forms.TextBox textPlaintext;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textRecoveredPlaintext;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textCiphertext;
		private System.Windows.Forms.RadioButton radioButtonRijndael;
		private System.Windows.Forms.RadioButton radioButtonDES;
		private System.Windows.Forms.RadioButton radioButtonRC2;
		private System.Windows.Forms.GroupBox groupBoxSymmetricAlgorithm;
		private System.Windows.Forms.Button buttonGenKey;
		private System.Windows.Forms.TextBox textBoxKey;
		private System.Windows.Forms.TextBox textBoxIV;
		private System.Windows.Forms.Button buttonGenIV;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton radioButtonTripleDES;
		private System.Windows.Forms.TextBox textCipherbytes;
		private System.Windows.Forms.GroupBox groupBoxMode;
		private System.Windows.Forms.RadioButton radioButtonECB;
		private System.Windows.Forms.RadioButton radioButtonCBC;
		private System.Windows.Forms.RadioButton radioButtonCFB;
		private System.Windows.Forms.RadioButton radioButtonOFB;
		private System.Windows.Forms.RadioButton radioButtonCTS;
		private System.Windows.Forms.GroupBox groupBoxPadding;
		private System.Windows.Forms.RadioButton radioButtonPKCS7;
		private System.Windows.Forms.RadioButton radioButtonZeros;
		private System.Windows.Forms.RadioButton radioButtonNone;
        private DataGridView ResultsGrid;

        
        private System.ComponentModel.Container components = null;
        private System.Diagnostics.Stopwatch stopwatch;

        byte[] Key;
        byte[] IV;
        CipherMode Mode;
        PaddingMode Padding;
        String Algorithm;

        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        byte[] cipherbytes;

        public SymmetricAlgorithms()
		{
			InitializeComponent();	
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.textPlaintext = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textRecoveredPlaintext = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textCiphertext = new System.Windows.Forms.TextBox();
            this.groupBoxSymmetricAlgorithm = new System.Windows.Forms.GroupBox();
            this.radioButtonDES = new System.Windows.Forms.RadioButton();
            this.radioButtonRC2 = new System.Windows.Forms.RadioButton();
            this.radioButtonTripleDES = new System.Windows.Forms.RadioButton();
            this.radioButtonRijndael = new System.Windows.Forms.RadioButton();
            this.buttonGenKey = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.buttonGenIV = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textCipherbytes = new System.Windows.Forms.TextBox();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonECB = new System.Windows.Forms.RadioButton();
            this.radioButtonCBC = new System.Windows.Forms.RadioButton();
            this.radioButtonCFB = new System.Windows.Forms.RadioButton();
            this.radioButtonOFB = new System.Windows.Forms.RadioButton();
            this.radioButtonCTS = new System.Windows.Forms.RadioButton();
            this.groupBoxPadding = new System.Windows.Forms.GroupBox();
            this.radioButtonPKCS7 = new System.Windows.Forms.RadioButton();
            this.radioButtonZeros = new System.Windows.Forms.RadioButton();
            this.radioButtonNone = new System.Windows.Forms.RadioButton();
            this.ResultsGrid = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxSymmetricAlgorithm.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxPadding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(10, 175);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(90, 65);
            this.buttonEncrypt.TabIndex = 17;
            this.buttonEncrypt.Text = "Run";
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // textPlaintext
            // 
            this.textPlaintext.Location = new System.Drawing.Point(125, 175);
            this.textPlaintext.Multiline = true;
            this.textPlaintext.Name = "textPlaintext";
            this.textPlaintext.Size = new System.Drawing.Size(614, 56);
            this.textPlaintext.TabIndex = 16;
            this.textPlaintext.TextChanged += new System.EventHandler(this.textPlaintext_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(115, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 83);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plaintext";
            // 
            // textRecoveredPlaintext
            // 
            this.textRecoveredPlaintext.Location = new System.Drawing.Point(125, 452);
            this.textRecoveredPlaintext.Multiline = true;
            this.textRecoveredPlaintext.Name = "textRecoveredPlaintext";
            this.textRecoveredPlaintext.ReadOnly = true;
            this.textRecoveredPlaintext.Size = new System.Drawing.Size(614, 56);
            this.textRecoveredPlaintext.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(115, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 83);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recovered Plaintext";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(115, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(634, 83);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ciphertext Displayed as Text String";
            // 
            // textCiphertext
            // 
            this.textCiphertext.Location = new System.Drawing.Point(125, 268);
            this.textCiphertext.Multiline = true;
            this.textCiphertext.Name = "textCiphertext";
            this.textCiphertext.ReadOnly = true;
            this.textCiphertext.Size = new System.Drawing.Size(614, 55);
            this.textCiphertext.TabIndex = 18;
            // 
            // groupBoxSymmetricAlgorithm
            // 
            this.groupBoxSymmetricAlgorithm.Controls.Add(this.radioButtonDES);
            this.groupBoxSymmetricAlgorithm.Controls.Add(this.radioButtonRC2);
            this.groupBoxSymmetricAlgorithm.Controls.Add(this.radioButtonTripleDES);
            this.groupBoxSymmetricAlgorithm.Controls.Add(this.radioButtonRijndael);
            this.groupBoxSymmetricAlgorithm.Location = new System.Drawing.Point(10, 9);
            this.groupBoxSymmetricAlgorithm.Name = "groupBoxSymmetricAlgorithm";
            this.groupBoxSymmetricAlgorithm.Size = new System.Drawing.Size(163, 139);
            this.groupBoxSymmetricAlgorithm.TabIndex = 0;
            this.groupBoxSymmetricAlgorithm.TabStop = false;
            this.groupBoxSymmetricAlgorithm.Text = "Symmetric Algorithms";
            // 
            // radioButtonDES
            // 
            this.radioButtonDES.Checked = true;
            this.radioButtonDES.Location = new System.Drawing.Point(19, 18);
            this.radioButtonDES.Name = "radioButtonDES";
            this.radioButtonDES.Size = new System.Drawing.Size(96, 28);
            this.radioButtonDES.TabIndex = 0;
            this.radioButtonDES.TabStop = true;
            this.radioButtonDES.Text = "DES";
            this.radioButtonDES.CheckedChanged += new System.EventHandler(this.radioButtonSA_Changed);
            // 
            // radioButtonRC2
            // 
            this.radioButtonRC2.Location = new System.Drawing.Point(19, 102);
            this.radioButtonRC2.Name = "radioButtonRC2";
            this.radioButtonRC2.Size = new System.Drawing.Size(96, 27);
            this.radioButtonRC2.TabIndex = 3;
            this.radioButtonRC2.Text = "RC2";
            this.radioButtonRC2.CheckedChanged += new System.EventHandler(this.radioButtonSA_Changed);
            // 
            // radioButtonTripleDES
            // 
            this.radioButtonTripleDES.Location = new System.Drawing.Point(19, 46);
            this.radioButtonTripleDES.Name = "radioButtonTripleDES";
            this.radioButtonTripleDES.Size = new System.Drawing.Size(96, 28);
            this.radioButtonTripleDES.TabIndex = 1;
            this.radioButtonTripleDES.Text = "Triple DES";
            this.radioButtonTripleDES.CheckedChanged += new System.EventHandler(this.radioButtonSA_Changed);
            // 
            // radioButtonRijndael
            // 
            this.radioButtonRijndael.Location = new System.Drawing.Point(19, 74);
            this.radioButtonRijndael.Name = "radioButtonRijndael";
            this.radioButtonRijndael.Size = new System.Drawing.Size(96, 28);
            this.radioButtonRijndael.TabIndex = 2;
            this.radioButtonRijndael.Text = "Rijndael";
            this.radioButtonRijndael.CheckedChanged += new System.EventHandler(this.radioButtonSA_Changed);
            // 
            // buttonGenKey
            // 
            this.buttonGenKey.Location = new System.Drawing.Point(182, 9);
            this.buttonGenKey.Name = "buttonGenKey";
            this.buttonGenKey.Size = new System.Drawing.Size(164, 27);
            this.buttonGenKey.TabIndex = 4;
            this.buttonGenKey.Text = "New Random Key";
            this.buttonGenKey.Click += new System.EventHandler(this.buttonGenKey_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKey.Location = new System.Drawing.Point(355, 9);
            this.textBoxKey.Multiline = true;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.ReadOnly = true;
            this.textBoxKey.Size = new System.Drawing.Size(394, 46);
            this.textBoxKey.TabIndex = 5;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // textBoxIV
            // 
            this.textBoxIV.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIV.Location = new System.Drawing.Point(355, 65);
            this.textBoxIV.Multiline = true;
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.ReadOnly = true;
            this.textBoxIV.Size = new System.Drawing.Size(394, 46);
            this.textBoxIV.TabIndex = 7;
            // 
            // buttonGenIV
            // 
            this.buttonGenIV.Location = new System.Drawing.Point(182, 65);
            this.buttonGenIV.Name = "buttonGenIV";
            this.buttonGenIV.Size = new System.Drawing.Size(164, 26);
            this.buttonGenIV.TabIndex = 6;
            this.buttonGenIV.Text = "New Random Init Vector";
            this.buttonGenIV.Click += new System.EventHandler(this.buttonGenIV_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(115, 342);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(634, 83);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ciphertext Displayed as Byte Array";
            // 
            // textCipherbytes
            // 
            this.textCipherbytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCipherbytes.Location = new System.Drawing.Point(125, 360);
            this.textCipherbytes.Multiline = true;
            this.textCipherbytes.Name = "textCipherbytes";
            this.textCipherbytes.ReadOnly = true;
            this.textCipherbytes.Size = new System.Drawing.Size(614, 55);
            this.textCipherbytes.TabIndex = 19;
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButtonECB);
            this.groupBoxMode.Controls.Add(this.radioButtonCBC);
            this.groupBoxMode.Controls.Add(this.radioButtonCFB);
            this.groupBoxMode.Controls.Add(this.radioButtonOFB);
            this.groupBoxMode.Controls.Add(this.radioButtonCTS);
            this.groupBoxMode.Location = new System.Drawing.Point(182, 111);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(308, 46);
            this.groupBoxMode.TabIndex = 8;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // radioButtonECB
            // 
            this.radioButtonECB.Checked = true;
            this.radioButtonECB.Location = new System.Drawing.Point(10, 18);
            this.radioButtonECB.Name = "radioButtonECB";
            this.radioButtonECB.Size = new System.Drawing.Size(57, 19);
            this.radioButtonECB.TabIndex = 8;
            this.radioButtonECB.TabStop = true;
            this.radioButtonECB.Text = "ECB";
            this.radioButtonECB.CheckedChanged += new System.EventHandler(this.radioButtonMode_Changed);
            // 
            // radioButtonCBC
            // 
            this.radioButtonCBC.Location = new System.Drawing.Point(67, 18);
            this.radioButtonCBC.Name = "radioButtonCBC";
            this.radioButtonCBC.Size = new System.Drawing.Size(58, 19);
            this.radioButtonCBC.TabIndex = 9;
            this.radioButtonCBC.Text = "CBC";
            this.radioButtonCBC.CheckedChanged += new System.EventHandler(this.radioButtonMode_Changed);
            // 
            // radioButtonCFB
            // 
            this.radioButtonCFB.Location = new System.Drawing.Point(125, 18);
            this.radioButtonCFB.Name = "radioButtonCFB";
            this.radioButtonCFB.Size = new System.Drawing.Size(57, 19);
            this.radioButtonCFB.TabIndex = 10;
            this.radioButtonCFB.Text = "CFB";
            this.radioButtonCFB.CheckedChanged += new System.EventHandler(this.radioButtonMode_Changed);
            // 
            // radioButtonOFB
            // 
            this.radioButtonOFB.Location = new System.Drawing.Point(182, 18);
            this.radioButtonOFB.Name = "radioButtonOFB";
            this.radioButtonOFB.Size = new System.Drawing.Size(58, 19);
            this.radioButtonOFB.TabIndex = 11;
            this.radioButtonOFB.Text = "OFB";
            this.radioButtonOFB.CheckedChanged += new System.EventHandler(this.radioButtonMode_Changed);
            // 
            // radioButtonCTS
            // 
            this.radioButtonCTS.Location = new System.Drawing.Point(240, 18);
            this.radioButtonCTS.Name = "radioButtonCTS";
            this.radioButtonCTS.Size = new System.Drawing.Size(58, 19);
            this.radioButtonCTS.TabIndex = 12;
            this.radioButtonCTS.Text = "CTS";
            this.radioButtonCTS.CheckedChanged += new System.EventHandler(this.radioButtonMode_Changed);
            // 
            // groupBoxPadding
            // 
            this.groupBoxPadding.Controls.Add(this.radioButtonPKCS7);
            this.groupBoxPadding.Controls.Add(this.radioButtonZeros);
            this.groupBoxPadding.Controls.Add(this.radioButtonNone);
            this.groupBoxPadding.Location = new System.Drawing.Point(509, 111);
            this.groupBoxPadding.Name = "groupBoxPadding";
            this.groupBoxPadding.Size = new System.Drawing.Size(240, 46);
            this.groupBoxPadding.TabIndex = 13;
            this.groupBoxPadding.TabStop = false;
            this.groupBoxPadding.Text = "Padding";
            // 
            // radioButtonPKCS7
            // 
            this.radioButtonPKCS7.Checked = true;
            this.radioButtonPKCS7.Location = new System.Drawing.Point(19, 18);
            this.radioButtonPKCS7.Name = "radioButtonPKCS7";
            this.radioButtonPKCS7.Size = new System.Drawing.Size(77, 19);
            this.radioButtonPKCS7.TabIndex = 13;
            this.radioButtonPKCS7.TabStop = true;
            this.radioButtonPKCS7.Text = "PKCS7";
            this.radioButtonPKCS7.CheckedChanged += new System.EventHandler(this.radioButtonPKCS7_CheckedChanged);
            this.radioButtonPKCS7.Click += new System.EventHandler(this.radioButtonPadding_Changed);
            // 
            // radioButtonZeros
            // 
            this.radioButtonZeros.Location = new System.Drawing.Point(96, 18);
            this.radioButtonZeros.Name = "radioButtonZeros";
            this.radioButtonZeros.Size = new System.Drawing.Size(67, 19);
            this.radioButtonZeros.TabIndex = 14;
            this.radioButtonZeros.Text = "Zeros";
            this.radioButtonZeros.Click += new System.EventHandler(this.radioButtonPadding_Changed);
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.Location = new System.Drawing.Point(163, 18);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(67, 19);
            this.radioButtonNone.TabIndex = 15;
            this.radioButtonNone.Text = "None";
            // 
            // ResultsGrid
            // 
            this.ResultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.ResultsGrid.Location = new System.Drawing.Point(10, 523);
            this.ResultsGrid.Name = "ResultsGrid";
            this.ResultsGrid.RowHeadersWidth = 51;
            this.ResultsGrid.RowTemplate.Height = 24;
            this.ResultsGrid.Size = new System.Drawing.Size(739, 190);
            this.ResultsGrid.TabIndex = 22;
            this.ResultsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Type";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Algorithm";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mode";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Padding";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Time";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // SymmetricAlgorithms
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(1178, 739);
            this.Controls.Add(this.ResultsGrid);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.buttonGenKey);
            this.Controls.Add(this.groupBoxSymmetricAlgorithm);
            this.Controls.Add(this.textPlaintext);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textRecoveredPlaintext);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textCiphertext);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBoxIV);
            this.Controls.Add(this.buttonGenIV);
            this.Controls.Add(this.textCipherbytes);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.groupBoxPadding);
            this.Name = "SymmetricAlgorithms";
            this.Text = "Symmetric Algorithms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSymmetricAlgorithm.ResumeLayout(false);
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxPadding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new SymmetricAlgorithms());
		}

		private void Form1_Load(
			object sender, System.EventArgs e)
		{
			//setup initial key, iv, mode, and padding
			GenKey();
            GenIV();
            EstablishMode();
			EstablishPadding();
		}



        //mode listener
        private void radioButtonMode_Changed(
            object sender, System.EventArgs e)
        {
            EstablishMode();
        }
        //mode
        void EstablishMode()
        {
            //determine current mode
            if (radioButtonECB.Checked == true)
                Mode = CipherMode.ECB;
            if (radioButtonCBC.Checked == true)
                Mode = CipherMode.CBC;
            if (radioButtonCFB.Checked == true)
                Mode = CipherMode.CFB;
            if (radioButtonOFB.Checked == true)
                Mode = CipherMode.OFB;
            if (radioButtonCTS.Checked == true)
                Mode = CipherMode.CTS;
        }


        //padding listener
        private void radioButtonPadding_Changed(
            object sender, System.EventArgs e)
        {
            EstablishPadding();
        }
        //padding
        void EstablishPadding()
        {
            //determine current padding
            if (radioButtonPKCS7.Checked == true)
                Padding = PaddingMode.PKCS7;
            if (radioButtonZeros.Checked == true)
                Padding = PaddingMode.Zeros;
            if (radioButtonNone.Checked == true)
                Padding = PaddingMode.None;
        }


        //Generate Key
        private void buttonGenKey_Click(object sender, System.EventArgs e)
        {
            GenKey();
        }
        //key
        private void GenKey()
        {
            //Generate new random IV
            SymmetricAlgorithm sa = CreateSymmetricAlgorithm();
            sa.GenerateKey();
            Key = sa.Key;

            //do UI stuff
            UpdateKeyTextBox();
            ClearOutputFields();
        }

        //Generate Init
        private void buttonGenIV_Click(object sender, System.EventArgs e)
        {
            GenIV();
        }
        //init
        private void GenIV()
        {
            //Generate new random IV
            SymmetricAlgorithm sa =CreateSymmetricAlgorithm();
            sa.GenerateIV();
            IV = sa.IV;

            //do UI stuff
            UpdateIVTextBox();
            ClearOutputFields();
        }
        
        //trigger creation of algorithm
        private void radioButtonSA_Changed(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                //setup new initial symmetric algorithm
                SymmetricAlgorithm sa = CreateSymmetricAlgorithm();
                Key = sa.Key;
                IV = sa.IV;

                //clear old info from previous algorithm
                UpdateKeyTextBox();
                UpdateIVTextBox();
                ClearOutputFields();
            }
        }

        //creation of algorithm
        SymmetricAlgorithm CreateSymmetricAlgorithm()
        {
            //create new instance of symmetric algorithm
            if (radioButtonRC2.Checked == true)
            {
                Algorithm = "RC2";
                return RC2.Create();
            }
            if (radioButtonRijndael.Checked == true)
            {
                Algorithm = "Rijindael";
                return Rijndael.Create();
            }
            if (radioButtonDES.Checked == true)
            {
                Algorithm = "DES";
                return DES.Create();
            }
            if (radioButtonTripleDES.Checked == true)
            {
                Algorithm = "TripleDES";
                return TripleDES.Create();
            }
            return null;
        }

        private void encryption()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            //clear cipher, bytes and recovered version
            ClearOutputFields();

            SymmetricAlgorithm sa = CreateSymmetricAlgorithm();
            sa.Key = Key;
            sa.IV = IV;
            sa.Mode = Mode;
            sa.Padding = Padding;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);

            //write plaintext bytes to crypto stream
            byte[] plainbytes = Encoding.UTF8.GetBytes(textPlaintext.Text);
            cs.Write(plainbytes, 0, plainbytes.Length);
            cs.Close();
            cipherbytes = ms.ToArray();
            ms.Close();

            //display text
            textCiphertext.Text = Encoding.UTF8.GetString(cipherbytes);

            //display bytes
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cipherbytes.Length; i++)
            {
                sb.Append(String.Format(
                    "{0:X2} ", cipherbytes[i]));
            }
            textCipherbytes.Text = sb.ToString();

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;

            ResultsGrid.Rows.Add("encrypt",Algorithm, sa.Mode.ToString(), sa.Padding.ToString(), timeSpan.ToString());
        }
        private void decryption()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            SymmetricAlgorithm sa = CreateSymmetricAlgorithm();
            sa.Key = Key;
            sa.IV = IV;
            sa.Mode = Mode;
            sa.Padding = Padding;

            MemoryStream ms = new MemoryStream(cipherbytes);
            CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read);

            //read plaintext bytes from crypto stream
            byte[] plainbytes = new Byte[cipherbytes.Length];
            cs.Read(plainbytes, 0, cipherbytes.Length);
            cs.Close();
            ms.Close();

            //display recovered plaintext
            textRecoveredPlaintext.Text = Encoding.UTF8.GetString(plainbytes);

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;

            ResultsGrid.Rows.Add("decrypt", Algorithm, sa.Mode.ToString(), sa.Padding.ToString(), timeSpan.ToString());
        }
        //main function
        private void buttonEncrypt_Click(object sender, System.EventArgs e)
		{
            encryption();
            decryption();
		}

        //clear cipher, bytes and recovered
        private void ClearOutputFields()
        {
            textCiphertext.Text = "";
            textCipherbytes.Text = "";
            textRecoveredPlaintext.Text = "";
        }

        private void buttonDecrypt_Click(object sender, System.EventArgs e)
		{
			

		}

		private void UpdateKeyTextBox()
		{
			StringBuilder sb = new StringBuilder();
			for (int i=0; i<Key.Length; i++)
			{
				sb.Append(
					String.Format("{0:X2} ", Key[i]));
			}
			textBoxKey.Text = sb.ToString();
		}

		private void UpdateIVTextBox()
		{
			StringBuilder sb = new StringBuilder();
			for (int i=0; i<IV.Length; i++)
			{
				sb.Append(
					String.Format("{0:X2} ", IV[i]));
			}
			textBoxIV.Text = sb.ToString();
		}

        //new text listener
		private void textPlaintext_TextChanged(
			object sender, System.EventArgs e)
		{
			ClearOutputFields();
		}
        

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButtonPKCS7_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
