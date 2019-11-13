using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;

public class Metric
{
    public DateTime TimeGeneratedUtc { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public string Tags { get; set; }

    public Metric(DateTime timeGeneratedUtc, string name, double value, string tags)
    {
        this.TimeGeneratedUtc = timeGeneratedUtc;
        this.Name = name;
        this.Value = value;
        this.Tags = tags;
    }

    public static int GetMetricKey(string name, string tags)
    {
        int hash = 17;
        hash = hash * 31 + name.GetHashCode();
        hash = hash * 31 + tags.GetHashCode();

        return hash;
    }
}