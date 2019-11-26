using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;
//using Newtonsoft.Json;

public class Metric
{
    public DateTime TimeGeneratedUtc { get; private set; }
    public string Name { get; private set; }
    public double Value { get; private set; }
    public string Tags { get; private set; }

    public Metric(DateTime timeGeneratedUtc, string name, double value, string tags)
    {
        this.TimeGeneratedUtc = timeGeneratedUtc;
        this.Name = name;
        this.Value = value;
        this.Tags = tags;
    }
}

public static class FakeData
{
    static readonly Random rand = new Random();

    public static IEnumerable<Metric> GenerateSeries(DateTime startDay, int numScrapes = 240)
    {
        return new Metric[] { new Metric(startDay, "test", 5, "tags sdjkhfalsdjfhlasdjfhalsdjfhalsdjfhalsdfjh"),
                              new Metric(startDay, "test", 55, "tags sdjkhfalsdjfhlasdjfhalsdjfhalsdjfhalsdfjh"),
                              new Metric(startDay, "test", 555, "tags sdjkhfalsdjfhlasdjfhalsdjfhalsdjfhalsdfjh")
        };
    }

}

public static class TestHelper
{
    public static string GetDeviceId(string tags)
    {
        return "Test";
        //return JsonConvert.DeserializeObject<Dictionary<string, string>>(tags)["device_id"];
    }
}
