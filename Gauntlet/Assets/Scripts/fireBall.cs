using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    public float speed;
    Rigidbody body;
    public float _deathTimer;
    public Transform player;
    public void Initialize(float deathTimer)
    {
        _deathTimer = deathTimer;
    }
    // Start is called before the first frame update
    void start()
    {
    


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
        StartCoroutine(Die());
        
    }
    IEnumerator Die()
    {

        yield return new WaitForSeconds(_deathTimer);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            //Player's health--;
        }
        Destroy(this.gameObject);
    }
}
