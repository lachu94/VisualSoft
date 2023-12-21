using VisualSoft.Models.Api;

namespace VisualSoft.Services
{
    public interface IFileConversionService
    {
        Task<DocumentResponse> ProcessFile(int count, IFormFile file);
    }
}
