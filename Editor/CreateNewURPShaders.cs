using System.Reflection;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace KageKirin.CreateURPShaders.Editor
{
    public class CreateNewURPShaders : MonoBehaviour
    {
        public static string ActiveFolderPath
        {
            get {
                MethodInfo getActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
                return (string)getActiveFolderPath.Invoke(null, null);
            }
        }

        [MenuItem("Assets/Create/Shader/Universal Render Pipeline/New Lit Shader")] static void CreateNewLitShader()
        {
            Shader shader        = Shader.Find("Universal Render Pipeline/Lit");
            string shaderPath    = AssetDatabase.GetAssetPath(shader);
            string newShaderPath = AssetDatabase.GenerateUniqueAssetPath($"{CreateNewURPShaders.ActiveFolderPath}/NewLit.shader");
            string newShaderName = Path.GetFileNameWithoutExtension(newShaderPath);

            string shaderSource    = File.ReadAllText(shaderPath);
            string newShaderSource = shaderSource.Replace("Universal Render Pipeline/Lit", $"Universal Render Pipeline/{newShaderName}");
            ProjectWindowUtil.CreateAssetWithContent(newShaderPath, newShaderSource, (Texture2D)AssetDatabase.GetCachedIcon(shaderPath));
        }

        [MenuItem("Assets/Create/Shader/Universal Render Pipeline/New Simple Lit Shader")]
        static void CreateNewSimpleLitShader()
        {
            Shader shader        = Shader.Find("Universal Render Pipeline/Simple Lit");
            string shaderPath    = AssetDatabase.GetAssetPath(shader);
            string newShaderPath = AssetDatabase.GenerateUniqueAssetPath($"{CreateNewURPShaders.ActiveFolderPath}/NewSimpleLit.shader");
            string newShaderName = Path.GetFileNameWithoutExtension(newShaderPath);

            string shaderSource    = File.ReadAllText(shaderPath);
            string newShaderSource = shaderSource.Replace("Universal Render Pipeline/Simple Lit", $"Universal Render Pipeline/{newShaderName}");
            ProjectWindowUtil.CreateAssetWithContent(newShaderPath, newShaderSource, (Texture2D)AssetDatabase.GetCachedIcon(shaderPath));
        }

        [MenuItem("Assets/Create/Shader/Universal Render Pipeline/New Empty Shader")]
        static void CreateNewEmptyShader()
        {
            Shader shader     = Shader.Find("Universal Render Pipeline/Lit");
            string shaderPath = AssetDatabase.GetAssetPath(shader);

            string newShaderPath = AssetDatabase.GenerateUniqueAssetPath($"{CreateNewURPShaders.ActiveFolderPath}/NewEmpty.shader");
            string newShaderName = Path.GetFileNameWithoutExtension(newShaderPath);

            string shaderSource    = @"// This shader fills the mesh shape with a color predefined in the code.
Shader ""Example/URPUnlitShaderBasic""
{
    // The properties block of the Unity shader. In this example this block is empty
    // because the output color is predefined in the fragment shader code.
    Properties
    { }

    // The SubShader block containing the Shader code.
    SubShader
    {
        // SubShader Tags define when and under which conditions a SubShader block or
        // a pass is executed.
        Tags { ""RenderType"" = ""Opaque"" ""RenderPipeline"" = ""UniversalPipeline"" }

        Pass
        {
            // The HLSL code block. Unity SRP uses the HLSL language.
            HLSLPROGRAM
            // This line defines the name of the vertex shader.
            #pragma vertex vert
            // This line defines the name of the fragment shader.
            #pragma fragment frag

            // The Core.hlsl file contains definitions of frequently used HLSL
            // macros and functions, and also contains #include references to other
            // HLSL files (for example, Common.hlsl, SpaceTransforms.hlsl, etc.).
            #include ""Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl""

            // The structure definition defines which variables it contains.
            // This example uses the Attributes structure as an input structure in
            // the vertex shader.
            struct Attributes
            {
                // The positionOS variable contains the vertex positions in object
                // space.
                float4 positionOS   : POSITION;
            };

            struct Varyings
            {
                // The positions in this struct must have the SV_POSITION semantic.
                float4 positionHCS  : SV_POSITION;
            };

            // The vertex shader definition with properties defined in the Varyings
            // structure. The type of the vert function must match the type (struct)
            // that it returns.
            Varyings vert(Attributes IN)
            {
                // Declaring the output object (OUT) with the Varyings struct.
                Varyings OUT;
                // The TransformObjectToHClip function transforms vertex positions
                // from object space to homogenous clip space.
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                // Returning the output.
                return OUT;
            }

            // The fragment shader definition.
            half4 frag() : SV_Target
            {
                // Defining the color variable and returning it.
                half4 customColor = half4(0.5, 0, 0, 1);
                return customColor;
            }
            ENDHLSL
        }
    }
}
";
            string newShaderSource = shaderSource.Replace("Example/URPUnlitShaderBasic", $"Universal Render Pipeline/{newShaderName}");
            ProjectWindowUtil.CreateAssetWithContent(newShaderPath, newShaderSource, (Texture2D)AssetDatabase.GetCachedIcon(shaderPath));
        }
    }
} // KageKirin.CreateURPShaders.Editor
