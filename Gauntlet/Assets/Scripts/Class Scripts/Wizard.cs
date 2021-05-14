using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Wizard : MonoBehaviour
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
        healthText = GameObject.Find("wizardHealthText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * pSpeed * Time.deltaTime);

        healthText.text = "Wizard Health: " + constantHealthDrain.ToString("f0");

        if (constantHealthDrain <= 0)
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
