using System.Reflection;
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
    }

} // KageKirin.CreateURPShaders.Editor