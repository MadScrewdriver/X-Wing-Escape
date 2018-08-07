using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    public GameObject off;
    public Text score;
    public Rigidbody movment;
    public float deley = 2f;
    public MovePlayer moveplayer;
    public DeathMenu deathMenu;
    public Asteroids asteroids;
    public double t;
    public bool end = true;
    public ParticleSystem Explosion;
    public Transform Camera;
    public Vector3 goback;
    public AudioClip explo;

    private void Start()
    {
        Explosion.Stop();
    }

    void Update()
    {

        if (!(end) && Time.time - t >= deley)
        {
            score.enabled = false;
            gameover();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Asteroid")
        {
            MenageDead();
        }
    }

    public void MenageDead()
    {
        if (end)
        {
            t = Time.time;
            end = false;
            moveplayer.enabled = false;
            Camera.position += goback;
            Explosion.Play();
            SoundManager.instanced.PlaySingle(explo);
            off.SetActive(false);  
        }
    }

    void gameover()
    {
        deathMenu.dead(asteroids.score);
    }
}
