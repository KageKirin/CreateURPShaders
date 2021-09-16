using System;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;

public class CreateNewShaderSources : MonoBehaviour
{
    public static string ActiveFolderPath
    {
        get
        {
            MethodInfo getActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("GetActiveFolderPath",
                BindingFlags.Static | BindingFlags.NonPublic);
            return (string) getActiveFolderPath.Invoke(null, null);
        }
    }

    private static string ConvertNameToMacro(string name)
    {
        return Regex.Replace(
            Regex.Replace(
                name,
                "(?<=[a-z0-9\\s])[A-Z0-9]+",
                m => "_" + m.Value)
            .ToUpperInvariant(),
            "\\s+", "");
    }

    private static string GetShaderSource(string name)
    {
        string macro = ConvertNameToMacro(name);

        // return a regular include guard, b/c #pragma once is not supported.
        return $"#ifndef {macro}\n"
             + $"#define {macro}\n\n"
             + $"#endif // {macro}\n";
    }

    [MenuItem("Assets/Create/Shader/New Shader Source (HLSL)")]
    static void CreateNewHLSL()
    {
        string newShaderPath = AssetDatabase.GenerateUniqueAssetPath($"{CreateNewURPShaders.ActiveFolderPath}/NewShaderLib.hlsl");
        string newShaderName = Path.GetFileNameWithoutExtension(newShaderPath);

        ProjectWindowUtil.CreateAssetWithContent(newShaderPath, GetShaderSource(newShaderName), AssetPreview.GetMiniTypeThumbnail(typeof(TextAsset)));
    }

    [MenuItem("Assets/Create/Shader/New Shader Source (GLSL)")]
    static void CreateNewGLSL()
    {
        string newShaderPath = AssetDatabase.GenerateUniqueAssetPath($"{CreateNewURPShaders.ActiveFolderPath}/NewShaderLib.glsl");
        string newShaderName = Path.GetFileNameWithoutExtension(newShaderPath);

        ProjectWindowUtil.CreateAssetWithContent(newShaderPath, GetShaderSource(newShaderName), AssetPreview.GetMiniTypeThumbnail(typeof(TextAsset)));
    }
}
