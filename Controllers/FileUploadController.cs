namespace baitapupload.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.IO;

public class FileUploadController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUploadController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile UploadedFile)
    {
        if (UploadedFile != null && UploadedFile.Length > 0)
        {
            // Lấy tên file
            var fileName = Path.GetFileName(UploadedFile.FileName);

            // Lấy đường dẫn lưu trữ file
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

            // Lưu file vào thư mục "images"
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream);
            }

            // Đường dẫn ảnh hiển thị trên giao diện
            ViewBag.ImagePath = $"/images/{fileName}";
            ViewBag.Message = "Upload thành công!";
        }
        else
        {
            ViewBag.Message = "Vui lòng chọn file!";
        }

        return View();
    }
}