using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static class Logger
{
    public static void LogPretty(string message)
    {
        Debug.Log($"[{DateTime.Now.ToLocalTime()}] [Better Mission Editor] " + message);
    }
}

