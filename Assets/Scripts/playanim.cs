using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playanim : MonoBehaviour {

    public float t;
    public float d = 5.0f;
    public AudioClip motor;

    private void Start()
    {
        t = 0;
        SoundManager.instanced.PlaySingle(motor);
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t >= d)
        {
            SceneManager.LoadScene("starwars");
        }
    }
}
