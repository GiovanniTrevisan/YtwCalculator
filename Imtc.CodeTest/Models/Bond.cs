namespace IMTC.CodeTest.Models
{

    // Class made with the context passed to follow a financial context flow
    public class Bond
    {
        public BondType BondType { get; set; }
        public CouponType CouponType { get; set; }
        public decimal NominalValue { get; set; }
        public decimal CouponRate { get; set; }
    }
}