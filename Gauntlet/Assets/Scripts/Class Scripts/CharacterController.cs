using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public TMP_Text healthText;

    // "Timer" Creates a time limit for the player
    public float constantHealthDrain = 100f;
    private Vector2 movementInput;

    // Base character stats
    public int pDamage;
    Vector3 pMove;
    public float pSpeed = 5f;
    enum pAttackType { melee, missile };
    public float pAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("warriorHealthText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
            Debug.Log("D key pressed.");
            transform.position += new Vector3(1, 0, 0) * pSpeed * Time.deltaTime;
        }
        */

        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * pSpeed * Time.deltaTime);

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

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
}
