using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererEnemy : MonoBehaviour
{
    public bool invisible;
    public int speed = 5;
    public int Hp = 5;
    public GameObject player;
    public float timeBetween;
    public float startDelay;
    Vector3 tempPos;
    Vector3 tempRot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("flashing", startDelay, timeBetween);
    }

    // Update is called once per frame
    void Update()
    {
        if(invisible==true)
        {

        }

        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        tempRot = transform.eulerAngles;

        transform.position += transform.forward * speed * Time.deltaTime;
        tempPos = transform.position;
        if (transform.position.y > 0 || transform.position.y < 0)
        {
            tempPos.y = 0;
            transform.position = tempPos;

        }
        if (transform.rotation.x < 0 || transform.rotation.x > 0 || transform.rotation.z < 0 || transform.rotation.z > 0)
        {
            tempRot.z = 0;
            tempRot.x = 0;
            transform.rotation = Quaternion.Euler(tempRot);
        }

        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player's health--;
        }
    }
    public void flashing()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if (invisible==true)
        {
            foreach (var r in renderers)
            {
                r.enabled = true;
            }
            invisible = false;
        }
        else
        {
            foreach (var r in renderers)
            {
                r.enabled = false;
            }
                invisible = true;
        }
    }
}
