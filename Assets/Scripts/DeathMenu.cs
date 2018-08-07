using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeathMenu : MonoBehaviour
{

    public Text scoretext;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }


    public void dead(int score)
    {
        gameObject.SetActive(true);
        scoretext.text = score.ToString();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void tomenu()
    {
        SceneManager.LoadScene("Menu");
    }
}