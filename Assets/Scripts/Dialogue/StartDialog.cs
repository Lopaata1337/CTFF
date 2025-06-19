using UnityEngine;

namespace VN.Dialogue
{
    public class DialogueStarter : MonoBehaviour
    {
        [Tooltip("������ ��������� �������� �� �������")]
        public DialogueSO[] startDialogues;

        public DialogueManager dialogueManager;
        private int currentIndex = 0;

        void Start()
        {
            if (startDialogues.Length > 0)
                dialogueManager.StartDialogue(startDialogues[0]);
        }

        // ����� �������� �����, ���� ������ ������������� �������
        public void StartNextDialogue()
        {
            currentIndex++;
            if (currentIndex < startDialogues.Length)
            {
                dialogueManager.StartDialogue(startDialogues[currentIndex]);
            }
        }
    }
}
