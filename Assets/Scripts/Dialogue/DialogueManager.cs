using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VN.Dialogue
{
    /// <summary>
    /// �������� �� ����� �������� �� ������
    /// </summary>
    public class DialogueManager : MonoBehaviour
    {
        [Header("UI ��������")]
        [SerializeField] private TextMeshProUGUI characterNameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Image characterImage;
        [SerializeField] private Button nextButton;

        [Header("���")]
        [SerializeField] private SpriteRenderer backgroundRenderer;

        private DialogueSO currentDialogue;

        /// <summary>
        /// ��������� ������ � ���������� �����
        /// </summary>
        public void StartDialogue(DialogueSO startDialogue)
        {
            currentDialogue = startDialogue;
            DisplayCurrentDialogue();
        }

        /// <summary>
        /// ���������� ������� �������
        /// </summary>
        private void DisplayCurrentDialogue()
        {
            if (currentDialogue == null)
            {
                Debug.Log("������ ��������.");
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
        /// ������� � ��������� �������
        /// </summary>
        private void NextDialogue()
        {
            currentDialogue = currentDialogue.nextDialogue;
            DisplayCurrentDialogue();
        }
    }
}
