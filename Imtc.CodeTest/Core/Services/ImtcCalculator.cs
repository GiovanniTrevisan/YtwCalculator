using IMTC.CodeTest.Models;

namespace IMTC.CodeTest.Core.Services
{

    // Class made with the context passed to follow a financial context flow
    public class ImtcCalculator : IImtcCalculator
    {
        public async Task<decimal> CalculateYtw(Bond bond, DateTime settlementDate, FinancialIndex index)
        {
            decimal ytw = 0;

            switch (bond.CouponType)
            {
                case CouponType.Deferred:
                    decimal interest = bond.NominalValue * bond.CouponRate;
                    decimal discountRate = 0.05m;
                    int timeToCouponPayment = 1;
                    ytw = interest / (1 + discountRate) + bond.NominalValue / (1 + discountRate) * (1 / (1 + discountRate)) * timeToCouponPayment;
                    break;
                case CouponType.Fixed:
                    ytw = bond.NominalValue * bond.CouponRate;
                    break;
                case CouponType.Variable:
                    decimal currentIndexValue = 10;
                    ytw = bond.NominalValue * currentIndexValue * bond.CouponRate;
                    break;
                case CouponType.ZeroCoupon:
                    decimal marketPrice = 0.9m * bond.NominalValue;
                    ytw = (bond.NominalValue - marketPrice) / bond.NominalValue;
                    break;
                default:
                    throw new ArgumentException("Tipo de cupom inválido");
            }

            return ytw;
        }
    }
}
