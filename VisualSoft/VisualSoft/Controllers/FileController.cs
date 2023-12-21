using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata;
using VisualSoft.Models;
using VisualSoft.Models.Api;
using VisualSoft.Services;
using Document = VisualSoft.Models.Document;

namespace VisualSoft.Controllers
{
    [ApiController]
    [Route("api/test")]
    [Produces("application/json")]
    public class FileController : ControllerBase
    {

        private readonly ILogger<FileController> _logger;
        private readonly IFileConversionService _fileConversionService;
        public FileController(ILogger<FileController> logger, IFileConversionService fileConversionService)
        {
            _logger = logger;
            _fileConversionService = fileConversionService;
        }

        [Authorize]
        [HttpPost("x")]
        public async Task<DocumentResponse> ProcessFile(int x, IFormFile file) => await _fileConversionService.ProcessFile(x, file);
    }
}
