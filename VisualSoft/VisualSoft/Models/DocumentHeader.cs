namespace VisualSoft.Models
{
    public class DocumentHeader
    {
        public string CodeBA { get; set; }
        public string Type { get; set; }
        public string NumerDokumentu { get; set; }
        public DateTime DataOperacji { get; set; }
        public string NumerDniaDokumentu { get; set; }
        public string KodKontrahenta { get; set; }
        public string NazwaKontrahenta { get; set; }
        public string NumerDokumentuZewnetrznego { get; set; }
        public string DataDokumentuZewnetrznego { get; set; }
        public string Netto { get; set; }
        public string Vat { get; set; }
        public string Brutto { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
    }
}
