using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    public int speed = 4;

    void Update()
    {
        transform.Translate((0.6f * Vector3.down + Vector3.left) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player playerControl = collision.GetComponent<Player>();

            if (playerControl != null)
            {
                playerControl.LifeSubstraction2();
            }
        }
    }
}
