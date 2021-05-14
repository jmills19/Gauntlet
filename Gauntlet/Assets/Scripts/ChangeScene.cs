using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject mainCamera;
    public static ChangeScene instance;
    public GameObject canvas;
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(player1);
        DontDestroyOnLoad(player2);
        DontDestroyOnLoad(player3);
        DontDestroyOnLoad(player4);
        DontDestroyOnLoad(mainCamera);
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvas);
    }

    public void switchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
