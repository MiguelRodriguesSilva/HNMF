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

    private void Start()
    {
        posDestino = posA.transform.position;
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(posA.transform.position, transform.position) < 0.1f)
        {
            posDestino = posB.transform.position;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Vector2.Distance(posB.transform.position, transform.position) < 0.1f)
        {
            posDestino = posA.transform.position; 
            transform.eulerAngles = Vector3.zero;
        }

        direction = (posDestino - transform.position).normalized;

        rb.velocity = direction * speed * Vector2.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ataque"))
        {
            Destroy(gameObject);
        }
    }
}
