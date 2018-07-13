using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatesAppDemo.Common;
using WhatesAppDemo.RequestHandler;

namespace WhatesAppDemo
{
    public partial class Form2 : Form
    {
        ApiRequestHandler apiRequestHandler = new ApiRequestHandler();
        private string base64EncodedImg;
        private string base64ExcelDocument;

        public Form2()
        {
            InitializeComponent();

            txtMessage.ReadOnly = true;
            txtFilePath.ReadOnly = true;
            btnFileDialog.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string apiToBeCalled;
            if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
            {
                apiToBeCalled = "message?token=" + Constant.TOKEN2;
                sendMessageAsync(apiToBeCalled);
            }
            else
            {
                apiToBeCalled = "sendFile?token=" + Constant.TOKEN2;
                sendMessageAsync(apiToBeCalled);
            }
        }

        private async Task sendMessageAsync(string UrlPattern)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMobileNumber.Text.Trim()))
                {
                    Dictionary<string, string> requestData = new Dictionary<string, string>();
                    requestData.Add("phone", txtMobileNumber.Text.Trim());
                    if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
                    {
                        requestData.Add("body", txtMessage.Text.Trim());
                    }
                    else
                    {
                        requestData.Add("body", rbImage.Checked ? base64EncodedImg : base64ExcelDocument);
                        requestData.Add("filename", txtFilePath.Text);
                    }
                    var responceData = await apiRequestHandler.SendDictionaryMessage(requestData, UrlPattern);
                    txtResponceStatus.Text = responceData.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void rbTextMessage_CheckedChanged(object sender, EventArgs e)
        {
            txtMessage.ReadOnly = false;
            txtMessage.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            txtFilePath.ReadOnly = true;
            btnFileDialog.Enabled = false;
            txtResponceStatus.Text = string.Empty;
        }

        private void btnFileDilaog_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = @"D:\Org Level Activities\Rfps\Bajaj Allianz";
            if (rbImage.Checked)
                fdlg.Filter = "Image files (*.jpg, *.jpeg) | *.jpg; *.jpeg;";
            else if (rbDocument.Checked)
                fdlg.Filter = "Document files (*.xlsx) | *.xlsx;";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = Path.GetFileName(fdlg.FileName);
                if (rbImage.Checked)
                {
                    var base64Img = new Base64Image
                    {
                        FileContents = File.ReadAllBytes(fdlg.FileName),
                        ContentType = "image/jpg"
                    };
                    base64EncodedImg = base64Img.ToString();
                }
                else if (rbDocument.Checked)
                {
                    Byte[] bytes = File.ReadAllBytes(fdlg.FileName);
                    base64ExcelDocument = string.Format("data:attachment/xlsx;base64,{0}", Convert.ToBase64String(bytes));
                }
            }
        }

        private void rbImage_CheckedChanged(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
            txtMessage.ReadOnly = true;
            txtFilePath.ReadOnly = false;
            btnFileDialog.Enabled = true;
            txtFilePath.Text = string.Empty;
            txtResponceStatus.Text = string.Empty;
        }

        private void rbDocument_CheckedChanged(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
            txtMessage.ReadOnly = true;
            txtFilePath.ReadOnly = false;
            btnFileDialog.Enabled = true;
            txtFilePath.Text = string.Empty;
            txtResponceStatus.Text = string.Empty;

        }
    }
}
