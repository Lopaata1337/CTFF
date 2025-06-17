using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;       // ��� ���������
    public TextMeshProUGUI dialogueText;   // ����� �������
    public Button nextButton;               // ������ �����

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public string sentence;
    }

    public DialogueLine[] dialogueLines;   // ������ ��������

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
        // ������ ������ ��� ��������� UI
        nameText.text = "";
        dialogueText.text = "";
        nextButton.gameObject.SetActive(false);
        Debug.Log("������ �������");
    }
}
