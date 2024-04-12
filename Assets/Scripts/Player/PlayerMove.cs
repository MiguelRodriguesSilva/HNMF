using System.Collections;
using System.Collections.Generic;
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

    public void KnockBack(Vector2 direction)
    {
        StartCoroutine(KB(direction));
    }

    IEnumerator KB(Vector2 dir)
    {
        podeMover = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(dir * new Vector2(1, 0.1f) * 5f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        podeMover = true;
    }
}
