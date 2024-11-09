using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


    
public class Collision : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_DialogueBox; 
    [SerializeField] private TextMeshProUGUI txt_Dialogue; 
    private Rigidbody2D rigidbody2D; 
    private void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    public void ShowSingleMessage()
    {
        
        Debug.Log("ShowSingleMessage called");
        
        sprite_DialogueBox.gameObject.SetActive(true);
        
        txt_Dialogue.gameObject.SetActive(true);
        
        txt_Dialogue.text = "어디선가 동물의 울음소리가 들린다";
        StartCoroutine(HideMessageAfterDelay(1.0f)); // Hide after 1 second

        
    }
     private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
         sprite_DialogueBox.gameObject.SetActive(false);
        
        txt_Dialogue.gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
    
     ShowSingleMessage();

    }
}
    

