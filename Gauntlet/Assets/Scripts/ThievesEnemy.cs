using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThievesEnemy : MonoBehaviour
{

    public bool run;
    public int speed;
    public int Hp = 5;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    int which;
    float distance1;
    float distance2;
    float distance3;
    float distance4;

    public float _deathTimer;
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
        player1 = GameObject.Find("Elf");
        player2 = GameObject.Find("Warrior");
        player3 = GameObject.Find("Wizard");
        player4 = GameObject.Find("Valkyrie");

        if (run == false)
        {
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
            }
            else if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4)
            {
                which = 2;
            }
            else if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4)
            {
                which = 3;
            }
            else if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3)
            {
                which = 4;
            }

            if (which == 1)
            {

                transform.LookAt(player1.transform);
                Quaternion targetRotation = Quaternion.LookRotation(player1.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else if (which == 2)
            {
                transform.LookAt(player2.transform);
                Quaternion targetRotation = Quaternion.LookRotation(player2.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else if (which == 3)
            {
                transform.LookAt(player3.transform);
                Quaternion targetRotation = Quaternion.LookRotation(player3.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else if (which == 4)
            {
                transform.LookAt(player4.transform);
                Quaternion targetRotation = Quaternion.LookRotation(player4.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;

            }       
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            run = true;
            StartCoroutine(Die());
        }
        if (other.gameObject.tag == "Bullet")
        {
            Hp -= 2;
        }
    }

   
IEnumerator Die()
    {

        yield return new WaitForSeconds(_deathTimer);
        Destroy(this.gameObject);
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

        if (direction == "back" && Physics.Raycast(transform.position, Vector3.back, 1.5f))
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
        else if (direction == "forward" && Physics.Raycast(transform.position, Vector3.forward, 1.5f))
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
        else if (direction == "left" && Physics.Raycast(transform.position, Vector3.left, 1.5f))
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
        else if (direction == "right" && Physics.Raycast(transform.position, Vector3.right, 1.5f))
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
