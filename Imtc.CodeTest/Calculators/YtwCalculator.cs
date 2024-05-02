using IMTC.CodeTest.Models;
using IMTC.CodeTest.Core.Services;
using IMTC.CodeTest.Indices.Services;
using System.Xml.Schema;
using System.Linq;

namespace IMTC.CodeTest.Calculators;

public class YtwCalculator : IYtwCalculator
{
    private readonly IImtcCalculator _calculator;
    private readonly IIndexProvider _indexProvider;
    private readonly ITimeService _timeService;

    public YtwCalculator(IImtcCalculator calculator, IIndexProvider indexProvider, ITimeService timeService)
    {
        _calculator = calculator;
        _indexProvider = indexProvider;
        _timeService = timeService;
    }

    public async Task<decimal?> CalculateYtwForBond(Bond bond)
    {
        var settlementDate = _timeService.UtcNow.Date;
        return await CalculateYtwForBond(bond, settlementDate);
    }

    public async Task<decimal?> CalculateYtwForBond(Bond bond, DateTime settlementDate)
    {
        if (bond is null)
        {
            throw new ArgumentNullException(nameof(bond));
        }

        var indexCode = bond switch
        {
            Bond b when b.CouponType == CouponType.Variable => IndexNames.USTR_CMT,
            Bond b when b.BondType == BondType.Municipal => IndexNames.MuniAAA,
            _ => IndexNames.USTR_CMT
        };

        var index = await _indexProvider.GetIndex(indexCode, settlementDate);
        var ytw = await _calculator.CalculateYtw(bond, settlementDate, index);
        return ytw;
    }

    public async Task<ValidationBondHandler> ValidateBond(Bond bond)
    {

        var errorMessages = new List<string>();

        if (bond.NominalValue == 0)
            errorMessages.Add("Nominal value is zero!");

        if (bond.CouponRate == 0)
            errorMessages.Add("Coupon Rate is zero!");

        if (!Enum.IsDefined(typeof(CouponType), bond.CouponType))
            errorMessages.Add("Coupon Type is invalid");

        if (!Enum.IsDefined(typeof(BondType), bond.BondType))
            errorMessages.Add("Bond Type selected is invalid");

        return new ValidationBondHandler() { ErrorMessages = errorMessages, IsValid = !errorMessages.Any()};
    }
}