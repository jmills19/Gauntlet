using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    Rigidbody body;
    public float _deathTimer;

    public bool goingLeft;
    public bool goingRight;
    public bool goingForward;
    public bool goingBack;



    public void Initialize(float pAttackRange, int bulletSpeed)
    {
        _deathTimer = pAttackRange;
        speed = bulletSpeed;
    }
    // Start is called before the first frame update
    void start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (goingBack == true && goingRight == false && goingLeft == false&&goingForward==false)
        {
            
            transform.position += speed * Vector3.back * Time.deltaTime;
        }
        if (goingForward == true && goingRight == false && goingLeft == false && goingBack == false)
        {
            transform.position += speed * Vector3.forward * Time.deltaTime;
        }
        if (goingLeft == true && goingRight == false && goingBack == false && goingForward == false)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        if (goingRight == true && goingBack == false && goingLeft == false && goingForward == false)
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
        //transform.position += speed * transform.forward * Time.deltaTime;
        StartCoroutine(Die());

    }
    IEnumerator Die()
    {

        yield return new WaitForSeconds(_deathTimer);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {

            Destroy(this.gameObject);
        }
    }
}
