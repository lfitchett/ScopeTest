using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;
using Newtonsoft.Json;

public class Metric
{
    public DateTime TimeGeneratedUtc;
    public string Name;
    public double Value;
    public string Tags;
    public string DeviceId;
}

public static class GenerateMetrics
{
    static readonly Random rand = new Random();

    public static IEnumerable<Metric> GenerateSeries(DateTime startDay, ScopeArray<string> deviceIds, int numScrapes = 240)
    {
        startDay = startDay.Date;

        for (int i = 0; i < deviceIds.Count; i++)
        {
            string deviceId = deviceIds[i];
            double avaliability = i / (double)deviceIds.Count;

            Dictionary<string, string> baseTags = new Dictionary<string, string>
                {
                    {"instance", "1" },
                    { "device_id", deviceId },
                };

            for (int j = 0; j < numScrapes; j++)
            {
                DateTime currTime = startDay.AddDays(j / (double)numScrapes);

                Dictionary<string, string> tags = new Dictionary<string, string>(baseTags);
                tags.Add("module", "$edgeAgent");
                yield return new Metric { TimeGeneratedUtc = currTime, Name = "edgeagent_total_time_expected_running_seconds", Tags = JsonConvert.SerializeObject(tags), DeviceId = deviceId, Value = 500 * j };
                yield return new Metric { TimeGeneratedUtc = currTime, Name = "edgeagent_total_time_running_correctly_seconds", Tags = JsonConvert.SerializeObject(tags), DeviceId = deviceId, Value = 500 * j * avaliability };

                tags = new Dictionary<string, string>(baseTags);
                tags.Add("module", "$edgeHub");
                yield return new Metric { TimeGeneratedUtc = currTime, Name = "edgeagent_total_time_expected_running_seconds", Tags = JsonConvert.SerializeObject(tags), DeviceId = deviceId, Value = 500 * j };
                yield return new Metric { TimeGeneratedUtc = currTime, Name = "edgeagent_total_time_running_correctly_seconds", Tags = JsonConvert.SerializeObject(tags), DeviceId = deviceId, Value = 500 * j * avaliability };
            }
        }
    }
}
