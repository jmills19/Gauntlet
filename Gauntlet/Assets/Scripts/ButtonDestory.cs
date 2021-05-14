using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestory : MonoBehaviour
{
    [SerializeField]
    GameObject objectToDestroy1;
    [SerializeField]
    GameObject objectToDestroy2;
    [SerializeField]
    GameObject objectToDestroy3;
    [SerializeField]
    GameObject objectToDestroy4;
    [SerializeField]
    GameObject objectToDestroy5;
    [SerializeField]
    GameObject objectToDestroy6;
    [SerializeField]
    GameObject objectToDestroy7;

    public void DestoyGameObject()
    {
        Destroy(objectToDestroy1);
        Destroy(objectToDestroy2);
        Destroy(objectToDestroy3);
        Destroy(objectToDestroy4);
        Destroy(objectToDestroy5);
        Destroy(objectToDestroy6);
        Destroy(objectToDestroy7);

    }
}
