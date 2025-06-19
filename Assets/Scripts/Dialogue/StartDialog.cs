using UnityEngine;

namespace VN.Dialogue
{
    public class DialogueStarter : MonoBehaviour
    {
        [Tooltip("Список стартовых диалогов по порядку")]
        public DialogueSO[] startDialogues;

        public DialogueManager dialogueManager;
        private int currentIndex = 0;

        void Start()
        {
            if (startDialogues.Length > 0)
                dialogueManager.StartDialogue(startDialogues[0]);
        }

        // Можно вызывать извне, если хочешь переключаться вручную
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
