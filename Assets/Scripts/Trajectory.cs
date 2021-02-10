using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public GameObject trajectory; 
    public GameObject pointPrefab;

    [SerializeField]
    int numberOfPoints;
    GameObject[] points;
    [SerializeField]
    float timeRate;


    // Start is called before the first frame update
    void Start()
    {
        InstantiatePoints();
    }

    public void Active(bool b)
    {
        trajectory.SetActive(b);
    }

    public void CalculatePositions(Ball ball, Vector2 v)
    {
        var t = timeRate;
        for (int i = 0; i < numberOfPoints; i++)
        {
            var x = ball.transform.position.x + v.x * t;
            var y = (ball.transform.position.y + v.y * t) - (10 * t * t) / 2f;

            points[i].transform.position = new Vector2(x, y);
            t += timeRate;
        }
    }

    void InstantiatePoints()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
            points[i].transform.parent = trajectory.transform;
        }
        Active(false);
    }
}
