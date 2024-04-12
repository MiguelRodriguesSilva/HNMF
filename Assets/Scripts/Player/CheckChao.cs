using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChao : MonoBehaviour
{
    [SerializeField] PlayerMove move;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plataforma"))
        {
            move.podePular = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plataforma"))
        {
            move.podePular = false;
        }
    }


}
