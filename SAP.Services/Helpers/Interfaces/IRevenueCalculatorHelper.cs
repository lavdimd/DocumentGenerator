using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Services.Helpers.Interfaces
{
    public interface IRevenueCalculatorHelper
    {

        double CalculateNettoValue(double brutoValue, double vatRate);
        double CalculateTaxAmount(double brutoValue, double vatRate);
    }
}
