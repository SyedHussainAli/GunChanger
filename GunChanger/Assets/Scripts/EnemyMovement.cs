using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 Direction;
    private float speed = 2;
    private GameObject player;
    private Rigidbody EnemyRb;
    private Vector3 awayDirection;
    private int health = 150;
    private bool hitWithBullet=false;//for checking if Enemy was hit by bullet

    public AudioClip crashSound;
    private AudioSource CrashAudio;

    public GameObject enemyPf;
    private float spawnRange = 15;
    private bool spawner = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        EnemyRb = GetComponent<Rigidbody>();

        CrashAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Direction = (player.transform.position - transform.position).normalized;
        transform.Translate(Direction * speed * Time.deltaTime);
        if(health<1&&spawner)
        {
            player.GetComponent<PlayerController>().enemyKilled++;
            StartCoroutine(SpawnEnemyOnSpot());
            spawner = false;
        }

    }

    IEnumerator SpawnEnemyOnSpot()
    {
       
        yield return new WaitForSeconds(0);
        Instantiate(enemyPf, GenerateRandomPosition(), enemyPf.transform.rotation);
        Destroy(gameObject);

    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomRange = new Vector3(spawnPosX, 0.6f, spawnPosZ);



        return randomRange;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet1"))
        {
            health -= 40;
            Debug.Log("Enemy Health is: "+health);
            Destroy(collision.gameObject);
            awayDirection = (transform.position-player.transform.position).normalized;
            EnemyRb.AddForce(awayDirection * 30,ForceMode.Impulse);
            hitWithBullet = true;

            CrashAudio.PlayOneShot(crashSound, 1);

        }
        else if (collision.gameObject.CompareTag("Bullet2"))
        {
            health -= 80;
            Debug.Log("Enemy Health is: " + health);
            Destroy(collision.gameObject);
            awayDirection = (transform.position - player.transform.position).normalized;
            EnemyRb.AddForce(awayDirection * 20, ForceMode.Impulse);
            hitWithBullet = true;

            CrashAudio.PlayOneShot(crashSound, 1);

        }
        else if (collision.gameObject.CompareTag("Bullet3"))
        {
            health -= 120;
            Debug.Log("Enemy Health is: " + health);
            Destroy(collision.gameObject);
            awayDirection = (transform.position - player.transform.position).normalized;
            EnemyRb.AddForce(awayDirection * 10, ForceMode.Impulse);
            hitWithBullet = true;

            CrashAudio.PlayOneShot(crashSound, 1);

        }
        else if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Gun1")|| collision.gameObject.CompareTag("Gun2")|| collision.gameObject.CompareTag("Gun3"))
        {
            player.GetComponent<PlayerController>().PlayerHealth-=10;
            player.GetComponent<PlayerController>().enemyKilled++;
            Debug.Log(player.GetComponent<PlayerController>().PlayerHealth);
            StartCoroutine(SpawnEnemyOnSpot());

            CrashAudio.PlayOneShot(crashSound, 1);

        }

        if (collision.gameObject.CompareTag("Walls") && hitWithBullet)
        {
            player.GetComponent<PlayerController>().enemyKilled++;
            StartCoroutine(SpawnEnemyOnSpot());

        }
        else if(collision.gameObject.CompareTag("Walls") && !hitWithBullet)
            StartCoroutine(SpawnEnemyOnSpot());
    }
}
