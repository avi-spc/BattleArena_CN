using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    PlayerMovement pm = new PlayerMovement();

    public Transform[] spawnPoint = new Transform[5];
    public int playerID = 0;
    public string character;
    
    private void Awake() {

        playerID = PhotonNetwork.player.ID;
        character = PlayerNetwork.Instance.cha;
    }

    private void Start() {

        Debug.Log(PhotonNetwork.player.ID);

        switch (playerID % 5) {
            case 1: pm.RPC_SpawnPlayer(spawnPoint[0], character);
                break;
            case 2: pm.RPC_SpawnPlayer(spawnPoint[1], character);
                break;
            case 3: pm.RPC_SpawnPlayer(spawnPoint[2], character);
                break;
            case 4: pm.RPC_SpawnPlayer(spawnPoint[3], character);
                break;
            case 0: pm.RPC_SpawnPlayer(spawnPoint[4], character);
                break;
            default: break;
        }

    }

    public void OnDis()
    {
        PhotonNetwork.Disconnect();
    }

}
	
	
