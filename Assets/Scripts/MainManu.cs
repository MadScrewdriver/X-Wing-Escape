using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour {

    public GameObject g;
    public AudioClip Imperial;

    public void Start()
    {
        //SoundManager.instanced.PlaySingle(Imperial);
        g.SetActive(true);    
    }

    public void ToGame()
    {
        SceneManager.LoadScene("animacja");
    }
}
