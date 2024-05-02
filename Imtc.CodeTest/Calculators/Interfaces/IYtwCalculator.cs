using IMTC.CodeTest.Models;

namespace IMTC.CodeTest.Calculators
{
    public interface IYtwCalculator
    {
        Task<decimal?> CalculateYtwForBond(Bond bond);
        Task<decimal?> CalculateYtwForBond(Bond bond, DateTime settlementDate);
        Task<ValidationBondHandler> ValidateBond(Bond bond);
    }
}