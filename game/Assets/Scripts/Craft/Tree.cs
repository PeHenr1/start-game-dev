using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHP;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    public void OnHit()
    {
        treeHP--;

        anim.SetTrigger("isHit");

        if(treeHP <= 0)
        {
            // cria o toco e instancia drops
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);

            }
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
