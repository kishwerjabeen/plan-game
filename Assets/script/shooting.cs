using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Quaternion.identity use when we dont wont to change position 
            Instantiate(playerBullet, transform.position, Quaternion.identity);
        }
    }
}
