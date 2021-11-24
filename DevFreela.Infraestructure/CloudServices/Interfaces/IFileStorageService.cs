using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Infraestructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}
