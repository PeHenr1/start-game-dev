using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite;    //sprite do perfil
    public Text speechText;        //texto da fala
    public Text actorNameText;     //nome do npc


    [Header("Settings")]
    public float typingSpeed;      //velocidade da fala

    // Control variables
    private bool isShowing;        //se janela est� vis�vel
    private int index;             //indice das falas
    private string[] sentences;


    public static DialogueControl instance;

    // awake - chamado antes de todos os start() na hierarquia de execu��o de scripts
    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // pular pra pr�xima frase (bot�o)
    public void NextSentence()
    {
        if(speechText.text == sentences[index]) 
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //quando termina os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
            }
        }
    }

    // chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
