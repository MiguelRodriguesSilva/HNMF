using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform player;
    private void FixedUpdate()
    {
        transform.position = player.position;
    }
}
