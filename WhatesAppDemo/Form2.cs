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
                    ContentType = "image/png"
                };

                 base64EncodedImg = base64Img.ToString();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendMessageAsync(Constant.TOKEN2);
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
                       // string imagePattern = @"data:image/png;base64,";
                        string imageURL = base64EncodedImg;//imagePattern + base64image;
                     //   string fileName = Path.GetFileName(txtFilePath.Text);
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


        static string base64String = null;
        private string base64image;
        private string base64EncodedImg;

        public string ImageToBase64(string path)
        {
            //string path = "D:\\SampleImage.jpg";
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public Stream ConvertToBase64(Stream stream)
        {
            Byte[] inArray = new Byte[(int)stream.Length];
            Char[] outArray = new Char[(int)(stream.Length * 1.34)];
            stream.Read(inArray, 0, (int)stream.Length);
            Convert.ToBase64CharArray(inArray, 0, inArray.Length, outArray, 0);
            return new MemoryStream(Encoding.UTF8.GetBytes(outArray));
        }
    }
}
