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

        Console.WriteLine("\nQuestion 2.a ");


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
        Console.WriteLine("\nThe 3 Highest Gold Price Last Year : " + string.Join(", ", HighestPrice));

        Console.WriteLine("The 3 Lowest Gold Price Last Year : " + string.Join(", ", LowestPrice));


        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");


        //Question 2.b

        Console.WriteLine("\nQuestion 2.b ");

        // Step 1: Get gold prices
        DateTime startDate2b = new DateTime(2020,01,01);
        DateTime endDate2b = new DateTime(2020,02,10);
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
        Console.WriteLine("\nLowest Gold Price in January 2020 : \n" + LowestPriceJanuary2020);
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

        //Question 2.c

        Console.WriteLine("\nQuestion 2.c ");

        // Step 1: Get gold prices
        DateTime startDate2020 = new DateTime(2020,01,01);
        DateTime endDate2020 = new DateTime(2020,12,31);
        DateTime startDate2021 = new DateTime(2021,01,01);
        DateTime endDate2021 = new DateTime(2021,12,31);
        DateTime startDate2022 = new DateTime(2022,01,01);
        DateTime endDate2022 = new DateTime(2022,12,31);
        List<GoldPrice> goldPrices2020 = dataService.GetGoldPrices(startDate2020, endDate2020).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2021 = dataService.GetGoldPrices(startDate2021, endDate2021).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2022 = dataService.GetGoldPrices(startDate2022, endDate2022).GetAwaiter().GetResult();

        int goldPrices2020to2022 = goldPrices2020.Count + goldPrices2021.Count + goldPrices2022.Count;

        if (goldPrices2020to2022 == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2020to2022} records. Ready for analysis.");

        
        // Step 2: Perform analysis
        GoldAnalysisService analysisService2020 = new GoldAnalysisService(goldPrices2020);
        GoldAnalysisService analysisService2021 = new GoldAnalysisService(goldPrices2021);
        GoldAnalysisService analysisService2022 = new GoldAnalysisService(goldPrices2022);

        var top13_2020 = analysisService2020.GetTop13GoldPrices();
        var top13_2021 = analysisService2021.GetTop13GoldPrices();
        var top13_2022 = analysisService2022.GetTop13GoldPrices();

        //Calcul of the top 13 highest price between 2020 and 2022
        List<GoldPrice> top13GoldPrices2020to2022 = new List<GoldPrice>();
        top13GoldPrices2020to2022.AddRange(analysisService2020.GetTop13GoldPrices());
        top13GoldPrices2020to2022.AddRange(analysisService2021.GetTop13GoldPrices());
        top13GoldPrices2020to2022.AddRange(analysisService2022.GetTop13GoldPrices());

        // Sort the list in descending order
        top13GoldPrices2020to2022 = top13GoldPrices2020to2022
            .OrderByDescending(price => price.Price)
            .ToList();

        // Select items 11, 12 and 13
        var selectedPrices = top13GoldPrices2020to2022.Skip(10).Take(3).ToList();

        // Step 3: Print results
        Console.WriteLine("\nGold Prices ranked 11, 12, and 13:");
        foreach (var goldPrice in selectedPrices)
        {
            Console.WriteLine($"Price: {goldPrice.Price}, Date: {goldPrice.Date}");
        }

        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        //Question 2.d

        Console.WriteLine("\nQuestion 2.d ");

        // Step 1: Get gold prices

        DateTime startDate2023 = new DateTime(2023,01,01);
        DateTime endDate2023 = new DateTime(2023,12,31);
        DateTime startDate2024 = new DateTime(2024,01,01);
        DateTime endDate2024 = new DateTime(2024,12,31);
        
        List<GoldPrice> goldPrices2023 = dataService.GetGoldPrices(startDate2023, endDate2023).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2024 = dataService.GetGoldPrices(startDate2024, endDate2024).GetAwaiter().GetResult();

        int goldPrices2020_2023_2024 = goldPrices2020.Count + goldPrices2023.Count + goldPrices2024.Count;

        if (goldPrices2020_2023_2024 == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2020_2023_2024} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2023 = new GoldAnalysisService(goldPrices2023);
        GoldAnalysisService analysisService2024 = new GoldAnalysisService(goldPrices2024);

        var avgPrice2020 = analysisService2020.GetAveragePrice();
        var avgPrice2023 = analysisService2023.GetAveragePrice();
        var avgPrice2024 = analysisService2024.GetAveragePrice();

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice2020, 2), "Average Gold Price in 2020");
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice2023, 2), "Average Gold Price in 2023");
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice2024, 2), "Average Gold Price in 2024");

        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");


        //Question 2.e

        Console.WriteLine("\nQuestion 2.e ");

        // Step 1: Get gold prices

        int goldPrices2020to2024 = goldPrices2020.Count + goldPrices2021.Count + goldPrices2022.Count + goldPrices2023.Count + goldPrices2024.Count;

        if (goldPrices2020to2024 == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2020to2024} records. Ready for analysis.");

        // Step 2: Perform analysis

        // Calcul of the lowest price between 2020 and 2024
        List<GoldPrice> lowestGoldPrices2020to2024 = new List<GoldPrice>();
        lowestGoldPrices2020to2024.Add(analysisService2020.GetLowestPrice2().First());
        lowestGoldPrices2020to2024.Add(analysisService2021.GetLowestPrice2().First());
        lowestGoldPrices2020to2024.Add(analysisService2022.GetLowestPrice2().First());
        lowestGoldPrices2020to2024.Add(analysisService2023.GetLowestPrice2().First());
        lowestGoldPrices2020to2024.Add(analysisService2024.GetLowestPrice2().First());

        GoldPrice lowestPriceEver = lowestGoldPrices2020to2024.First();

        foreach (GoldPrice lowestPrice in lowestGoldPrices2020to2024)
        {
            if (lowestPrice.Price < lowestPriceEver.Price)
            {
                lowestPriceEver = lowestPrice;
            }
        }

        //Calcul of the highest price between 2020 and 2024
        List<GoldPrice> highestGoldPrices2020to2024 = new List<GoldPrice>();
        highestGoldPrices2020to2024.Add(analysisService2020.GetHighestPrice2().First());
        highestGoldPrices2020to2024.Add(analysisService2021.GetHighestPrice2().First());
        highestGoldPrices2020to2024.Add(analysisService2022.GetHighestPrice2().First());
        highestGoldPrices2020to2024.Add(analysisService2023.GetHighestPrice2().First());
        highestGoldPrices2020to2024.Add(analysisService2024.GetHighestPrice2().First());

        GoldPrice highestPriceEver = highestGoldPrices2020to2024.First();

        foreach (GoldPrice highestPrice in highestGoldPrices2020to2024)
        {
            if (highestPrice.Price > highestPriceEver.Price)
            {
                highestPriceEver = highestPrice;
            }
        }

        // Step 3: Print results
        Console.WriteLine("\nLowest Price between 2020 and 2024 : " + lowestPriceEver.Price + " on " + lowestPriceEver.Date);
        Console.WriteLine("\nHighest Price between 2020 and 2024 : " + highestPriceEver.Price + " on " + highestPriceEver.Date);

        PourcentageIncrease = analysisService2020.PercentageIncrease(lowestPriceEver.Price, highestPriceEver.Price);

        Console.WriteLine("\nSo if you buy gold on "+ lowestPriceEver.Date + " and sell it on " + highestPriceEver.Date + " you will earn a benfit of " + Math.Round(PourcentageIncrease, 2) + "%");


        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");
    }
}
