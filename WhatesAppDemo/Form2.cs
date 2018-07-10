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

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                //txtFilePath.Text = fdlg.FileName;
                txtFilePath.Text = Path.GetFileName(fdlg.FileName);
              //  base64image = ImageToBase64(fdlg.FileName);

                var base64Img = new Base64Image
                {
                    FileContents = File.ReadAllBytes(fdlg.FileName),
                    ContentType = "image/jpg"
                };

                 base64EncodedImg = base64Img.ToString();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
            {
                string str = "message?token=" + Constant.TOKEN2; 
                sendMessageAsync(str); 
            }
            else
            {
                string str = "sendFile?token=" + Constant.TOKEN2; 
                sendMessageAsync(str);
            }
        }

        private async Task sendMessageAsync(string UrlPattern)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMobileNumber.Text.Trim()))
                {
                    List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                    requestData.Add(new KeyValuePair<string, string>("phone", txtMobileNumber.Text.Trim()));
                    if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
                    {  
                        requestData.Add(new KeyValuePair<string, string>("body", txtMessage.Text.Trim()));
                    }
                    else
                    {

                        var imageURL = base64EncodedImg;
                        requestData.Add(new KeyValuePair<string, string>("body", imageURL));
                        requestData.Add(new KeyValuePair<string, string>("filename", txtFilePath.Text));
                    }
                    var responceData = await apiRequestHandler.SendMessage(requestData, UrlPattern);
                    txtResponceStatus.Text = responceData.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        } 
    }
}
