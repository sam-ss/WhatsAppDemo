using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo
{
    public class UploadToBlobStorageAsJson
    {
        private const string CONTENT_TYPE = "application/json";

        private readonly object obj;
        private readonly string containerPath;
        private readonly string blobAddressUri;
        private readonly FileStream fileStream;

        public UploadToBlobStorageAsJson(object obj,
                                            string containerPath,
                                            string blobAddressUri)
        {
            this.obj = obj;
            this.containerPath = containerPath;
            this.blobAddressUri = blobAddressUri;
        }

        public UploadToBlobStorageAsJson(FileStream fileStream,
                                            string containerPath,
                                            string blobAddressUri)
        {
            this.fileStream = fileStream;
            this.containerPath = containerPath;
            this.blobAddressUri = blobAddressUri;
        }

        public void Apply(CloudStorageAccount model)
        {
            var client = model.CreateCloudBlobClient();

            var container = client.GetContainerReference(containerPath);

            if (!container.ExistsAsync().Result)
                container.CreateAsync();

            var blobReference = container.GetBlockBlobReference(blobAddressUri);

            UploadResponseToContainer(blobReference);
        }


        public string ApplyMedia(CloudStorageAccount model)
        {
            var client = model.CreateCloudBlobClient();

            var container = client.GetContainerReference(containerPath);

            if (!container.ExistsAsync().Result)
                container.CreateAsync();

            var blobReference = container.GetBlockBlobReference(blobAddressUri);

            var blockBlob = blobReference;

            return UploadMediaToContainer(blockBlob);
        }
        private void UploadResponseToContainer(CloudBlockBlob blockBlob)
        {
            SetBlobProperties(blockBlob);
            blockBlob.UploadTextAsync(JsonConvert.SerializeObject(obj));
            //using (var ms = new MemoryStream())
            //{
            //    LoadStreamWithJson(ms);
            //    blockBlob.UploadFromStreamAsync(ms).ConfigureAwait(true);
            //}
        }

        private string UploadMediaToContainer(CloudBlockBlob blockBlob)
        {
            blockBlob.UploadFromByteArrayAsync(ReadFully(fileStream, blockBlob.StreamWriteSizeInBytes), 0, (int)fileStream.Length);
            return blockBlob.Uri.ToString();
        }

        private byte[] ReadFully(Stream input, int size)
        {
            byte[] buffer = new byte[size];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, size)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private void SetBlobProperties(CloudBlockBlob blobReference)
        {
            blobReference.Properties.ContentType = CONTENT_TYPE;
        }

        private void LoadStreamWithJson(Stream ms)
        {
            var json = JsonConvert.SerializeObject(obj);
            StreamWriter writer = new StreamWriter(ms);
            writer.Write(json);
            writer.Flush();
            ms.Position = 0;
        }
    }
}
