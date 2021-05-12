using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThievesEnemy : MonoBehaviour
{
    public bool goingLeft;
    public bool goingForward;
    public bool run;
    public int speed;
    public int Hp = 5;
    public GameObject player;
    Vector3 tempPos;
    Vector3 tempRot;
    // Start is called before the first frame update
    void Start()
    {
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
            tempRot = transform.eulerAngles;

            transform.position += transform.forward * speed * Time.deltaTime;
           
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.forward, 1f))
            {
                Debug.Log("What");
                if (Random.Range(0, 2) == 0)
                {
                    
                }
                else
                {
                    
                }
            }
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        tempPos = transform.position;
        if (transform.position.y > 0 || transform.position.y < 0)
        {
            tempPos.y = 0;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player's health--;
            run = true;
        }
    }
}
