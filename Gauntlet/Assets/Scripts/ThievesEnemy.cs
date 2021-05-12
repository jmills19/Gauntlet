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
            

            transform.position += transform.forward * speed * Time.deltaTime;
           
        }
        else
        {

            if (Physics.Raycast(transform.position, Vector3.back, 1f))
            {
                Debug.Log("forward");
                if (Random.Range(0, 2) == 0)
                {
                    //transform.Rotate(new Vector3(0, -90, 0));
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
                else
                {
                    //transform.Rotate(new Vector3(0, 90, 0));
                    transform.position += Vector3.left * Time.deltaTime * speed;
                }
            }
            else if(Physics.Raycast(transform.position,Vector3.forward,1f))
            {
                Debug.Log("back");
                if (Random.Range(0, 2) == 0)
                {
                    //transform.Rotate(new Vector3(0, -90, 0));
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
                else
                {
                    //transform.Rotate(new Vector3(0, 90, 0));
                    transform.position += Vector3.left * Time.deltaTime * speed;
                }
            }
            
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
            //Player's health--;
            run = true;
        }
    }
}
