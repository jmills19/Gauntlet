using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{

    public Transform fireballPos;
    public GameObject fireball;
    public float _fireDeathTimer;
    //public TMP_Text healthText;
    public PlayerInput playerInput;
    public Vector3 rawInputMovement;
    // "Timer" Creates a time limit for the player
    public float constantHealthDrain = 100f;


    // Base character stats
    //public int pDamage;
    Vector3 pMove;
    public float pSpeed = 5f;
    //enum pAttackType { melee, missile };
    //public float pAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        //controller = gameObject.AddComponent<PlayerInput>();
        //healthText = GameObject.Find("warriorHealthText").GetComponent<TMP_Text>();
    }
 

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D key pressed.");
            transform.position += new Vector3(1, 0, 0) * pSpeed * Time.deltaTime;
        }
        */

        transform.Translate(new Vector3(rawInputMovement.x, 0, rawInputMovement.z) * pSpeed * Time.deltaTime);

        // healthText.text = "Warrior Health: " + constantHealthDrain.ToString("f0");

        if(constantHealthDrain <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            constantHealthDrain -= Time.deltaTime;
        }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Debug.Log("Move");
       
        
        Vector2 inputMovement = value.ReadValue<Vector2>();
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        
  
        if(value.started)
        {
            GameObject projectile = Instantiate(fireball, fireballPos.transform.position, this.transform.rotation);
            projectile.GetComponent<fireBall>().Initialize(_fireDeathTimer);
            Debug.Log("Attack");
        }
    }
}
