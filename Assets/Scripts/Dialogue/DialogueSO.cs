using UnityEngine;

namespace VN.Dialogue
{
    /// <summary>
    /// ScriptableObject, описывающий одну реплику диалога
    /// </summary>
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "VN/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        public string characterName;                     // Имя персонажа
        [TextArea(3, 10)]
        public string dialogueText;                      // Текст реплики
        public Sprite characterSprite;                   // Спрайт персонажа
        public AudioClip voiceLine;                      // Звук реплики
        public DialogueSO nextDialogue;                  // Следующая реплика

        [Header("Фон (по желанию)")]
        public Sprite backgroundSprite;                  // Фон для этой реплики
    }
}
