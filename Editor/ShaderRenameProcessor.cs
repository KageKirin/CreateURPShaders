using System.Reflection;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace KageKirin.CreateURPShaders.Editor
{
    public class ShaderRenameProcessor : UnityEditor.AssetModificationProcessor
    {
        private static AssetMoveResult OnWillMoveAsset(string sourcePath, string targetPath)
        {
            string sourceFileExt = Path.GetExtension(sourcePath);

            if (sourceFileExt != ".shader")
            {
                return AssetMoveResult.DidNotMove;
            }

            // get shader (file) name
            string sourceName = Path.GetFileNameWithoutExtension(sourcePath);
            string targetName = Path.GetFileNameWithoutExtension(targetPath);

            // replace the shader at source level before moving
            // !! potentially risky renaming here, as it will affect variables, types, functions that match
            string shaderSource = File.ReadAllText(sourcePath);
            File.WriteAllText(sourcePath, shaderSource.Replace(sourceName, targetName));

            // leave the asset moving to Unity
            return AssetMoveResult.DidNotMove;
        }
    }
} // namespace KageKirin.CreateURPShaders.Editor
