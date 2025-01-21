using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject laserPrefabs;
    public float Fire = 0.5f;
    public float nextFire;

    [SerializeField]
    private int playerLives = 5;

    [SerializeField]
    private int speed = 7;

    [SerializeField]
    private GameObject playerExplosionPrefab;

    [SerializeField]
    private AudioSource soundLaser;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        soundLaser = GetComponent<AudioSource>();
    }

    void Update()
    {
        SpaceMovement();

        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFire)
            {
                soundLaser.Play();
                Instantiate(laserPrefabs, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                nextFire = Time.time + Fire;
            }
        }
    }

    public void LifeSubstraction()
    {
        playerLives--;
        if (playerLives < 1)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void LifeSubstraction2()
    {
        playerLives = playerLives - 5;
        if (playerLives < 1)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SpaceMovement()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verInput);

        if (transform.position.y > 2f)
        {
            transform.position = new Vector3(transform.position.x, 2f, 0);
        }
        else if (transform.position.y < -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x > 9.7f)
        {
            transform.position = new Vector3(-9.7f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.7f)
        {
            transform.position = new Vector3(9.7f, transform.position.y, 0);
        }
    }
}
