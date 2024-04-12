using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMagico : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;

    private void Start()
    {
        Vector2 direction = (transform.position - GameObject.FindWithTag("Player").transform.position).normalized;
        rb.velocity = Vector2.right * speed * 10 * direction;   
    }
}
