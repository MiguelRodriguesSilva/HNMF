using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVida : MonoBehaviour
{
    [SerializeField] PlayerMove move;
    [SerializeField] float vidaPlayer;
    [SerializeField] float cdInvuneravel;
    [SerializeField] bool podeTomarDano = true; 

    private void Update() 
    {
        if (vidaPlayer < 1)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Inimigo") && podeTomarDano)
        {
            vidaPlayer--;
            Vector2 direction = (transform.position - other.gameObject.transform.position);
            StartCoroutine(TomouDano(direction));
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo") && podeTomarDano)
        {
            vidaPlayer--;
            Vector2 direction = (transform.position - other.gameObject.transform.position).normalized;
            StartCoroutine(TomouDano(direction));
        }
    }

    IEnumerator TomouDano(Vector2 dir)
    {
        podeTomarDano = false;
        move.KnockBack(dir);
        yield return new WaitForSeconds(cdInvuneravel);
        podeTomarDano = true;
    }
}
