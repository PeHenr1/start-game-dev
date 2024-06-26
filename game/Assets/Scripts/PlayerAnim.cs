using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private bool facingPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }

            // Atualiza a direção que o jogador está olhando
            if (player.direction.x > 0)
            {
                facingPosition = true;
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (player.direction.x < 0)
            {
                facingPosition = false;
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
            // Mantém a direção anterior quando parado
            if (facingPosition)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion
}
