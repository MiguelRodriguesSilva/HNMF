using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInteligence : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Animator anim;
    [SerializeField] bool escolhendo, seguir = true;

    void Update()
    {
        if (escolhendo == false)
        {
            escolhendo = true;
            StartCoroutine(Escolhas());
        }
    }

    IEnumerator Escolhas()
    {
        yield return new WaitForSeconds(Random.Range(3f,4f));

        Escolheu(Random.Range(1,3));
    }

    void Escolheu(int e)
    {
        switch(e)
        {
            
            case 1:
                anim.Play("AtaqueNormal");
                escolhendo = false;
                break;

            case 2:
                anim.Play("CaindoCoisa");
                escolhendo = false;
            break;
        }
    }


}
