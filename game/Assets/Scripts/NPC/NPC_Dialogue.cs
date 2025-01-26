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

    private Player player;
    private NPC npc;


    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        npc = GetComponent<NPC>();
        GetNPCInfo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && playerHit)
        {
            CheckPlayerDirection();
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;

                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }

        }
    }

    // usado pela física
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            //DialogueControl.instance.dialogueObj.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

    // ESSA PORRA ALTERA CERTO, MAS NAO MANTEM!!!!
    // logica para mudar o lado do npc na direção do player, corrigir
    public void CheckPlayerDirection()
    {

        Vector2 playerDirection = player.transform.position - transform.position;
        Vector2 npcDirection = npc.currentDirection;

        if (playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            
        }
    }

}