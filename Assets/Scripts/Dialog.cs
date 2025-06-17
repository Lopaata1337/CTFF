using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;       // Имя персонажа
    public TextMeshProUGUI dialogueText;   // Текст диалога
    public Button nextButton;               // Кнопка Далее

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public string sentence;
    }

    public DialogueLine[] dialogueLines;   // Массив диалогов

    private int currentLineIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(NextLine);
        ShowLine(currentLineIndex);
    }

    void ShowLine(int index)
    {
        if (index < dialogueLines.Length)
        {
            nameText.text = dialogueLines[index].speakerName;
            dialogueText.text = dialogueLines[index].sentence;
        }
        else
        {
            EndDialogue();
        }
    }

    public void NextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            ShowLine(currentLineIndex);
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        // Скрыть панель или отключить UI
        nameText.text = "";
        dialogueText.text = "";
        nextButton.gameObject.SetActive(false);
        Debug.Log("Диалог окончен");
    }
}
