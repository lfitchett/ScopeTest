using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;
using System.Runtime.InteropServices;

public class DatedValue
{
    public double Value { get; set; }
    public DateTime Time { get; set; }
}

public class NamedValue
{
    public double Value { get; set; }
    public string Name { get; set; }
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

    public static double Avaliability(IEnumerable<NamedValue> namedValues)
    {
        var expectedRunning = namedValues.Where(v => v.Name == "edgeagent_total_time_expected_running_seconds");
        var actuallyRunning = namedValues.Where(v => v.Name == "edgeagent_total_time_running_correctly_seconds");

        if (expectedRunning.Count() != 1 || actuallyRunning.Count() != 1)
        {
            return -1;
        }

        return actuallyRunning.Single().Value / expectedRunning.Single().Value;
    }

    public static string print<T>(IEnumerable<T> stuff)
    {
        return string.Join(", ", stuff);
    }
}