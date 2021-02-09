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

    /*
    void PaintParabola()
    {
        for(int i=0; i<numberOfPoints; i++)
        {
            points[i].transform.position = GetPointPosition(i * 1f);
            Debug.Log(i);
            Debug.Log(GetPointPosition(i));
        }
    }

    Vector2 GetPointPosition(float n)
    {
        float distance = direction.x;
        float angle = Vector2.Angle(direction, transform.right) * Mathf.PI / 180;
        float v0 = Mathf.Sqrt(distance * 10 / (Mathf.Sin(angle)));
        float maxh = v0 * v0 * Mathf.Sin(angle) / 20;

        Debug.Log("v0" + v0);

        float xx = v0 * Mathf.Cos(angle) * n;
        float yy = v0 * Mathf.Sin(angle) * n - (10 * n * n / 2);

        float x = transform.position.x + (n * distance / (float)numberOfPoints);
        float y = transform.position.y + (n * maxh / (float)numberOfPoints);
        if (n > numberOfPoints / 2)
        {
            y = maxh/2 - (n * maxh / (float)numberOfPoints);
        }

        return new Vector2(x, y);
    }
    */
}
