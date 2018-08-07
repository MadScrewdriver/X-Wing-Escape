using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gameplay : MonoBehaviour {

    public GameObject red;
    public GameObject green;
    public GameObject orange;
    public Vector2 pos1;
    public Vector2 pos2;
    public Transform player_trans;
    public bool danger = false;
    public string what = "green";
    public double t;
    public int distance = 300;
    public Collide collide;
    public AudioClip bad;

	// Use this for initialization
	void Start () {
        Debug.Log("s");
        red.SetActive(false);
        green.SetActive(false);
        orange.SetActive(false);
        t = Time.time;
        SoundManager.instanced.PlaySingle(bad);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("t");
        if (Time.time - t >= 1)
        {
            if (!(danger))
            {

                pos2 = pos1;
                pos1 = new Vector2(player_trans.position.x, player_trans.position.y);

                if (Math.Sqrt(Math.Pow((pos2.x - pos1.x), 2) + Math.Pow((pos2.y - pos1.y), 2)) < distance)
                {
                    danger = true;
                    green.SetActive(true);
                    what = "green";
                }

            }

            else
            {
                if (Math.Sqrt(Math.Pow((pos1.x - player_trans.position.x), 2) + Math.Pow((pos1.y - player_trans.position.y), 2)) < distance)
                {
                    if (what == "green")
                    {
                        green.SetActive(false);
                        orange.SetActive(true);
                        what = "orange";
                        t = Time.time;
                  
                    }

                    else if (what == "orange")
                    {
                        orange.SetActive(false);
                        red.SetActive(true);
                        t = Time.time;
                        what = "red";
                    }

                    else if (what == "red")
                    {
                        collide.MenageDead();
                    }

                }

                else
                {
                    danger = false;
                    red.SetActive(false);
                    orange.SetActive(false);
                    green.SetActive(false);
                    pos1 = new Vector2(player_trans.position.x, player_trans.position.y);
                }
            }

            t = Time.time;
        }
    }
}
