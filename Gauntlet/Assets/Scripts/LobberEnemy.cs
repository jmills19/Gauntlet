using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberEnemy : MonoBehaviour
{
    public float howFar;
    public float howClose;
    public int speed = 5;
    public int Hp = 5;

    public Transform RockPos;
    public GameObject player;
    public GameObject Rock;
    public float _fireDeathTimer;
    public float timeBetweenShots;
    public float startDelay;
    public bool shooting = false;

    Vector3 tempPos;
    Vector3 tempRot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        tempRot = transform.eulerAngles;

        if (distance <= howFar&&distance>=howClose)
        {
            shooting = true;
        }
        else if(distance>=howFar)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            tempPos = transform.position;
            shooting = false;
        }
        else if(distance<=howClose)
        {
            transform.position += transform.forward * -1*speed * Time.deltaTime;
            tempPos = transform.position;
            shooting = false;
        }
        if (transform.position.y > 1 || transform.position.y < 1)
        {
            tempPos.y = 1;
            transform.position = tempPos;

        }
        if (transform.rotation.y < 0 || transform.rotation.y > 0)
        {
            tempRot.x = 0;
            transform.rotation = Quaternion.Euler(tempRot);
        }

        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SpawnProjectile()
    //similar spawner that was in the original platformer but it can now spawn enemies
    {

        if (shooting == true)
        {
            GameObject projectile = Instantiate(Rock, RockPos.transform.position, this.transform.rotation);
            projectile.GetComponent<Rock>().Initialize(_fireDeathTimer);
        }
    }
}
