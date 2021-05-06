using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    public float speed;
    public float _deathTimer;
    public void Initialize(float deathTimer)
    //please comment what this does
    {
        _deathTimer = deathTimer;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Vector3.left * Time.deltaTime;
        
    }
    IEnumerator Die()
    {

        yield return new WaitForSeconds(_deathTimer);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
      
            Destroy(this.gameObject);
    }
}
