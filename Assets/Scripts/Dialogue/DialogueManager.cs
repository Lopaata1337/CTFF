using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VN.Dialogue;

namespace VN.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [Header("UI элементы")]
        [SerializeField] private TextMeshProUGUI characterNameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Image characterImage;
        [SerializeField] private Button nextButton;

        [Header("Фон")]
        [SerializeField] private SpriteRenderer backgroundRenderer;

        [Header("Выборы")]
        [SerializeField] private GameObject choicePanel;
        [SerializeField] private Button[] choiceButtons;

        private DialogueSO currentDialogue;

        public void StartDialogue(DialogueSO startDialogue)
        {
            currentDialogue = startDialogue;
            DisplayCurrentDialogue();
        }

        private void DisplayCurrentDialogue()
        {
            if (currentDialogue == null)
            {
                Debug.Log("Диалог завершён.");
                ClearUI();
                return;
            }

            characterNameText.text = currentDialogue.characterName;
            dialogueText.text = currentDialogue.dialogueText;
            characterImage.sprite = currentDialogue.characterSprite;

            if (backgroundRenderer != null && currentDialogue.backgroundSprite != null)
            {
                backgroundRenderer.sprite = currentDialogue.backgroundSprite;
            }

            if (currentDialogue.choices != null && currentDialogue.choices.Length > 0)
            {
                ShowChoices();
            }
            else
            {
                HideChoices();
                ShowNextButton();
            }
        }

        private void ClearUI()
        {
            dialogueText.text = "";
            characterNameText.text = "";
            characterImage.sprite = null;
            nextButton.gameObject.SetActive(false);
            choicePanel.SetActive(false);
        }

        private void ShowNextButton()
        {
            nextButton.gameObject.SetActive(true);
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(NextDialogue);
        }

        private void HideChoices()
        {
            choicePanel.SetActive(false);

            foreach (var btn in choiceButtons)
            {
                btn.gameObject.SetActive(false);
                btn.onClick.RemoveAllListeners();
            }
        }

        private void NextDialogue()
        {
            currentDialogue = currentDialogue.nextDialogue;
            DisplayCurrentDialogue();
        }

        private void ShowChoices()
        {
            nextButton.gameObject.SetActive(false);
            choicePanel.SetActive(true);

            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < currentDialogue.choices.Length)
                {
                    var btn = choiceButtons[i];
                    btn.gameObject.SetActive(true);

                    var choice = currentDialogue.choices[i];
                    var btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
                    if (btnText != null) btnText.text = choice.choiceText;

                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(() =>
                    {
                        currentDialogue = choice.nextDialogue;
                        DisplayCurrentDialogue();
                    });
                }
                else
                {
                    choiceButtons[i].gameObject.SetActive(false);
                    choiceButtons[i].onClick.RemoveAllListeners();
                }
            }
        }
    }
}
