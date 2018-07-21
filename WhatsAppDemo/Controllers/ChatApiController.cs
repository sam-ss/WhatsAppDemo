using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public IActionResult SendMessage([FromBody] SendMessageRequest request)
        {
            WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
            serviceBridge.SendWhatsAppMessage(request);
            return Ok("received : " + request);
        }


        /*
        [HttpPost]
        [Route("SendImage")]
        public IActionResult SendImage(IFormFile file)
        {
            if (file != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);

                    SendImageRequest request = new SendImageRequest();

                    var tempPath = Path.GetTempFileName();

                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(tempPath, FileMode.Open))
                    {
                        request.Url = WriteMediaToBlobStorage(stream, file.FileName);

                        if (!string.IsNullOrEmpty(request.Url))
                        {
                            request.RecipientMobileNumber = "917715014151";
                            WeboxappServiceBridge serviceBridge = new WeboxappServiceBridge();
                            serviceBridge.SendWhatsAppImage(request);
                        }
                    }
                }
            }

            return Ok("Uploaded");
        }

        */

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
                            //request.RecipientMobileNumber = file.RecipientMobileNumber;// "917715014151";
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
        public IActionResult Post([FromBody] object body)
        {
            WriteMessageToBlobStorage(body);

            return Ok("received : " + body);
        }

        private void WriteMessageToBlobStorage(object body)
        {
            var uploadToBlobStorage = new UploadToBlobStorageAsJson(body,
                                                                Constants.ApiHooksContainer,
                                                                string.Format("receivedobject{0}.txt", Guid.NewGuid()));

            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=whatsappchatapistorage;AccountKey=j5VmajwdxuxNOw8fp6CX2mGNUTMosW8r9rxo1oF8FoPbGQFSvg9kHHb9UkHKmeOKkF552WuIESeFrDsyo9k0fQ==;EndpointSuffix=core.windows.net");

            uploadToBlobStorage.Apply(storageAccount);
        }

        private string WriteMediaToBlobStorage(FileStream fileStream, string fileName)
        {
            var uploadToBlobStorage = new UploadToBlobStorageAsJson(fileStream,
                                                                Constants.ApiMediaContainer,
                                                                fileName);

            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=whatsappchatapistorage;AccountKey=j5VmajwdxuxNOw8fp6CX2mGNUTMosW8r9rxo1oF8FoPbGQFSvg9kHHb9UkHKmeOKkF552WuIESeFrDsyo9k0fQ==;EndpointSuffix=core.windows.net");

            return uploadToBlobStorage.ApplyMedia(storageAccount);
        }
    }
}