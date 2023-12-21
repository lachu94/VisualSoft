namespace VisualSoft.Models
{
    public class Document
    {
        public DocumentHeader Header { get; set; }
        public DocumentComment Comment { get; set; }
        public List<DocumentPosition> Postions { get; set; }
        public Document()
        {
            Postions = new List<DocumentPosition>();
        }
    }
}
