
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Evcomp.API.Models;
using Microsoft.Extensions.Options;

namespace Evcomp.API.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly AwsSettings _awsSettings;
        public S3Service(IOptions<AwsSettings> awsOptions)
        {
            _awsSettings = awsOptions.Value;

            var config = new AmazonS3Config
            {
                ServiceURL = _awsSettings.ServiceURL,
                ForcePathStyle = true,
                AuthenticationRegion = _awsSettings.Region
            };

            _s3Client = new AmazonS3Client(_awsSettings.AccessKey, _awsSettings.SecretKey, config);
        }

        public async Task<string> UploadFileAsync(string fileName, IFormFile file)
        {
            using var newMemoryStream = new MemoryStream();
            file.CopyTo(newMemoryStream);

            await new TransferUtility(_s3Client).UploadAsync(new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = fileName,
                BucketName = _awsSettings.BucketName,
                CannedACL = S3CannedACL.PublicRead
            });

            return $"https://s3.cloud.ru/bucket-0ada39/{fileName}";
        }
        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _awsSettings.BucketName,
                Key = fileName
            };

            var response = await _s3Client.DeleteObjectAsync(deleteObjectRequest);
            return response.HttpStatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }
}
