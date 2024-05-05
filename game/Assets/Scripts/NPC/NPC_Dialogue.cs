using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    bool playerHit;
    private List<string> sentences = new List<string>();
    

    void Start()
    {
        GetNPCInfo();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++) {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }

    // usado pela f�sica
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue() 
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;   
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
