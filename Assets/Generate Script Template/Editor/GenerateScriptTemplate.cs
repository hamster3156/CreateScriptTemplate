using UnityEditor;
using UnityEngine;

namespace hamster.Editor
{
    static internal class GenerateScriptTemplate
    {
        // インターフェースのテンプレートファイル名
        private const string interfaceTemplateFileName = "InterfaceTemplate";

        // 作成するスクリプトの名前
        private const string interfaceScriptName = "New Interface.cs";

        // エディタ上の表示させる項目の名前
        private const string menuRoot = "Create/Add New Script/";

        // エディタに表示される項目の場所と表示名を設定する
        [MenuItem(menuRoot + "Interface")]
        private static void CreateInterfaceScript() => CreateScriptFile(interfaceTemplateFileName, interfaceScriptName);

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