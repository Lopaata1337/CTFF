using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VN.Dialogue
{
    /// <summary>
    /// Отвечает за показ диалогов на экране
    /// </summary>
    public class DialogueManager : MonoBehaviour
    {
        [Header("UI элементы")]
        [SerializeField] private TextMeshProUGUI characterNameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Image characterImage;
        [SerializeField] private Button nextButton;

        [Header("Фон")]
        [SerializeField] private SpriteRenderer backgroundRenderer;

        private DialogueSO currentDialogue;

        /// <summary>
        /// Запускает диалог с начального блока
        /// </summary>
        public void StartDialogue(DialogueSO startDialogue)
        {
            currentDialogue = startDialogue;
            DisplayCurrentDialogue();
        }

        /// <summary>
        /// Отображает текущую реплику
        /// </summary>
        private void DisplayCurrentDialogue()
        {
            if (currentDialogue == null)
            {
                Debug.Log("Диалог завершён.");
                return;
            }

            characterNameText.text = currentDialogue.characterName;
            dialogueText.text = currentDialogue.dialogueText;
            characterImage.sprite = currentDialogue.characterSprite;

            if (currentDialogue.backgroundSprite != null && backgroundRenderer != null)
            {
                backgroundRenderer.sprite = currentDialogue.backgroundSprite;
            }

            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(NextDialogue);
        }

        /// <summary>
        /// Переход к следующей реплике
        /// </summary>
        private void NextDialogue()
        {
            currentDialogue = currentDialogue.nextDialogue;
            DisplayCurrentDialogue();
        }
    }
}
