using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThievesEnemy : MonoBehaviour
{

    public bool run;
    public int speed;
    public int Hp = 5;
    public GameObject player;
    Vector3 tempPos;
    Vector3 tempRot;

    public string direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = "back";
        run = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (run == false)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            

            transform.position += transform.forward * speed * Time.deltaTime;
           
        }
        else
        {
            runaway();
        }
        tempRot = transform.eulerAngles;
        tempPos = transform.position;
        if (transform.position.y > 0 || transform.position.y < 0)
        {
            tempPos.y = 0;
            transform.position = tempPos;

        }
        if (transform.rotation.x < 0 || transform.rotation.x > 0||transform.rotation.z<0||transform.rotation.z>0)
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

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player's health--;
            run = true;
        }
    }

    void runaway()
    {

        if (direction == "back")
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (direction == "forward")
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (direction == "left")
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (direction == "right")
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        if (direction == "back" && Physics.Raycast(transform.position, Vector3.back, 0.8f))
        {
            if (Random.Range(0, 2) == 0)
            {
                direction = "left";
            }
            else
            {
                direction = "right";
            }
        }
        else if (direction == "forward" && Physics.Raycast(transform.position, Vector3.forward, 0.8f))
        {
            if (Random.Range(0, 2) == 0)
            {
                direction = "left";
            }
            else
            {
                direction = "right";
            }
        }
        else if (direction == "left" && Physics.Raycast(transform.position, Vector3.left, 0.8f))
        {
            if (Random.Range(0, 2) == 0)
            {
                direction = "forward";
            }
            else
            {
                direction = "back";
            }
        }
        else if (direction == "right" && Physics.Raycast(transform.position, Vector3.right, 0.8f))
        {
            if (Random.Range(0, 2) == 0)
            {
                direction = "forward";
            }
            else
            {
                direction = "back";
            }
        }
    }
}
