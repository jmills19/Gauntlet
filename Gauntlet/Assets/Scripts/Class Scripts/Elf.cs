using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Elf : MonoBehaviour
{
    public Transform Pos;
    public GameObject bullet;
    public TMP_Text healthText;
    public float pAttackRange;
    public int bulletSpeed;

    public static bool isForward;
    public static bool isBackward;
    public static bool isRight;
    public static bool isLeft;

    private Vector3 moveDirection = Vector3.zero;
    //public static float xMove, zMove;
    // "Timer" Creates a time limit for the player
    public float constantHealthDrain = 100f;

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
        healthText = GameObject.Find("elfHealthText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(rawInputMovement.x, 0, rawInputMovement.z) * pSpeed * Time.deltaTime);
      
        if(rawInputMovement.x>0.5&&rawInputMovement.z<0.5&&rawInputMovement.z>-0.5)
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

        healthText.text = "Elf Health: " + constantHealthDrain.ToString("f0");

        if (constantHealthDrain <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
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

        if (value.started)
        {
            if (shooting == true)
            {
                GameObject projectile = Instantiate(bullet, Pos.transform.position, this.transform.rotation);
                projectile.GetComponent<bullet>().goingBack = isBackward;
                projectile.GetComponent<bullet>().goingForward = isForward;
                projectile.GetComponent<bullet>().goingLeft = isLeft;
                projectile.GetComponent<bullet>().goingRight = isRight;
                projectile.GetComponent<bullet>().Initialize(pAttackRange,bulletSpeed);
               
                shooting = false;
                StartCoroutine(shoot());

                Debug.Log("Attack");
            }
        }
    }


    IEnumerator shoot()
    {

        yield return new WaitForSeconds(timeBetweenShots);
        shooting = true;
    }
}
