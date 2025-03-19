using System;
using System.Collections.Generic;
using System.Linq;
using GoldSavings.App.Model;

namespace GoldSavings.App.Services
{
    public class GoldAnalysisService
    {
        private readonly List<GoldPrice> _goldPrices;

        public GoldAnalysisService(List<GoldPrice> goldPrices)
        {
            _goldPrices = goldPrices;
        }
        public double GetAveragePrice()
        {
            return _goldPrices.Average(p => p.Price);
        }

        public List<double> GetHighestPrice()
        {
            return _goldPrices.OrderByDescending(p => p.Price).Take(3).Select(p => p.Price).ToList();
        }

        public List<double> GetLowestPrice()
        {
            return _goldPrices.OrderBy(p => p.Price).Take(3).Select(p => p.Price).ToList();
        }

        public List<GoldPrice> GetLowestPrice2()
        {
            return _goldPrices.OrderBy(p => p.Price).Take(3).ToList();
        }

        public List<GoldPrice> GetHighestPrice2()
        {
            return _goldPrices.OrderByDescending(p => p.Price).Take(3).ToList();
        }

        public List<GoldPrice> GetTop13GoldPrices()
        {
            return _goldPrices.OrderByDescending(p => p.Price).Take(13).ToList();
        }
        
        public double PercentageIncrease(double PurchasePrice, double sellPrice)
        {
            return ((sellPrice - PurchasePrice) / PurchasePrice) * 100;
        }
          
    }
}
