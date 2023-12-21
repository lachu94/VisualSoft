namespace VisualSoft.Models.Api
{
    public class DocumentResponse : ResponseBase
    {       
        public List<Document> Documents { get; set; }
        public int LineCount { get; set; }
        public int CharCount { get; set; }
        public int Sum { get; set; }
        public int XCount { get; set; }
        public string ProdcutsWithMaxNetValue { get; set; }

        public DocumentResponse()
        {
            Documents = new List<Document>();
        }
    }
}
