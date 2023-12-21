using System.Globalization;
using VisualSoft.Models;
using VisualSoft.Models.Api;

namespace VisualSoft.Services
{
    public class FileConversionService : IFileConversionService
    { 
        public async Task<DocumentResponse> ProcessFile(int count, IFormFile file)
        {
            var response = new DocumentResponse();

            if (file == null)
            {
                response.SetError("Brak pliku");
                return response;
            }

            try
            {
                await using var stream = file.OpenReadStream();
                string line = string.Empty;
                StreamReader streamReader = new StreamReader(stream);

                Document tempDocument = null;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] words = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    response.LineCount++;
                    response.CharCount += line.ToCharArray().Count();

                    if (IsHeader(line))
                    {
                        tempDocument = new Document();
                        var header = new DocumentHeader();
                        var props = GetProperties(header);

                        for (int i = 0; i < props.Length; i++)
                        {
                            props[i].SetValue(header, Convert.ChangeType(words[i + 1], props[i].PropertyType));
                        }

                        tempDocument.Header = header;
                        response.Documents.Add(tempDocument);
                    }
                    else if (IsComment(line, tempDocument))
                    {
                        var comment = new DocumentComment();
                        var props = GetProperties(comment);

                        for (int i = 0; i < props.Length; i++)
                        {
                            props[i].SetValue(comment, Convert.ChangeType(words[i + 1], props[i].PropertyType));
                        }
                        tempDocument.Comment = comment;
                    }
                    else if (IsPosition(line, tempDocument))
                    {
                        var positon = new DocumentPosition();
                        System.Reflection.PropertyInfo[] props = GetProperties(positon);

                        for (int i = 0; i < props.Length; i++)
                        {
                            props[i].SetValue(positon, Convert.ChangeType(words[i + 1], props[i].PropertyType, CultureInfo.InvariantCulture));
                        }

                        tempDocument.Postions.Add(positon);
                    }
                }

                response.Sum = response.Documents.Sum(x => x.Postions.Count);
                response.XCount = response.Documents.Where(x => x.Postions.Count > count).Count();

                var names = response.Documents
                    .SelectMany(x => x.Postions)
                    .GroupBy(x => x.WartoscNetto)
                    .OrderByDescending(x => x.Key)
                    .First()
                    .Select(x => x.NazwaProduktu)
                    .ToArray();

                response.ProdcutsWithMaxNetValue = string.Join(",", names);
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
            }

            return response;
        }

        private static System.Reflection.PropertyInfo[] GetProperties<T>(T model) => model.GetType().GetProperties().ToArray();
        private static bool IsPosition(string line, Document lastDocument) => line.StartsWith("B") && lastDocument != null;
        private static bool IsComment(string line, Document lastDocument) => line.StartsWith("C") && lastDocument != null;
        private static bool IsHeader(string line) => line.StartsWith("H");

    }
}
