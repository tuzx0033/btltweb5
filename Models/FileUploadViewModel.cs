using System.ComponentModel.DataAnnotations;

namespace baitapupload.Models;


public class FileUploadViewModel
{
    [Required]
    [Display(Name = "Chọn file")]
    public IFormFile UploadedFile { get; set; }
}