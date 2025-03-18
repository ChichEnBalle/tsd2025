using GoldSavings.App.Model;
using GoldSavings.App.Client;
using GoldSavings.App.Services;
namespace GoldSavings.App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Gold Investor!");

        // Step 1: Get gold prices
        GoldDataService dataService = new GoldDataService();
        DateTime startDate = new DateTime(2024,09,18);
        DateTime endDate = DateTime.Now;
        List<GoldPrice> goldPrices = dataService.GetGoldPrices(startDate, endDate).GetAwaiter().GetResult();

        if (goldPrices.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService = new GoldAnalysisService(goldPrices);
        var avgPrice = analysisService.GetAveragePrice();

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice, 2), "Average Gold Price Last Half Year");

        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        // Question 2.a 

        // Step 1: Get gold prices
        DateTime startDate2a = new DateTime(2024,01,01);
        DateTime endDate2a = new DateTime(2024,12,31);
        List<GoldPrice> goldPrices2a = dataService.GetGoldPrices(startDate2a, endDate2a).GetAwaiter().GetResult();

        if (goldPrices2a.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2a.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2a = new GoldAnalysisService(goldPrices2a);
        var HighestPrice = analysisService2a.GetHighestPrice();
        var LowestPrice = analysisService2a.GetLowestPrice();

        // Step 3: Print results
        Console.WriteLine("The 3 Highest Gold Price Last Year : " + string.Join(", ", HighestPrice));

        Console.WriteLine("The 3 Lowest Gold Price Last Year : " + string.Join(", ", LowestPrice));


        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");


        //Question 2.b

        // Step 1: Get gold prices
        DateTime startDate2b = new DateTime(2020,01,01);
        DateTime endDate2b = new DateTime(2020,03,30);
        List<GoldPrice> goldPrices2b = dataService.GetGoldPrices(startDate2b, endDate2b).GetAwaiter().GetResult();

        if (goldPrices2b.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2b.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2b = new GoldAnalysisService(goldPrices2b);
        var LowestPriceJanuary2020 = analysisService2b.GetLowestPrice().First();

        // Step 3: Print results
        Console.WriteLine("Lowest Gold Price in January 2020 : " + LowestPriceJanuary2020);
        double PourcentageIncrease = 0;

        foreach (var goldPriceToday in goldPrices2b)
        {
            PourcentageIncrease = analysisService2b.PercentageIncrease(LowestPriceJanuary2020, goldPriceToday.Price);
            if (PourcentageIncrease >= 5)
            {
                Console.WriteLine("On "+ goldPriceToday.Date +", they would have earned " + Math.Round(PourcentageIncrease, 2) +  "%");
            }
        }

        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        //Question 2.e

        // Step 1: Get gold prices
        DateTime startDate2020 = new DateTime(2020,01,01);
        DateTime endDate2020 = new DateTime(2020,12,31);
        DateTime startDate2021 = new DateTime(2021,01,01);
        DateTime endDate2021 = new DateTime(2021,12,31);
        DateTime startDate2022 = new DateTime(2022,01,01);
        DateTime endDate2022 = new DateTime(2022,12,31);
        DateTime startDate2023 = new DateTime(2023,01,01);
        DateTime endDate2023 = new DateTime(2023,12,31);
        DateTime startDate2024 = new DateTime(2024,01,01);
        DateTime endDate2024 = new DateTime(2024,12,31);
        List<GoldPrice> goldPrices2020 = dataService.GetGoldPrices(startDate2020, endDate2020).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2021 = dataService.GetGoldPrices(startDate2021, endDate2021).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2022 = dataService.GetGoldPrices(startDate2022, endDate2022).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2023 = dataService.GetGoldPrices(startDate2023, endDate2023).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2024 = dataService.GetGoldPrices(startDate2024, endDate2024).GetAwaiter().GetResult();

        int goldPrices2020to2024 = goldPrices2020.Count + goldPrices2021.Count + goldPrices2022.Count + goldPrices2023.Count + goldPrices2023.Count;

        if (goldPrices2020to2024 == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2020to2024} records. Ready for analysis.");

        // Step 2: Perform analysis

        // Calcul of the lowest price between 2020 and 2024
        List<Double> lowestGoldPrices2020to2024 = new List<Double>();
        GoldAnalysisService analysisService2020 = new GoldAnalysisService(goldPrices2020);
        GoldAnalysisService analysisService2021 = new GoldAnalysisService(goldPrices2021);
        GoldAnalysisService analysisService2022 = new GoldAnalysisService(goldPrices2022);
        GoldAnalysisService analysisService2023 = new GoldAnalysisService(goldPrices2023);
        GoldAnalysisService analysisService2024 = new GoldAnalysisService(goldPrices2024);

        lowestGoldPrices2020to2024.Add(analysisService2020.GetLowestPrice().First());
        lowestGoldPrices2020to2024.Add(analysisService2021.GetLowestPrice().First());
        lowestGoldPrices2020to2024.Add(analysisService2022.GetLowestPrice().First());
        lowestGoldPrices2020to2024.Add(analysisService2023.GetLowestPrice().First());
        lowestGoldPrices2020to2024.Add(analysisService2024.GetLowestPrice().First());
        
        double lowestPriceEver = analysisService2020.GetLowestPrice().First();


        foreach(double lowestPrice in lowestGoldPrices2020to2024)
        {
            if(lowestPrice < lowestPriceEver)
            {
                lowestPriceEver=lowestPrice;
            }
        }

        //Calcul of the highest price between 2020 and 2024

        List<Double> HighestGoldPrices2020to2024 = new List<Double>();
        HighestGoldPrices2020to2024.Add(analysisService2020.GetHighestPrice().First());
        HighestGoldPrices2020to2024.Add(analysisService2021.GetHighestPrice().First());
        HighestGoldPrices2020to2024.Add(analysisService2022.GetHighestPrice().First());
        HighestGoldPrices2020to2024.Add(analysisService2023.GetHighestPrice().First());
        HighestGoldPrices2020to2024.Add(analysisService2024.GetHighestPrice().First());

        double highestPriceEver = analysisService2020.GetHighestPrice().First();

        foreach(double highestPrice in HighestGoldPrices2020to2024)
        {
            if(highestPrice > highestPriceEver)
            {
                highestPriceEver=highestPrice;
            }
        }

        // Step 3: Print results

        Console.WriteLine("Lowest Price Ever :" + lowestPriceEver);
        Console.WriteLine("Highest Price Ever :" + highestPriceEver);


        // Console.WriteLine("Lowest Gold Price in 2020 and 2024 : " + LowestPrice2020to2024);
        // Console.WriteLine("Highest Gold Price in 2020 and 2024 : " + HighestPrice2020to2024);
        // Console.WriteLine("Pourcentage Increase between the lowest and highest price in 2020 and 2024 : " + Math.Round(PourcentageIncrease, 2) + "%");


        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");
    }
}
