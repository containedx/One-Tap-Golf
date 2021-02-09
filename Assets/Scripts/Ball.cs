using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    public void ThrowBall(Vector2 v)
    {
        rb.AddForce(v);
    }
}
