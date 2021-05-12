using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int Hp;

    public float timeBetweenShots;
    public float startDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, timeBetweenShots);
    }


    public void SpawnEnemy()
    //similar spawner that was in the original platformer but it can now spawn enemies
    {

        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="bullet")
        {
            Hp--;
            if(Hp<0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
