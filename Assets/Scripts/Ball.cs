using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject PointPrefab;

    public float force;

    Vector2 direction;

    
    void Update()
    {
        if(Input.GetButton("Fire1")) //if LMB clicked
        {
            PaintParabola();
            IncreaseForce();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ThrowBall();
            Debug.Log("throw");
        }
    }

    void ThrowBall()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)transform.position;

        rb.AddForce(direction * force);
    }

    void IncreaseForce()
    {
        force += 1;
    }

    void PaintParabola()
    {

    }

    Vector2 GetPointPosition(float x)
    {
        return Vector2.zero;
    }
}
