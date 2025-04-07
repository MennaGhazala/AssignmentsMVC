using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Servies.Helper
{
    public class DocumentSetting
    {
        public static string UploadFile(IFormFile file, string FolderName) 
        {
            //  var folderPath = "F:\\Route\\CSharp\\AssignmentsMVC\\AssignmentsMVC\\wwwroot\\Files\\Images\\";
          
            //1. GetHashCode folder path
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            //2. get file path

            var fileName = $"{Guid.NewGuid()}-{file.FileName}";

            // 3. compine folder path + file path
            var filePath = Path.Combine(folderPath, fileName);

            //4. save file 
            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);
            return fileName;

        }


    }

   
}
