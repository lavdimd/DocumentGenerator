using SAP.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Services.Helpers
{
    public class RevenueCalculatorHelper : IRevenueCalculatorHelper
    {
        public double CalculateNettoValue(double brutoValue, double vatRate)
        {
            var totalAmount = (double)brutoValue;
            var vatRateForCountry = vatRate;
            var calculatedVATRate = 1 + (double)(vatRateForCountry / 100.0);
            var netPrice = Math.Round(totalAmount / calculatedVATRate, 2);
            var taxAmount = Math.Round((totalAmount - netPrice), 2);

            return netPrice;
        }

        public double CalculateTaxAmount(double brutoValue, double vatRate)
        {
            var totalAmount = (double)brutoValue;
            var vatRateForCountry = vatRate;
            var calculatedVATRate = 1 + (double)(vatRateForCountry / 100.0);
            var netPrice = Math.Round(totalAmount / calculatedVATRate, 2);
            var taxAmount = Math.Round((totalAmount - netPrice), 2);

            return taxAmount;
        }
    }
}
