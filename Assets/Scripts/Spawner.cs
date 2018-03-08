using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    PlayerMovement pm = new PlayerMovement();

    public Transform[] spawnPoint = new Transform[5];
    public int playerID = 0;
  
    private void Awake() {
        playerID = PhotonNetwork.player.ID; ;
    }

    private void Start() {

        switch (playerID) {
            case 1: pm.RPC_SpawnPlayer(spawnPoint[0]);
                break;
            case 2: pm.RPC_SpawnPlayer(spawnPoint[1]);
                break;
            case 3: pm.RPC_SpawnPlayer(spawnPoint[2]);
                break;
            case 4: pm.RPC_SpawnPlayer(spawnPoint[3]);
                break;
            case 5: pm.RPC_SpawnPlayer(spawnPoint[4]);
                break;
            default: break;
        }

    }
    
}
	
	
