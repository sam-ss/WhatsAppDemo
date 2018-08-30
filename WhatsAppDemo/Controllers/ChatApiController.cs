using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using WhatsAppDemo.ApiContracts;
using WhatsAppDemo.ApiContracts.WeboxAppApi;
using WhatsAppDemo.Common;
using WhatsAppDemo.Models;

namespace WhatsAppDemo.Controllers
{
    [Route("api/[controller]")]
    public class ChatApiController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public ChatApiController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage([FromBody] string request)
        {
            SendMessageRequest inputRequest = JsonConvert.DeserializeObject<SendMessageRequest>(request);
            ApiType apiType = (ApiType)Enum.Parse(typeof(ApiType), inputRequest.ApiName);

            if (apiType == ApiType.WeboxAppApi)
            {
                WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
                serviceBridge.SendWhatsAppMessage(inputRequest);
            }
            else if (apiType == ApiType.ChatApi)
            {
                ChatApiServiceBridge serviceBridge = new ChatApiServiceBridge();
                serviceBridge.SendWhatsAppMessage(inputRequest);
            }

            return Ok("received : " + request);
        }

        [HttpPost]
        [Route("SendImage")]
        public IActionResult SendImage(SendImageRequest request)
        {
            ApiType apiType = (ApiType)Enum.Parse(typeof(ApiType), request.ApiName);

            if (request.File != null)
            {
                if (request.File.Length > 0)
                {
                    var tempPath = Path.GetTempFileName();
                    tempPath = tempPath.Insert(tempPath.IndexOf(".tmp") - 1, Guid.NewGuid().ToString());
                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        request.File.CopyToAsync(stream);
                    }

                    if (apiType == ApiType.WeboxAppApi)
                    {

                        using (var stream = new FileStream(tempPath, FileMode.Open))
                        {
                            request.Url = WriteMediaToBlobStorage(apiType, stream, request.File.FileName);

                            if (!string.IsNullOrEmpty(request.Url))
                            {
                                WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
                                serviceBridge.SendWhatsAppImage(request);
                            }
                        }
                    }
                    else if (apiType == ApiType.ChatApi)
                    {
                        Byte[] bytes = this.ReadAllBytes2(tempPath);//System.IO.File.ReadAllBytes(tempPath);

                        if (request.File.FileName.Contains(".jpg"))
                            request.Url = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(bytes));
                        else if (request.File.FileName.Contains(".png"))
                            request.Url = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(bytes));
                        else if (request.File.FileName.Contains(".bmp"))
                            request.Url = string.Format("data:image/bmp;base64,{0}", Convert.ToBase64String(bytes));
                        ChatApiServiceBridge serviceBridge = new ChatApiServiceBridge();
                        serviceBridge.SendWhatsAppImage(request);

                    }

                }
            }

            return Ok("Uploaded");
        }

        [HttpPost]
        [Route("SendMedia")]
        public IActionResult SendMedia(SendMediaRequest request)
        {
            ApiType apiType = (ApiType)Enum.Parse(typeof(ApiType), request.ApiName);

            if (request.File != null)
            {
                if (request.File.Length > 0)
                {
                    var tempPath = Path.GetTempFileName();
                    tempPath = tempPath.Insert(tempPath.IndexOf(".tmp") - 1, Guid.NewGuid().ToString());
                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        request.File.CopyToAsync(stream);
                    }

                    if (apiType == ApiType.WeboxAppApi)
                    {
                        using (var stream = new FileStream(tempPath, FileMode.Open))
                        {
                            request.Url = WriteMediaToBlobStorage(apiType, stream, request.File.FileName);

                            if (!string.IsNullOrEmpty(request.Url))
                            {
                                WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
                                serviceBridge.SendWhatsAppMedia(request);
                            }
                        }
                    }
                    else if (apiType == ApiType.ChatApi)
                    {
                        Byte[] bytes = this.ReadAllBytes2(tempPath); // System.IO.File.ReadAllBytes(tempPath);

                        if (request.File.FileName.Contains(".xlsx"))
                            request.Url = string.Format("data:attachment/xlsx;base64,{0}", Convert.ToBase64String(bytes));
                        else if (request.File.FileName.Contains(".pdf"))
                            request.Url = string.Format("data:application/pdf;base64,{0}", Convert.ToBase64String(bytes));
                        else if (request.File.FileName.Contains(".docx"))
                            request.Url = string.Format("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,{0}", Convert.ToBase64String(bytes));

                        ChatApiServiceBridge serviceBridge = new ChatApiServiceBridge();
                        serviceBridge.SendWhatsAppMedia(request);

                    }
                }

            }

            return Ok("Uploaded");
        }

        [HttpPost]
        [Route("Hook")]
        public async Task<ContentResult> Hook([FromBody] string body)
        {
            WriteMessageToBlobStorage(body, ApiType.ChatApi);

            ContentResult response = new ContentResult
            {
                Content = body,
                StatusCode = 200
            };

            return await Task.FromResult(response);
        }

        [HttpPost]
        public async Task<ContentResult> Post([FromBody] string body)
        {
            ContentResult response = null;

            Hook receivedHook = new Hook();
            receivedHook.Contact = new Contact();
            receivedHook.Message = new Message();
            foreach (var eachKey in Request.Form.Keys)
            {
                if (eachKey == "event")
                    receivedHook.Event = Request.Form[eachKey];
                else if (eachKey == "token")
                    receivedHook.Token = Request.Form[eachKey];
                else if (eachKey == "uid")
                    receivedHook.Uid = Request.Form[eachKey];
                else if (eachKey == "contact[uid]")
                    receivedHook.Contact.Uid = Request.Form[eachKey];
                else if (eachKey == "contact[name]")
                    receivedHook.Contact.Name = Request.Form[eachKey];
                else if (eachKey == "contact[type]")
                    receivedHook.Contact.Type = Request.Form[eachKey];
                else if (eachKey == "message[dtm]")
                    receivedHook.Message.Dtm = Request.Form[eachKey];
                else if (eachKey == "message[uid]")
                    receivedHook.Message.Uid = Request.Form[eachKey];
                else if (eachKey == "message[cuid]")
                    receivedHook.Message.Cuid = Request.Form[eachKey];
                else if (eachKey == "message[dir]")
                    receivedHook.Message.Dir = Request.Form[eachKey];
                else if (eachKey == "message[type]")
                    receivedHook.Message.Type = Request.Form[eachKey];
                else if (eachKey == "message[body][text]")
                    receivedHook.Message.Body = Request.Form[eachKey];
                else if (eachKey == "message[ack]")
                    receivedHook.Message.Ack = Request.Form[eachKey];
            }

            WriteMessageToBlobStorage(receivedHook, ApiType.WeboxAppApi);

            response = new ContentResult
            {
                Content = JsonConvert.SerializeObject(receivedHook, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }),
                StatusCode = 200
            };

            return await Task.FromResult(response);
        }

        [HttpPost]
        [Route("GetRecentResponses")]
        public JsonResult GetRecentResponses([FromBody] string selectedApiType)
        {
            ApiType apiType = (ApiType)Enum.Parse(typeof(ApiType), selectedApiType);
            if (apiType == ApiType.WeboxAppApi)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Constants.StorageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(Constants.WeboxAppApiHooksContainer);
                BlobContinuationToken continuationToken = null;
                List<Hook> receivedHooks = new List<Hook>();
                do
                {
                    var response = container.ListBlobsSegmentedAsync(string.Empty, true, BlobListingDetails.None, new int?(), continuationToken, null, null);
                    continuationToken = response.Result.ContinuationToken;
                    foreach (var blob in response.Result.Results.OfType<CloudBlockBlob>())
                    {
                        var blobData = blob.DownloadTextAsync().Result;
                        receivedHooks.Add(JsonConvert.DeserializeObject<Hook>(blobData));
                    }
                } while (continuationToken != null);


                List<ReceviedResponseModel> receviedResponses = MapResponseToHoks(receivedHooks);
                if (receviedResponses != null && receviedResponses.Count > 0)
                    receviedResponses = receviedResponses.OrderByDescending(eachResponse => eachResponse.ReceivedAt).ToList<ReceviedResponseModel>();
                return Json(receviedResponses);
            }
            else if (apiType == ApiType.ChatApi)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Constants.StorageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(Constants.ChatApiHooksContainer);
                BlobContinuationToken continuationToken = null;
                List<WhatsAppDemo.ApiContracts.ChatApi.Hook> receivedHooks = new List<WhatsAppDemo.ApiContracts.ChatApi.Hook>();
                do
                {
                    var response = container.ListBlobsSegmentedAsync(string.Empty, true, BlobListingDetails.None, new int?(), continuationToken, null, null);
                    continuationToken = response.Result.ContinuationToken;
                    foreach (var blob in response.Result.Results.OfType<CloudBlockBlob>())
                    {
                        var blobData = blob.DownloadTextAsync().Result;
                        receivedHooks.Add(JsonConvert.DeserializeObject<WhatsAppDemo.ApiContracts.ChatApi.Hook>(JsonConvert.DeserializeObject<string>(blobData)));
                    }
                } while (continuationToken != null);


                List<ReceviedResponseModel> receviedResponses = MapResponseToHoks(receivedHooks);
                if (receviedResponses != null && receviedResponses.Count > 0)
                    receviedResponses = receviedResponses.OrderByDescending(eachResponse => eachResponse.ReceivedAt).ToList<ReceviedResponseModel>();

                return Json(receviedResponses);
            }

            return null;
        }

        private void WriteMessageToBlobStorage(object body, ApiType apiType)
        {
            UploadToBlobStorageAsJson uploadToBlobStorage = null;

            if (apiType == ApiType.WeboxAppApi)
            {
                uploadToBlobStorage = new UploadToBlobStorageAsJson(body,
                                                                    Constants.WeboxAppApiHooksContainer,
                                                                    string.Format("receivedobject{0}.json", Guid.NewGuid()));
            }
            if (apiType == ApiType.ChatApi)
            {
                uploadToBlobStorage = new UploadToBlobStorageAsJson(body,
                                                                    Constants.ChatApiHooksContainer,
                                                                    string.Format("receivedobject{0}.json", Guid.NewGuid()));
            }
            var storageAccount = CloudStorageAccount.Parse(Constants.StorageConnectionString);

            uploadToBlobStorage.Apply(storageAccount);
        }

        private string WriteMediaToBlobStorage(ApiType apiType, FileStream fileStream, string fileName)
        {
            var storageAccount = CloudStorageAccount.Parse(Constants.StorageConnectionString);

            if (apiType == ApiType.WeboxAppApi)
            {
                UploadToBlobStorageAsJson uploadToBlobStorage = new UploadToBlobStorageAsJson(fileStream,
                                                                Constants.WeboxAppApiMediaContainer,
                                                                fileName);


                return uploadToBlobStorage.ApplyMedia(storageAccount);
            }

            return string.Empty;
        }
        private List<ReceviedResponseModel> MapResponseToHoks(List<Hook> receivedHooks)
        {
            List<ReceviedResponseModel> receivedResponses = new List<ReceviedResponseModel>();

            receivedHooks.ForEach(eachHook =>
            {
                receivedResponses.Add(new ReceviedResponseModel
                {
                    ReceivedFrom = eachHook.Contact.Name,
                    ReceivedFromNumber = eachHook.Contact.Uid,
                    Response = eachHook.Message.Body,
                    ReceivedAt = eachHook.Message.Dtm.FromTimeStampToDateTime().Add(new TimeSpan(5, 30, 00))
                });
            });

            return receivedResponses;
        }

        private List<ReceviedResponseModel> MapResponseToHoks(List<WhatsAppDemo.ApiContracts.ChatApi.Hook> receivedHooks)
        {
            List<ReceviedResponseModel> receivedResponses = new List<ReceviedResponseModel>();

            receivedHooks.ForEach(eachHook =>
            {
                if (eachHook.Messages != null && eachHook.Messages.Count > 0)
                {
                    receivedResponses.Add(new ReceviedResponseModel
                    {
                        ReceivedFrom = !eachHook.Messages[0].FromMe ? eachHook.Messages[0].SenderName : Constants.SelfName,
                        ReceivedFromNumber = !eachHook.Messages[0].FromMe ? eachHook.Messages[0].ChatId.Substring(0, eachHook.Messages[0].ChatId.IndexOf("@")) : Constants.SenderMobileNumber,
                        SendTo = eachHook.Messages[0].FromMe ? eachHook.Messages[0].SenderName : Constants.SelfName,
                        SendToNumber = eachHook.Messages[0].FromMe ? eachHook.Messages[0].ChatId.Substring(0, eachHook.Messages[0].ChatId.IndexOf("@")) : Constants.SenderMobileNumber,
                        Response = eachHook.Messages[0].Body,
                        ReceivedAt = eachHook.Messages[0].Time.FromTimeStampToDateTime().Add(new TimeSpan(5, 30, 00))
                    });
                }
            });

            return receivedResponses;
        }


        private byte[] ReadAllBytes2(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}