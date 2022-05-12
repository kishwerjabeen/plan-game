using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;
    public float bulletSpawnTime = 1f;
    public GameObject flash;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }
    // Update is called once per frame
    void Update()
    {
       
        {
            // Quaternion.identity use when we dont wont to change position 
           
        }
    }
    void Fire()
    {
        Instantiate(playerBullet, spawnPointRight.position, Quaternion.identity);
        Instantiate(playerBullet, spawnPointLeft.position, Quaternion.identity);
    }

   IEnumerator Shoot()
    {
        //yield return new WaitForSeconds(bulletSpawnTime);
        //Fire();
        //StartCoroutine(Shoot());
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.08f);
            flash.SetActive(false);

        }



    }
}
