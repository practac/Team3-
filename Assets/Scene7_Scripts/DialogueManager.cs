using System.Collections; // 이 줄이 필요합니다.
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // UI Text 컴포넌트를 연결

    public void ShowDialogue(string message)
    {
        if (dialogueText != null)
        {

            dialogueText.text = message;
            
            // 대화창을 일정 시간 후에 숨기려면 Coroutine 등을 사용해 추가 구현 가능
            StartCoroutine(HideDialogueAfterSeconds(2));
        }
        else
        {
            Debug.LogWarning("Dialogue Text is not assigned!");
        }
    }

    private IEnumerator HideDialogueAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialogueText.text = null; 
    }
}
