using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp
{
    static class Common
    {
        public static string GetEnvironmentVariable(string name)
        {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
