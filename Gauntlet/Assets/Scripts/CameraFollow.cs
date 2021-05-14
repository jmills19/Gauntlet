using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetPlayer;
    public Vector3 mydif;
    
    // Start is called before the first frame update
    void Start()
    {
        mydif = new Vector3(0, 30, -40);
        mydif = transform.position - targetPlayer.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       targetPlayer = GameObject.Find("Elf");
        //targetPlayer = GameObject.FindGameObjectWithTag("Player");
        transform.position = targetPlayer.transform.position + mydif;
    }
}