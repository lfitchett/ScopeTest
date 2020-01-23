using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;

public static class PersistHelper
{
    //public static string StripTags(string rawTags)
    //{
    //    try
    //    {
    //        Dictionary<string, string> tags = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawTags);
    //        tags.Remove("ms_telemetry");

    //        return JsonConvert.SerializeObject(tags);
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}

    //public static string GenerateDeviceId(string cloud, string iothub, string deviceName)
    //{
    //    string deviceHash = string.Concat(sHA256.ComputeHash(Encoding.UTF8.GetBytes(deviceName)).Select(b => b.ToString("x2")));

    //    return string.Format("{0}/{1}/{2}", cloud, iothub, deviceHash);
    //}
}