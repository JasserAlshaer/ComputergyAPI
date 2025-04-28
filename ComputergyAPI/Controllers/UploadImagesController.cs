using Microsoft.AspNetCore.Mvc;
using ComputergyAPI.Helpers;
using Microsoft.AspNetCore.Http;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(new { Message = "No file uploaded." });

                var allowedExtensions = ".jpg.jpeg.png";

                var uploadedFileName = await FileHelper.UploadFileAsync(file, allowedExtensions);

                return Ok(new
                {
                    Message = "Image uploaded successfully!",
                    FileName = uploadedFileName
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                    //example
                });
            }
        }
    }
}