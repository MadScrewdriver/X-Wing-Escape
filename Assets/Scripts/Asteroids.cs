using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroids : MonoBehaviour {

    public Transform player;
    public Vector3 pos;
    public Vector3 posleft;
    public Vector3 posright;
    public Vector3 posup;
    public Vector3 posdown;
    public int start_dis = 4;
    public List<GameObject> clone = new List<GameObject>();
    public float distance_between = 25;
    public GameObject pref;
    public GameObject pref_back;
    public List<bool> alredy = new List<bool>();
    public Vector3 front;
    public Text score_text;
    public int score = 0;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < 30; i++)
        {
            pos = new Vector3(Random.Range(-700, 700), Random.Range(-700, 700), distance_between * start_dis + distance_between * i) + front;
            posleft = new Vector3(Random.Range(-3000, -800), Random.Range(-700, 700), distance_between * start_dis + distance_between * i) + front;
            posright = new Vector3(Random.Range(800, 3000), Random.Range(-700, 700), distance_between * start_dis + distance_between * i) + front;
            posup = new Vector3(Random.Range(-3000, 3000), Random.Range(800, 2000), distance_between * start_dis + distance_between * i) + front;
            posdown = new Vector3(Random.Range(-3000, 3000), Random.Range(-800, -2000), distance_between * start_dis + distance_between * i) + front;

            clone.Add(Instantiate(pref, pos, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject);
            clone.Add(Instantiate(pref_back, posright, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject);
            clone.Add(Instantiate(pref_back, posleft, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject);
            clone.Add(Instantiate(pref_back, posup, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject);
            clone.Add(Instantiate(pref_back, posdown, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject);

            alredy.Add(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float player_pos = player.position.z;

        if (clone[0].transform.position.z + 10 < player_pos)
        {
            if (clone[0].transform.position.y >= -700 && clone[0].transform.position.y <= 700 && 
                clone[0].transform.position.x >= -700 && clone[0].transform.position.x <= 700)
            {
                addopo();
                update_score();
                remove();
            }

            else
            {
                addbackground();
            }

        }

    }

    void addbackground()
    {
        GameObject c = clone[0];
        clone.RemoveAt(0);
        c.transform.position += new Vector3(0, 0, distance_between * 30);
        clone.Add(c);
    }

    void addopo()
    {
        pos.x = Random.Range(-700, 700);
        pos.y = Random.Range(-700, 700);
        pos.z += distance_between;
        clone.Add(Instantiate(pref, pos, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject);
        alredy.Add(true);
    }

    void remove()
    {
        Destroy(clone[0]);
        clone.RemoveAt(0);
        alredy.RemoveAt(0);
    }

    void update_score()
    {
        float player_pos = player.position.z;

        if (clone[0].transform.position.z + 0.5 < player_pos && alredy[0])
        {
            alredy[0] = false;
            score++;
        }

        if (clone[1].transform.position.z + 0.5 < player_pos && alredy[1])
        {
            alredy[1] = false;
            score++;
        }

        score_text.text = score.ToString();
    }

}
