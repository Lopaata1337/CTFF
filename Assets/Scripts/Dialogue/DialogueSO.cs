using UnityEngine;

namespace VN.Dialogue
{
    /// <summary>
    /// ScriptableObject, ����������� ���� ������� ������� � ���������� ������
    /// </summary>
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "VN/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        public string characterName;                     // ��� ���������
        [TextArea(3, 10)]
        public string dialogueText;                      // ����� �������
        public Sprite characterSprite;                   // ������ ���������
        public AudioClip voiceLine;                      // ���� �������
        public DialogueSO nextDialogue;                  // ��������� ������� (���� ��� ������)

        [Header("��� (�� �������)")]
        public Sprite backgroundSprite;                  // ��� ��� ���� �������

        [Header("������")]
        public Choice[] choices;                          // �������� ������

        [System.Serializable]
        public class Choice
        {
            public string choiceText;                     // ����� ��������
            public DialogueSO nextDialogue;               // ��������� ������� ��� ������ ����� ��������
        }
    }
}
