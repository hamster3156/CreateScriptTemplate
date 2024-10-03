using UnityEditor;
using UnityEngine;

namespace Hamster.Editor
{
    static internal class CreateScriptTemplate
    {
        // テンプレートファイルの名前
        private const string csharpTemplateFileName = "CSharpTemplate";
        private const string monoBehaviourTemplateFileName = "MonoBehaviourTemplate";
        private const string interfaceTemplateFileName = "InterfaceTemplate";
        private const string scriptableObjectTemplateFileName = "ScriptableObjectTemplate";
        private const string dummyTemplateFileName = "DummyTemplate";

        // 作成するスクリプトの名前
        private const string csharpScriptName = "NewCSharpScript.cs";
        private const string monoBehaviourScriptName = "NewMonoBehaviourScript.cs";
        private const string interfaceScriptName = "NewInterfaceScript.cs";
        private const string scriptableObjectScriptName = "NewScriptableObjectScript.cs";
        private const string dummyScriptName = "Dummy.txt";

        // エディタ上に表示させるルート
        private const string menuRoot = "Assets/Create Scripting/";

        // メニューに表示するメソッド
        [MenuItem(menuRoot + "Dummy")]
        private static void CreateDummyFile()
        {
            CreateScriptFile(dummyTemplateFileName, dummyScriptName);
        }

        [MenuItem(menuRoot + "C#")]
        private static void CreateCsharpScript()
        {
            CreateScriptFile(csharpTemplateFileName, csharpScriptName);
        }

        [MenuItem(menuRoot + "MonoBehaviour")]
        private static void CreateMonoBehaviourScript()
        {
            CreateScriptFile(monoBehaviourTemplateFileName, monoBehaviourScriptName);
        }

        [MenuItem(menuRoot + "Interface")]
        private static void CreateInterfaceScript()
        {
            CreateScriptFile(interfaceTemplateFileName, interfaceScriptName);
        }

        [MenuItem(menuRoot + "ScriptableObject")]
        private static void CreateScriptableObjectScript()
        {
            CreateScriptFile(scriptableObjectTemplateFileName, scriptableObjectScriptName);
        }

        /// <summary>
        /// ファイル名を元にファイルパスを取得する
        /// </summary>
        /// <param name="targetFileName">ファイルパスを取得したいファイルの名前</param>
        /// <returns>引き数に入れたファイルのファイルパスが返ってくる</returns>
        private static string GetFilePath(string targetFileName)
        {
            // ファイル名を元にアセットを検索する
            string[] fileNames = AssetDatabase.FindAssets(targetFileName);

            // ファイルが見つからなかった場合は処理を中断する
            if (fileNames.Length == 0)
            {
                Debug.LogWarning("file not found");
                return string.Empty;
            }

            // 見つかったアセットのパスを返す
            return AssetDatabase.GUIDToAssetPath(fileNames[0]);
        }

        /// <summary>
        /// テンプレートファイルを元に新しいスクリプトを作成する
        /// </summary>
        /// <param name="templateFileName">元にするファイル名</param>
        /// <param name="newScriptName">作成するスクリプト名</param>
        private static void CreateScriptFile(string templateFileName, string newScriptName)
        {
            var filePath = GetFilePath(templateFileName);

            if (filePath == null)
            {
                return;
            }

            // テンプレートファイルを元に新しいスクリプトを作成する
            ProjectWindowUtil
                .CreateScriptAssetFromTemplateFile(filePath, newScriptName);
        }
    }
}