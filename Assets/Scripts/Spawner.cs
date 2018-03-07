using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    PlayerMovement pm = new PlayerMovement();

	// Use this for initialization
	void Start () {
        pm.RPC_SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
