using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed;
    private int borders = 20;

    private Rigidbody BulletRb;
    // Start is called before the first frame update
    void Start()
    {
        BulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // BulletRb.AddForce(Vector3.forward * speed);
        BulletRb.AddRelativeForce(0, 0, 30);
        if (transform.position.x > borders || transform.position.x < -borders ||transform.position.z > borders || transform.position.z < -borders|| transform.position.y > 1)
            Destroy(gameObject);

    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
            Destroy(gameObject);
    }
}
