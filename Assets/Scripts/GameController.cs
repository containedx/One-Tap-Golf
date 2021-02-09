using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Ball ball;

    public GameObject pointPrefab;

    [SerializeField]
    int numberOfPoints;
    GameObject[] points;
    [SerializeField]
    float timeRate;

    [SerializeField]
    float force;

    Vector2 start;
    Vector2 end;
    Vector2 direction;
    Vector2 v;
    float distance;

    void Start()
    {
        points = new GameObject[numberOfPoints];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //if LMB clicked
        {
            InstantiatePosition();
        }
        if (Input.GetButton("Fire1"))
        {
            Pointing();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Throw();
        }
    }


    void InstantiatePosition()
    {
        start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        InstantiatePoints();
    }

    void Pointing()
    {
        end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(start, end);
        direction = (start - end).normalized;
        v = direction * distance * force;

        IncreaseForce();
        CalculatePositions();
    }

    void Throw()
    {
        ball.ThrowBall(v);
        force = 10; //back to initial force
    }

    void CalculatePositions()
    {
        var t = timeRate;
        for(int i=0; i < numberOfPoints; i++)
        {
            var x = ball.transform.position.x + v.x * t;
            var y = (ball.transform.position.y + v.y * t) - (Physics2D.gravity.magnitude * t * t) / 2f;

            points[i].transform.position = new Vector2(x, y);
            t += timeRate;
        }
    }

    void InstantiatePoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        }
    }

    void IncreaseForce()
    {
        force += 0.1f;
    }
}
