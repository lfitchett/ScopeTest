using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;
using Newtonsoft.Json;

public static class PersistHelper
{
    public static int GetMetricKey(string name, string tags)
    {
        int hash = 17;
        hash = hash * 31 + name.GetHashCode();
        hash = hash * 31 + tags.GetHashCode();

        return hash;
    }

    public static string StripTags(string rawTags)
    {
        Dictionary<string, string> tags = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawTags);
        tags.Remove("ms_telemetry");
        tags.Remove("instance");

        return JsonConvert.SerializeObject(tags);
    }
}