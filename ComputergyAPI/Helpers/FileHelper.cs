namespace ComputergyAPI.Helpers
{
    public static class FileHelper
    {


        public static async Task<string> UploadFileAsync(IFormFile file, string extensions)
        {
            if (file == null || file.Length == 0)
                throw new Exception("File is empty or null");

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!extensions.Contains(extension))
                throw new Exception("File extension is not allowed");

           
            
            var fileName = Guid.NewGuid().ToString() + extension;
            var uploadIMAGE = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            var filePath = Path.Combine(uploadIMAGE, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}

