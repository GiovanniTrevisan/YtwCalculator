using IMTC.CodeTest.Models;

namespace IMTC.CodeTest.Core.Services
{
    public interface IImtcCalculator
    {
        Task<decimal> CalculateYtw(Bond bond, DateTime settlementDate, FinancialIndex index);
    }
}