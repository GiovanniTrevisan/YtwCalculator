namespace IMTC.CodeTest.Calculators
{
    public class ValidationBondHandler
    {
        public bool IsValid { get; set; }
        public IList<string>? ErrorMessages { get; set; }
    }
}