using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private GameObject gun1;
    private GameObject gun2;
    private GameObject gun3;

    public GameObject[] bulletsPf;

    private GameObject speedSetter;
    private int bulletType = 0;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        gun1 = GameObject.Find("Gun1");
        gun2 = GameObject.Find("Gun2");
        gun3 = GameObject.Find("Gun3");

        ActivateGunOnStart();

    }
    void ActivateGunOnStart()
    {
        bulletType = 1;
        gun1.SetActive(true);
        gun2.SetActive(false);
        gun3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchGuns();
        BulletsSpawner();

    }

    private void BulletsSpawner()
    {
       if(bulletType==1&&Input.GetKeyDown(KeyCode.Space))
        {
            position = new Vector3(gun1.transform.position.x, gun1.transform.position.y , gun1.transform.position.z+1);
            speedSetter= Instantiate(bulletsPf[0], position, gun1.transform.rotation);
            speedSetter.GetComponent<MoveForward>().SetSpeed(20);
        }
       else if (bulletType == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            position = new Vector3(gun1.transform.position.x, gun1.transform.position.y, gun1.transform.position.z + 1);

            speedSetter = Instantiate(bulletsPf[1], position, transform.rotation);
            speedSetter.GetComponent<MoveForward>().SetSpeed(10);
        }
        else if (bulletType == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            position = new Vector3(gun1.transform.position.x, gun1.transform.position.y, gun1.transform.position.z + 1);
            speedSetter = Instantiate(bulletsPf[2], position, transform.rotation);
            speedSetter.GetComponent<MoveForward>().SetSpeed(5);
        }
    }

    void SwitchGuns()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            gun3.SetActive(false);
            bulletType = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            gun3.SetActive(false);
            bulletType = 2;

        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(true);
            bulletType = 3;
        }
    }

}
