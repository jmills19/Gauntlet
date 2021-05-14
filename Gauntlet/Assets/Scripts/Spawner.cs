using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int Hp=3;
    public bool startSpawn;
    public float howfar;
    public Transform Pos;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    int which;
    float distance1;
    float distance2;
    float distance3;
    float distance4;

    public float timeBetweenShots;
    public float startDelay;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnEnemy", startDelay, timeBetweenShots);
    }
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
        player1 = GameObject.Find("Elf");
        player2 = GameObject.Find("Warrior");
        player3 = GameObject.Find("Wizard");
        player4 = GameObject.Find("Valkyrie");
        if (player1 != null)
        {
            distance1 = Vector3.Distance(player1.transform.position, this.transform.position);
        }
        else
        {
            distance1 = 99999;
        }
        if (player2 != null)
        {
            distance2 = Vector3.Distance(player2.transform.position, this.transform.position);
        }
        else
        {
            distance2 = 99999;
        }
        if (player3 != null)
        {
            distance3 = Vector3.Distance(player3.transform.position, this.transform.position);
        }
        else
        {
            distance3 = 99999;
        }
        if (player4 != null)
        {
            distance4 = Vector3.Distance(player4.transform.position, this.transform.position);
        }
        else
        {
            distance4 = 99999;
        }



        if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4)
        {
            which = 1;
            if (distance1 < howfar)
            {
                if (Physics.Raycast(transform.position, Vector3.back, 5f) && Physics.Raycast(transform.position, Vector3.forward, 5f)
                    && Physics.Raycast(transform.position, Vector3.left, 5f) && Physics.Raycast(transform.position, Vector3.right, 5f))
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
        else if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4)
        {
            which = 2;
            if (distance2 < howfar)
            {
                if (Physics.Raycast(transform.position, Vector3.back, 5f) && Physics.Raycast(transform.position, Vector3.forward, 5f)
                    && Physics.Raycast(transform.position, Vector3.left, 5f) && Physics.Raycast(transform.position, Vector3.right, 5f))
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
        else if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4)
        {
            which = 3;
            if (distance3 < howfar)
            {
                if (Physics.Raycast(transform.position, Vector3.back, 5f) && Physics.Raycast(transform.position, Vector3.forward, 5f)
                    && Physics.Raycast(transform.position, Vector3.left, 5f) && Physics.Raycast(transform.position, Vector3.right, 5f))
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
        else if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3)
        {
            which = 4;
            if (distance4 < howfar)
            {
                if (Physics.Raycast(transform.position, Vector3.back, 5f) && Physics.Raycast(transform.position, Vector3.forward, 5f)
                    && Physics.Raycast(transform.position, Vector3.left, 5f) && Physics.Raycast(transform.position, Vector3.right, 5f))
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


       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Hp--;

        }

    }
    public void SpawnEnemy()
    {
        if (startSpawn == true)
        {
            GameObject projectile = Instantiate(projectilePrefab, Pos.transform.position, projectilePrefab.transform.rotation);
        }
    }
    
}
