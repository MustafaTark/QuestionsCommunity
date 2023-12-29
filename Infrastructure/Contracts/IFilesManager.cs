using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IFilesManager
    {
        FileStream GetFile(string fileName);
        void DeleteFile(string fileName);
        byte[]? GetFileBytes(string fileName);
        string UploadFileByBytes(byte[] fileBytes, string fileName);
        string UploadFiles(IFormFile file);
    }
}
