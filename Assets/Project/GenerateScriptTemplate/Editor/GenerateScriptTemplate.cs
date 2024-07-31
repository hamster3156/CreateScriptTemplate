using UnityEditor;
using UnityEngine;

namespace hamster.Editor
{
    static internal class GenerateScriptTemplate
    {
        // �C���^�[�t�F�[�X�̃e���v���[�g�t�@�C����
        private const string interfaceTemplateFileName = "InterfaceTemplate";

        // �쐬����X�N���v�g�̖��O
        private const string interfaceScriptName = "New Interface.cs";

        // �G�f�B�^��̕\�������鍀�ڂ̖��O
        private const string menuRoot = "Create/Add New Script/";

        // �G�f�B�^�ɕ\������鍀�ڂ̏ꏊ�ƕ\������ݒ肷��
        [MenuItem(menuRoot + "Interface")]
        private static void CreateInterfaceScript() => CreateScriptFile(interfaceTemplateFileName, interfaceScriptName);

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