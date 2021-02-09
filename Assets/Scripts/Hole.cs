using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(Random.Range(-6.8f, 6.8f), transform.position.y, transform.position.z);
    }
}
