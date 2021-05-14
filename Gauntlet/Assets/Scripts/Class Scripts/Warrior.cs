using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Warrior : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text scoreText;

    [SerializeField]
    //private WarriorControls _controls;

    // "Timer" Creates a time limit for the player
    public float constantHealthDrain = 100f;
    private Vector2 movementInput;

    //[SerializeField]
    public Transform firePoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private float launchForce = 700f;
    public int score = 0;

    // Base character stats
    public int pDamage;
    Vector3 pMove;
    public float pSpeed = 5f;
    enum pAttackType { melee, missile };
    public float pAttackRange;

    private void Awake()
    {
        //controls.Player.Shoot.performed += ctx => Shoot();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("warriorHealthText").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * pSpeed * Time.deltaTime);

        healthText.text = "Warrior Health: " + constantHealthDrain.ToString("f0");
        scoreText.text = "Score: " + score.ToString();

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
        Debug.Log("Player Moving!");
        movementInput = ctx.ReadValue<Vector2>();
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        Debug.Log("Player Shot!");
        var projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        projectileInstance.AddForce(firePoint.forward * launchForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Treausre")
        {
            score = score + 10;
            Destroy(collision.gameObject);
        }
    }
}
