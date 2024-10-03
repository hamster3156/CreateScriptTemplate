using UnityEditor;
using UnityEngine;

namespace Hamster.Editor
{
    static internal class CreateScriptTemplate
    {
        // �e���v���[�g�t�@�C���̖��O
        private const string csharpTemplateFileName = "CSharpTemplate";
        private const string monoBehaviourTemplateFileName = "MonoBehaviourTemplate";
        private const string interfaceTemplateFileName = "InterfaceTemplate";
        private const string scriptableObjectTemplateFileName = "ScriptableObjectTemplate";
        private const string dummyTemplateFileName = "DummyTemplate";

        // �쐬����X�N���v�g�̖��O
        private const string csharpScriptName = "NewCSharpScript.cs";
        private const string monoBehaviourScriptName = "NewMonoBehaviourScript.cs";
        private const string interfaceScriptName = "NewInterfaceScript.cs";
        private const string scriptableObjectScriptName = "NewScriptableObjectScript.cs";
        private const string dummyScriptName = "Dummy.txt";

        // �G�f�B�^��ɕ\�������郋�[�g
        private const string menuRoot = "Assets/Create Scripting/";

        // ���j���[�ɕ\�����郁�\�b�h
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
        /// �t�@�C���������Ƀt�@�C���p�X���擾����
        /// </summary>
        /// <param name="targetFileName">�t�@�C���p�X���擾�������t�@�C���̖��O</param>
        /// <returns>�������ɓ��ꂽ�t�@�C���̃t�@�C���p�X���Ԃ��Ă���</returns>
        private static string GetFilePath(string targetFileName)
        {
            // �t�@�C���������ɃA�Z�b�g����������
            string[] fileNames = AssetDatabase.FindAssets(targetFileName);

            // �t�@�C����������Ȃ������ꍇ�͏����𒆒f����
            if (fileNames.Length == 0)
            {
                Debug.LogWarning("file not found");
                return string.Empty;
            }

            // ���������A�Z�b�g�̃p�X��Ԃ�
            return AssetDatabase.GUIDToAssetPath(fileNames[0]);
        }

        /// <summary>
        /// �e���v���[�g�t�@�C�������ɐV�����X�N���v�g���쐬����
        /// </summary>
        /// <param name="templateFileName">���ɂ���t�@�C����</param>
        /// <param name="newScriptName">�쐬����X�N���v�g��</param>
        private static void CreateScriptFile(string templateFileName, string newScriptName)
        {
            var filePath = GetFilePath(templateFileName);

            if (filePath == null)
            {
                return;
            }

            // �e���v���[�g�t�@�C�������ɐV�����X�N���v�g���쐬����
            ProjectWindowUtil
                .CreateScriptAssetFromTemplateFile(filePath, newScriptName);
        }
    }
}