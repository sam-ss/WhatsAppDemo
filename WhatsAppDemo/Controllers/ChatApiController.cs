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
        public IActionResult SendMessage([FromForm] SendMessageRequest request)
        {
            var result = GetRecentResponses();
            /*
            WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
            serviceBridge.SendWhatsAppMessage(request);
            */
            return Ok("received : " + request);
        }

        [HttpPost]
        [Route("SendImage")]
        public IActionResult SendImage(SendImageRequest request)
        {
            if (request.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (request.File.Length > 0)
                {
                    var filePath = Path.Combine(uploads, request.File.FileName);

                    var tempPath = Path.GetTempFileName();

                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        request.File.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(tempPath, FileMode.Open))
                    {
                        request.Url = WriteMediaToBlobStorage(stream, request.File.FileName);

                        if (!string.IsNullOrEmpty(request.Url))
                        {
                            WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
                            serviceBridge.SendWhatsAppImage(request);
                        }
                    }
                }
            }

            return Ok("Uploaded");
        }

        [HttpPost]
        [Route("SendMedia")]
        public IActionResult SendMedia(SendMediaRequest request)
        {
            if (request.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (request.File.Length > 0)
                {
                    var filePath = Path.Combine(uploads, request.File.FileName);

                    var tempPath = Path.GetTempFileName();

                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        request.File.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(tempPath, FileMode.Open))
                    {
                        request.Url = WriteMediaToBlobStorage(stream, request.File.FileName);

                        if (!string.IsNullOrEmpty(request.Url))
                        {
                            WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
                            serviceBridge.SendWhatsAppMedia(request);
                        }
                    }
                }
            }

            return Ok("Uploaded");
        }

        [HttpPost]
        public async Task<ContentResult> Post([FromBody] string body)
        {
            ContentResult response = null;

            if (!string.IsNullOrEmpty(body))
            {
                WriteMessageToBlobStorage(body);

                response = new ContentResult
                {
                    Content = body,
                    StatusCode = 200
                };
            }
            else
            {
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

                WriteMessageToBlobStorage(receivedHook);

                response = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(receivedHook, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }),
                    StatusCode = 200
                };
            }


            return await Task.FromResult(response);
        }

        [HttpGet]
        [Route("GetRecentResponses")]
        public JsonResult GetRecentResponses()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Constants.StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(Constants.ApiHooksContainer);
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

            return Json(receviedResponses);
        }

        private void WriteMessageToBlobStorage(object body)
        {
            var uploadToBlobStorage = new UploadToBlobStorageAsJson(body,
                                                                Constants.ApiHooksContainer,
                                                                string.Format("receivedobject{0}.json", Guid.NewGuid()));

            var storageAccount = CloudStorageAccount.Parse(Constants.StorageConnectionString);

            uploadToBlobStorage.Apply(storageAccount);
        }

        private string WriteMediaToBlobStorage(FileStream fileStream, string fileName)
        {
            var uploadToBlobStorage = new UploadToBlobStorageAsJson(fileStream,
                                                                Constants.ApiMediaContainer,
                                                                fileName);

            var storageAccount = CloudStorageAccount.Parse(Constants.StorageConnectionString);

            return uploadToBlobStorage.ApplyMedia(storageAccount);
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
    }
}