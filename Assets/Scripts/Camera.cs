using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public Transform camer;
    public Transform player_pos;
    public Vector3 distance_from_player;
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        camer.position = player_pos.position + distance_from_player;
    }
}
