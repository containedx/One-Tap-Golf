using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    void Start()
    {
        SetRandomPosition();
    }

    public void SetRandomPosition()
    {
        //Random Hole Position in Right Part Of Screen
        transform.position = new Vector3(Random.Range(0f, 6.8f), transform.position.y, transform.position.z);
    }
}
