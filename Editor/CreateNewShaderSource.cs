using System;
using System.Reflection;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace KageKirin.CreateURPShaders.Editor
{
    public class CreateNewShaderSources : MonoBehaviour
    {
        private static string GetShaderSource(string name)
        {
            string macro = Utils.ConvertNameToMacro(name);

            // return a regular include guard, b/c #pragma once is not supported.
            return $"#ifndef {macro}\n" + $"#define {macro}\n\n" + $"#endif // {macro}\n";
        }

        [MenuItem("Assets/Create/Shader/New Shader Source (HLSL)")]
        static void CreateNewHLSL()
        {
            string newShaderPath = AssetDatabase.GenerateUniqueAssetPath($"{Utils.ActiveFolderPath}/NewShaderLib.hlsl");
            string newShaderName = Path.GetFileNameWithoutExtension(newShaderPath);

            ProjectWindowUtil.CreateAssetWithContent(newShaderPath, GetShaderSource(newShaderName), AssetPreview.GetMiniTypeThumbnail(typeof(TextAsset)));
        }

        [MenuItem("Assets/Create/Shader/New Shader Source (GLSL)")]
        static void CreateNewGLSL()
        {
            string newShaderPath = AssetDatabase.GenerateUniqueAssetPath($"{Utils.ActiveFolderPath}/NewShaderLib.glsl");
            string newShaderName = Path.GetFileNameWithoutExtension(newShaderPath);

            ProjectWindowUtil.CreateAssetWithContent(newShaderPath, GetShaderSource(newShaderName), AssetPreview.GetMiniTypeThumbnail(typeof(TextAsset)));
        }
    }
} // namespace KageKirin.CreateURPShaders.Editor
