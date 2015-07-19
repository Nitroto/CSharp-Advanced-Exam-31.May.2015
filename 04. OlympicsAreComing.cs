using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

class OlympicsAreComing
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Regex splitPattern = new Regex(@"\s*\|\s*");
        Dictionary<string, List<string>> winers = new Dictionary<string, List<string>>();
        string command = Console.ReadLine();
        while (command != "report")
        {
            string[] tokens = splitPattern.Split(command.Trim());
            string athlete = Regex.Replace(tokens[0].Trim(), @"\s+", " ");
            string country = Regex.Replace(tokens[1].Trim(), @"\s+", " ");

            if (!winers.ContainsKey(country))
            {
                winers.Add(country, new List<string>());
            }

            winers[country].Add(athlete);

            command = Console.ReadLine();
        }

        var orderedCountryData = winers
            .OrderByDescending(x => x.Value.Count);

        foreach (var country in orderedCountryData)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins",
                country.Key,
                country.Value.Distinct().Count(),
                country.Value.Count);
        }
    }
}

