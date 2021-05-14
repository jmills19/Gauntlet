using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ser_Spawn : MonoBehaviour
{
    void Start()
    {
        //The empty game object where the player spawns after starting a new level or respawning
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
    }
}
