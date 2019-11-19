using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

public class DatedValue
{
    public double Value { get; set; }
    public DateTime Time { get; set; }
}

public static class Helper
{
    public static double Duration(IEnumerable<DatedValue> datedValues)
    {
        IEnumerable<double> values = datedValues.OrderBy(v => v.Time).Select(v => v.Value);

        double total = 0;
        double lowest = values.First();
        double highest = lowest;
        foreach (var value in values.Skip(1))
        {
            if (value < highest)
            {
                total += highest - lowest;
                lowest = value;
            }
            highest = value;
        }

        return total + highest - lowest;
    }

    public static string print<T>(IEnumerable<T> stuff)
    {
        return string.Join(", ", stuff);
    }

    public static Dictionary<string, string> ParseTags(string rawTags)
    {
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(rawTags);
    }
}