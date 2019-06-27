using AspNetCoreMultipleUploadAPI.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AspNetCoreMultipleUploadAPI.WebApi.Controllers
{
    [Route("api/file")]
    public class FileController : Controller
    {

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            try
            {
                var result = new List<FileUploadResult>();
                foreach (var file in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", file.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    result.Add(new FileUploadResult() { Name = file.FileName, Length = file.Length });
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

    }
}
