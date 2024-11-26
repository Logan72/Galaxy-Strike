using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] lines;
    [SerializeField] TMP_Text dialogueTMP;
    int currentLineNumber = 0;

    void Start()
    {
        dialogueTMP.text = lines[currentLineNumber];
    }
    public void ShowNextLine()
    {
        dialogueTMP.text = lines[++currentLineNumber];
    }
}
