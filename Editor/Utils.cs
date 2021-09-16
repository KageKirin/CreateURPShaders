using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;

namespace KageKirin.CreateURPShaders.Editor
{
    public static class Utils
    {
        public static string ActiveFolderPath
        {
            get {
                MethodInfo getActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
                return (string)getActiveFolderPath.Invoke(null, null);
            }
        }

        public static string ConvertNameToMacro(string name)
        {
            return Regex.Replace(Regex.Replace(name, "(?<=[a-z0-9\\s])[A-Z0-9]+", m => "_" + m.Value).ToUpperInvariant(), "\\s+", "");
        }
    }

} // KageKirin.CreateURPShaders.Editor