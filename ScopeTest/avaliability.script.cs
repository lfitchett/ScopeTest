using Microsoft.SCOPE.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

public static class AvaliabilityHelper
{

    public static int Hash(params object[] values)
    {
        int hash = 17;
        foreach (object o in values)
        {
            hash = hash * 31 + o.GetHashCode();
        }
        return hash;
    }

    public static Dictionary<string, string> ParseTags(string rawTags)
    {
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(rawTags);
    }
}