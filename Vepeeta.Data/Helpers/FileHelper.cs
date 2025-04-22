using Microsoft.AspNetCore.Http;
using Vepeeta.Data.Entity.Identity.Clinics;

namespace Vepeeta.Data.Helpers
{
    public static class FileHelper
    {
        public static string SaveFile(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadsFolder = Path.Combine("wwwroot", "Photos", folderName);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // التأكد من وجود المجلد
            Directory.CreateDirectory(uploadsFolder);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            // إنشاء مسار URL الكامل باستخدام عنوان السيرفر
            string relativePath = Path.Combine("Photos", folderName, uniqueFileName);
            string fullUrl = $"http://vepeeta.runasp.net/{relativePath.Replace("\\", "/")}";

            return fullUrl;
        }

        public static List<ClincsImage> SaveFilesOfClincImageAsImages(List<IFormFile> files, string folderName)
        {
            // تحقق من أن الملفات ليست null
            if (files == null || files.Count == 0)
            {
                throw new ArgumentNullException(nameof(files), "The file list cannot be null or empty.");
            }

            // تحقق من أن المجلد ليس null أو فارغ
            if (string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentException("The folder name cannot be null or empty.", nameof(folderName));
            }

            var images = new List<ClincsImage>();

            foreach (var file in files)
            {
                // تحقق من أن الملف ليس null
                if (file == null)
                {
                    continue; // أو يمكن إضافة معاملة لتجاهل الملف الحالي إذا كان null
                }

                var fileUrl = SaveFile(file, folderName);
                if (fileUrl != null)
                {
                    images.Add(new ClincsImage { ImageUrl = fileUrl });
                }
            }

            return images;
        }


    }
}
