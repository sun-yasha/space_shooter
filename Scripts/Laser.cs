using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int speed = 7;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y >= 5.7)
        {
            Destroy(this.gameObject, 0.5f);
        }
        
    }
}
