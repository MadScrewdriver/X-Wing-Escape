using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public GameObject player;
    public float speed = 500f;
    public Vector3 kineticspeed;
    public bool right = false;
    public bool left= false;
    public bool up = false;
    public bool down = false;
    public int rotation = 0;
    public Transform first_wing;
    public Transform secend_wing;
    public Rigidbody rb;
	
	// Update is called once per frame
	void Update () {

        left = Input.GetKey("a") && player.transform.position.x > -600;
        up = Input.GetKey("w") && player.transform.position.y < 500;
        down = Input.GetKey("s") && player.transform.position.y > -400;
        right = Input.GetKey("d") && player.transform.position.x < 600;
        
    }

    void FixedUpdate()
    {

        rot();

        if (right)
        {
            player.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        if (left)
        {
            player.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }

        if (up)
        {
            player.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }

        if (down)
        {
            player.transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }

        kinetic();
    }


    void kinetic()
    {
        rb.velocity = kineticspeed;
    }

    void rot()
    {
        float currentrotation = first_wing.rotation.z;

        if ((left && right) || !(left && right))
        {
            first_wing.rotation = Quaternion.Euler(0, 180, -11);
            secend_wing.rotation = Quaternion.Euler(0, 180, 11);
        }

        if (left && !(right))
        {
            first_wing.rotation = Quaternion.Euler(0, 180, -21);
            secend_wing.rotation = Quaternion.Euler(0, 180, 1);
        }

        if (right && !(left))
        {
            first_wing.rotation = Quaternion.Euler(0, 180, -1);
            secend_wing.rotation = Quaternion.Euler(0, 180, 21);
        }

    }
}
