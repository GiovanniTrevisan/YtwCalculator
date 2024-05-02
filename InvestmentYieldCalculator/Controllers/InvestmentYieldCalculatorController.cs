using IMTC.CodeTest.Calculators;
using IMTC.CodeTest.Models;
using InvestmentYieldCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvestmentYieldCalculator.Controllers
{
    public class InvestmentYieldCalculatorController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IYtwCalculator _calculator;

        public InvestmentYieldCalculatorController(ILogger<HomeController> logger, IYtwCalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateYtw(decimal nominalValue, decimal cupomRate, BondType bondType, CouponType couponType)
        {
            var bond = new Bond
            {
                NominalValue = nominalValue,
                CouponRate = cupomRate,
                BondType = bondType,
                CouponType = couponType
            };

            var validationBond = await _calculator.ValidateBond(bond);

            if (!validationBond.IsValid)
                return BadRequest(validationBond.ErrorMessages);

            var yieldToWorst = await _calculator.CalculateYtwForBond(bond);

            return Ok(yieldToWorst);
        }
    }
}