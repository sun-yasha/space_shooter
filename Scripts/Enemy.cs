using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int speed = 3;

    [SerializeField]
    private GameObject enemyExplosionPrefab;

    [SerializeField]
    private AudioClip enemySound;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6.7)
        {
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemySound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.LifeSubstraction();
            }
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemySound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
