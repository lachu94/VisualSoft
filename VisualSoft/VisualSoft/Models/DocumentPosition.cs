namespace VisualSoft.Models
{
    public class DocumentPosition
    {
        public int KodProduktu { get; set; }
        public string NazwaProduktu { get; set; }
        public decimal Ilosc { get; set; }
        public decimal CenaNetto { get; set; }
        public decimal WartoscNetto { get; set; }
        public decimal Vat { get; set; }
        public decimal IloscPrzed { get; set; }
        public decimal AvgPrzed { get; set; }
        public decimal IloscPo { get; set; }
        public decimal AvgPo { get; set; }
        public int Grupa { get; set; }
    }
}
