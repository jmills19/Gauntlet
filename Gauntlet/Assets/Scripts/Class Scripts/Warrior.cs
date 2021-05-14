using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Warrior : MonoBehaviour
{
    public Transform ForwardPos;
    public Transform backPos;
    public Transform leftPos;
    public Transform RightPos;
    public GameObject bullet;
    public TMP_Text healthText;
    public TMP_Text Score;
    public float pAttackRange;
    public int bulletSpeed;

    public int key;
    public int treasure;

    public static bool isForward;
    public static bool isBackward;
    public static bool isRight;
    public static bool isLeft;

    private Vector3 moveDirection = Vector3.zero;
    //public static float xMove, zMove;
    // "Timer" Creates a time limit for the player
    public float constantHealthDrain = 200f;

    public PlayerInput playerInput;
    public bool shooting = true;
    public Vector3 rawInputMovement;



    // Base character stats

    public float timeBetweenShots;

    public int pDamage;
    Vector3 pMove;

    public float pSpeed = 5f;
    enum pAttackType { melee, missile };


    // Start is called before the first frame update
    void Start()
    {
        shooting = true;
        healthText = GameObject.Find("warriorHealthText").GetComponent<TMP_Text>();
        Score = GameObject.Find("warriorScore").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(new Vector3(rawInputMovement.x, 0, rawInputMovement.z) * pSpeed * Time.deltaTime);

        if (rawInputMovement.x > 0.5 && rawInputMovement.z < 0.5 && rawInputMovement.z > -0.5)
        {
            Debug.Log("right");
            isForward = false;
            isBackward = false;
            isLeft = false;
            isRight = true;
        }
        else if (rawInputMovement.x < -0.5 && rawInputMovement.z < 0.5 && rawInputMovement.z > -0.5)
        {
            Debug.Log("left");
            isForward = false;
            isBackward = false;
            isLeft = true;
            isRight = false;
        }
        else if (rawInputMovement.z > 0.5 && rawInputMovement.x < 0.5 && rawInputMovement.x > -0.5)
        {
            Debug.Log("forward");
            isForward = true;
            isBackward = false;
            isLeft = false;
            isRight = false;
        }
        else if (rawInputMovement.z < -0.5 && rawInputMovement.x < 0.5 && rawInputMovement.x > -0.5)
        {
            Debug.Log("back");
            isForward = false;
            isBackward = true;
            isLeft = false;
            isRight = false;
        }


        Score.text = "Score: " + treasure.ToString("f0");
        if (constantHealthDrain <= 0)
        {
            healthText.text = "You Die!";
            Destroy(gameObject);
        }
        else
        {
            healthText.text = "Warrior Health: " + constantHealthDrain.ToString("f0");
            constantHealthDrain -= Time.deltaTime;
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {

        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        Debug.Log("wtf");
        if (value.started)
        {
            
            if (shooting == true)
            {
                if (isForward == true && isBackward == false && isLeft == false && isRight == false)
                {

                    GameObject projectile = Instantiate(bullet, ForwardPos.transform.position, this.transform.rotation);
                    projectile.GetComponent<bullet>().goingBack = isBackward;
                    projectile.GetComponent<bullet>().goingForward = isForward;
                    projectile.GetComponent<bullet>().goingLeft = isLeft;
                    projectile.GetComponent<bullet>().goingRight = isRight;
                    projectile.GetComponent<bullet>().Initialize(pAttackRange, bulletSpeed);

                }
                else if (isBackward == true && isForward == false && isLeft == false && isRight == false)
                {
                    GameObject projectile = Instantiate(bullet, backPos.transform.position, this.transform.rotation);
                    projectile.GetComponent<bullet>().goingBack = isBackward;
                    projectile.GetComponent<bullet>().goingForward = isForward;
                    projectile.GetComponent<bullet>().goingLeft = isLeft;
                    projectile.GetComponent<bullet>().goingRight = isRight;
                    projectile.GetComponent<bullet>().Initialize(pAttackRange, bulletSpeed);

                }
                else if (isLeft == true && isBackward == false && isForward == false && isRight == false)
                {
                    GameObject projectile = Instantiate(bullet, leftPos.transform.position, this.transform.rotation);
                    projectile.GetComponent<bullet>().goingBack = isBackward;
                    projectile.GetComponent<bullet>().goingForward = isForward;
                    projectile.GetComponent<bullet>().goingLeft = isLeft;
                    projectile.GetComponent<bullet>().goingRight = isRight;
                    projectile.GetComponent<bullet>().Initialize(pAttackRange, bulletSpeed);

                }
                else if (isRight == true && isBackward == false && isLeft == false && isForward == false)
                {
                    GameObject projectile = Instantiate(bullet, RightPos.transform.position, this.transform.rotation);
                    projectile.GetComponent<bullet>().goingBack = isBackward;
                    projectile.GetComponent<bullet>().goingForward = isForward;
                    projectile.GetComponent<bullet>().goingLeft = isLeft;
                    projectile.GetComponent<bullet>().goingRight = isRight;
                    projectile.GetComponent<bullet>().Initialize(pAttackRange, bulletSpeed);

                }

                shooting = false;
                StartCoroutine(shoot());

                Debug.Log("Attack");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Death")
        {
            constantHealthDrain -= DeathEnemy.totalDamage;
        }
        if (other.gameObject.tag == "Enemy")
        {
            constantHealthDrain--;
        }
        if (other.gameObject.tag == "door")
        {
            if (key > 0)
            {
                key--;
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rock")
        {
            constantHealthDrain--;
        }
        if (other.gameObject.tag == "key")
        {
            key++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "treasure")
        {
            treasure += 50;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Exit")
        {
            ChangeScene.instance.switchScene(2);
        }
        if (other.gameObject.tag == "win")
        {
            ChangeScene.instance.switchScene(3);
        }
    }

    IEnumerator shoot()
    {

        yield return new WaitForSeconds(timeBetweenShots);
        shooting = true;
    }

}
