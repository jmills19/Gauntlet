using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int Hp;
    public bool startSpawn;
    public float howfar;

    public GameObject player;
    public float timeBetweenShots;
    public float startDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, timeBetweenShots);
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance < howfar)
        {
            if (Physics.Raycast(transform.position, Vector3.back, 4f) && Physics.Raycast(transform.position, Vector3.forward, 4f)
                && Physics.Raycast(transform.position, Vector3.left, 4f) && Physics.Raycast(transform.position, Vector3.right, 4f))
            {
                startSpawn = false;
            }
            else
            {
                startSpawn = true;
            }
        }
        else
        {
            startSpawn = false;
        }
    }


    public void SpawnEnemy()
    //similar spawner that was in the original platformer but it can now spawn enemies
    {
        if (startSpawn == true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
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
