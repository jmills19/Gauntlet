using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // "Timer" Creates a time limit for the player
    public int constantHealthDrain = 100;

    // Base character stats
    int pHealth;
    int pDamage;
    Vector3 pMove;
    float pSpeed = 5;
    enum pAttackType { melee, missile };
    float pAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * pSpeed * Time.deltaTime;
        }
        // Move to the Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * pSpeed * Time.deltaTime;
        }
        // Move Backwards
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -1) * pSpeed * Time.deltaTime;
        }
        // Move to the Right
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D was pressed.");
            transform.position += new Vector3(1, 0, 0) * pSpeed * Time.deltaTime;
        }

        if (constantHealthDrain > 0)
        {
            constantHealthDrain--;
        }
    }
}
