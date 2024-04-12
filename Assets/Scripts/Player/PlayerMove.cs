using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float speed, alturaPulo;
    [SerializeField] public bool podeMover = true, podePular = true;
    [SerializeField] float tempoDash;
    private float moveX;

    private void FixedUpdate() 
    {
        if (podeMover)
        {
            Movimento();
        }

    }

    private void Update()
    {
        if (podePular && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * alturaPulo;
            podePular = false;
        }
    }

    void Movimento()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);


        if (moveX > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }

        if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
