using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 10f;
    private float verticalInput;
    private float horizontalInput;
    private float playerRotation = 60;

    public int enemyKilled = 0;
    public int PlayerHealth = 100;

    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyKilled = 0;
        PlayerHealth = 100;
        StartCoroutine(WinCondition());

        

    }

    IEnumerator WinCondition()
    {
        yield return new WaitForSeconds(60);
        if (enemyKilled >= 15)
            Debug.Log("You win");
        else
            Debug.Log("You Lose");


    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * playerSpeed * Time.deltaTime);
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * playerRotation * Time.deltaTime);

        if(PlayerHealth<1&&!gameOver)
        {
            Debug.Log("Game Over");
            gameOver = true;
        }

    }
}
