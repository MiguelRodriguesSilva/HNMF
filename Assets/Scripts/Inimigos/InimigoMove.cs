using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform posA, posB;
    [SerializeField] Vector3 posDestino;
    [SerializeField] float speed;
    [SerializeField] Vector2 direction;
    [SerializeField] int vidaInimigo = 3;

    [SerializeField] bool podeMover = true;

    private void Start()
    {
        posDestino = posA.transform.position;
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(posA.transform.position, transform.position) < 1f)
        {
            posDestino = posB.transform.position;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Vector2.Distance(posB.transform.position, transform.position) < 1f)
        {
            posDestino = posA.transform.position; 
            transform.eulerAngles = Vector3.zero;
        }

        direction = (posDestino - transform.position).normalized;

        if (podeMover)
        {
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
        

        if (vidaInimigo < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ataque"))
        {
            vidaInimigo--;
            Vector2 direction = (collision.gameObject.transform.position - transform.position).normalized;
            KnockBack(direction);
        }
    }

    void KnockBack(Vector2 direction)
    {
        StartCoroutine(KB(direction));
    }

    IEnumerator KB(Vector2 dir)
    {
        podeMover = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(dir * new Vector2(1, 0.3f) * 5f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        podeMover = true;
    }
}
