using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public int speed=5;
    public int Hp = 4;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    int which;
    float distance1;
    float distance2;
    float distance3;
    float distance4;

    Vector3 tempPos;
    Vector3 tempRot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.Find("Elf");
        player2 = GameObject.Find("Warrior");
        player3 = GameObject.Find("Wizard");
        player4 = GameObject.Find("Valkyrie");
        

        moveToPlayer();

        if (Hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //Player's health--;
        }
        if (other.gameObject.tag == "Bullet")
        {
            Hp -= 2;
        }
    }



    void moveToPlayer()
    {
        if(player1 != null)
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
            tempRot = transform.eulerAngles;
        }
        else if (which == 2)
        {
            transform.LookAt(player2.transform);
            Quaternion targetRotation = Quaternion.LookRotation(player2.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            tempRot = transform.eulerAngles;
        }
        else if (which == 3)
        {
            transform.LookAt(player3.transform);
            Quaternion targetRotation = Quaternion.LookRotation(player3.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            tempRot = transform.eulerAngles;
        }
        else if (which == 4)
        {
            transform.LookAt(player4.transform);
            Quaternion targetRotation = Quaternion.LookRotation(player4.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            tempRot = transform.eulerAngles;
        }


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
    }
}
