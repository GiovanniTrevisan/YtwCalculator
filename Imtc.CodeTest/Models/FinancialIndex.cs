namespace IMTC.CodeTest.Models
{

    // Class made with the context passed to follow a financial context flow
    public class FinancialIndex
    {
        public IndexNames Name { get; internal set; }
        public DateTime Date { get; internal set; }
    }
}