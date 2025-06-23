using UnityEngine;

namespace VN.Dialogue
{
    /// <summary>
    /// ScriptableObject, описывающий одну реплику диалога с поддержкой выбора
    /// </summary>
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "VN/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        public string characterName;                     // Имя персонажа
        [TextArea(3, 10)]
        public string dialogueText;                      // Текст реплики
        public Sprite characterSprite;                   // Спрайт персонажа
        public AudioClip voiceLine;                      // Звук реплики
        public DialogueSO nextDialogue;                  // Следующая реплика (если нет выбора)

        [Header("Фон (по желанию)")]
        public Sprite backgroundSprite;                  // Фон для этой реплики

        [Header("Выборы")]
        public Choice[] choices;                          // Варианты выбора

        [System.Serializable]
        public class Choice
        {
            public string choiceText;                     // Текст варианта
            public DialogueSO nextDialogue;               // Следующая реплика при выборе этого варианта
        }
    }
}
