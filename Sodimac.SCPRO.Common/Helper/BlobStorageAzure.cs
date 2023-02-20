using Microsoft.WindowsAzure.Storage;
using System;
using System.IO;
using System.Threading.Tasks;


namespace Sodimac.SCPRO.Common.Helper
{
    public static class BlobStorageAzure
    {
        public static async Task<Uri> UploadFromStream(string key, string storageFile, string fileName, MemoryStream fileStream)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(key);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(storageFile);
                var blockBlob = container.GetBlockBlobReference(fileName);

                fileStream.Position = 0;

                using (var stream = fileStream)
                {
                    await blockBlob.UploadFromStreamAsync(stream);
                }

                return blockBlob.Uri;
            }
            catch (StorageException ex)
            {
                Console.WriteLine("StorageException: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw;
            }
        }

        public static async Task<bool> DeleteIfExistsAsync(string key, string storageFile, string fileName)
        {
            bool retorno;
            try
            {
                var storageAccount = CloudStorageAccount.Parse(key);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(storageFile);
                var blockBlob = container.GetBlockBlobReference(fileName);

                retorno = await blockBlob.DeleteIfExistsAsync();
            }
            catch (StorageException ex)
            {
                retorno = false;
                Console.WriteLine("StorageException: " + ex.Message);
            }
            catch (Exception ex)
            {
                retorno = false;
                Console.WriteLine("Exception: " + ex.Message);
            }
            return retorno;
        }

        public static async Task<byte[]> DownloadToByteArray(string key, string storageFile, string fileName)
        {
            try
            {
                var storageAccount = CloudStorageAccount.Parse(key);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(storageFile);
                var blockBlob = container.GetBlockBlobReference(fileName);
                await blockBlob.FetchAttributesAsync();

                MemoryStream memoryStream = new MemoryStream();
                await blockBlob.DownloadToStreamAsync(memoryStream);
                return memoryStream.ToArray();
            }
            catch (StorageException ex)
            {
                Console.WriteLine("StorageException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return new byte[0];
        }

        public static MemoryStream GenerateStreamFromString(string stringVal)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(stringVal);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
