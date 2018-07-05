using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatesAppDemo.Common;
using WhatesAppDemo.RequestHandler;

namespace WhatesAppDemo
{
    public partial class Form1 : Form
    {
        ApiRequestHandler apiRequestHandler = new ApiRequestHandler();
        public Form1()
        {
            InitializeComponent();
            txtToken.Text = Constant.TOKEN;
            txtUid.Text = Constant.UID;
            txtUserId.Text = Constant.UID;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (rbMessage.Checked == true)
            {
                sendMessageAsync(Constant.Send_Chat);
            }
            else if (rbImage.Checked == true)
            {
                sendMessageAsync(Constant.Send_Image);
            }
            else if (rbLink.Checked == true)
            {
                sendMessageAsync(Constant.Send_Link);
            }
            else if (rbVideo.Checked == true)
            {
                sendMessageAsync(Constant.Send_Media);
            } 
        } 
        private void rbMessage_CheckedChanged(object sender, EventArgs e)
        {
            grpMedia.Visible = false;
        } 
        private void Form1_Load(object sender, EventArgs e)
        {
            if (rbMessage.Checked == true)
            {
                grpMedia.Visible = false;
            }
            else
            {
                grpMedia.Visible = true;

            }
        }

        private void rbImage_CheckedChanged(object sender, EventArgs e)
        {
            grpMedia.Visible = true;
            isThbmbShow(false);
        }

        void isThbmbShow(bool value)
        {
            txtUrlThumb.Visible = value;
            lblUrlThumb.Visible = value;
        }

        private void rbLink_CheckedChanged(object sender, EventArgs e)
        {
            grpMedia.Visible = true;
            isThbmbShow(true);
        } 
        private void rbVideo_CheckedChanged(object sender, EventArgs e)
        {
            grpMedia.Visible = true;
            isThbmbShow(true);
        } 

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            CheclkAccountStatusAsync(Constant.Check_Account_Status);
        }

        private async Task CheclkAccountStatusAsync(string UrlPattern)
        {
            try
            {
                
                    List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                    requestData.Add(new KeyValuePair<string, string>("token", txtToken.Text.Trim()));
                //  requestData.Add(new KeyValuePair<string, string>("uid", txtUserId.Text.Trim()));
                var address = string.Format("{0}{1}", UrlPattern, txtUserId.Text.Trim());
                var responceData = await apiRequestHandler.SendMessage(requestData, address);
                    txtStatusResult.Text = responceData.ToString();
                
            }
            catch (Exception ex)
            {
            }
        }

        private async Task sendMessageAsync(string UrlPattern)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMobileNumber.Text.Trim()))
                {
                    List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                    requestData.Add(new KeyValuePair<string, string>("token", txtToken.Text.Trim()));
                    requestData.Add(new KeyValuePair<string, string>("uid", txtUid.Text.Trim()));
                    requestData.Add(new KeyValuePair<string, string>("to", txtMobileNumber.Text.Trim()));
                    requestData.Add(new KeyValuePair<string, string>("custom_uid", txtCustomUid.Text.Trim()));
                    if (rbMessage.Checked == true)
                    {
                        if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
                            return;
                        requestData.Add(new KeyValuePair<string, string>("text", txtMessage.Text.Trim()));
                    }
                    else if (rbImage.Checked == true || rbLink.Checked == true || rbVideo.Checked == true)
                    {
                        requestData.Add(new KeyValuePair<string, string>("url", txtMediaImageUrl.Text.Trim()));
                        if (!string.IsNullOrEmpty(txtCaption.Text.Trim()))
                        {
                            requestData.Add(new KeyValuePair<string, string>("caption", txtCaption.Text.Trim()));
                        }
                        else if (!string.IsNullOrEmpty(txtDescription.Text.Trim()))
                        {
                            requestData.Add(new KeyValuePair<string, string>("description", txtDescription.Text.Trim()));
                        }

                        if (rbLink.Checked == true || rbVideo.Checked == true)
                        {
                            if (!string.IsNullOrEmpty(txtUrlThumb.Text.Trim()))
                            {
                                requestData.Add(new KeyValuePair<string, string>("url_thumb", txtUrlThumb.Text.Trim()));
                            }
                        }
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
