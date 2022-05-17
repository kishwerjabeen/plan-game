using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform gunPointLeft;
    public Transform gunPointRight;
    public GameObject enemyBullet;
    public GameObject enemyFlash;
    public GameObject enemyExplosionPrefeb;
    //healthbar jo script ka name ha wohi name daygae

    public Healthbar healthbar;


    public float enemyBulletSpawnTime = 0.5f;
    
   // healthbar 
    public float health = 10f;

    float barSize = 1f;
    float damage = 0;


    // Start is called before the first frame update
    
    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(EnemyShooting());
        // healthbar
        damage = barSize / health;
        healthbar.Setsize(barSize);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "PlayerBullet")
        {
            DamageHealthbar();
            //bullet destroy 
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefeb, transform.position, Quaternion.identity);
                // destroy copy
                Destroy(enemyExplosion, 0.4f);
            }



          
        }
        
    }
    //healthbar
    void DamageHealthbar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
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