using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TMP_Text healthText;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = healthText.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = cc.constantHealthDrain.ToString("0");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is closed (Quit Button).");
    }
}
