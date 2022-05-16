using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform gunPointLeft;
    public Transform gunPointRight;
    public GameObject enemyBullet;
    public float enemyBulletSpawnTime = 0.5f;
    public GameObject enemyFlash;
    public GameObject enemyExplosionPrefeb;


    // Start is called before the first frame update
    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(EnemyShooting());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "PlayerBullet")
        {
            Destroy(gameObject);
            GameObject enemyExplosion = Instantiate(enemyExplosionPrefeb, transform.position, Quaternion.identity);
         // destroy copy
            Destroy(enemyExplosion, 0.4f);
        }
        
    }
    void EnemyFire()
    {
        Instantiate(enemyBullet, gunPointLeft.position, Quaternion.identity);
        Instantiate(enemyBullet, gunPointRight.position, Quaternion.identity);
    }
    //CoRoutine
    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyBulletSpawnTime);
            EnemyFire();
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.08f);
            enemyFlash.SetActive(false);
        }
       
    }
}