﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour {

    public string arenaCreationStatus;
    public GameObject LobNet;
    LobbyNetwork LN;

    [SerializeField]
    private Text _roomName;
    private Text RoomName {
        get { return _roomName; }
    }

    //public bool con=false;
    private void Awake()
    {
        LobNet = GameObject.FindGameObjectWithTag("LN");
    }
    private void Start()
    {
        LN = LobNet.GetComponent<LobbyNetwork>();
        
    }

    public void OnCreateRoom() {

        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 5 };

        roomOptions.PlayerTtl = 6000;
        roomOptions.EmptyRoomTtl = 6000;

        if (PhotonNetwork.CreateRoom(RoomName.text,roomOptions,TypedLobby.Default)) {
            arenaCreationStatus = "Arena creation request sent successfully.";
            Debug.Log("Request for room creation sent successfully.");
        }
        else {
            arenaCreationStatus = "Arena creation request failed";
            Debug.Log("Request for room creation failed.");
        }

      //  con = true;
      //  if (con == true)
       //     idf();
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage) {
        arenaCreationStatus = "Arena creation failed";
        Debug.Log("Room creation failed : " + codeAndMessage);

    }

    private void OnCreatedRoom() {
        arenaCreationStatus = "Arena created successfully";
        Debug.Log("Room created successfully.");

    }

    private void Update()
    {
        LN.arenaStatusText.text = arenaCreationStatus;
    }

    //private void idf() {
    //    PlayerNetwork.Instance.eachPlayerName[((PhotonNetwork.player.ID) - 1) % 5] = PhotonNetwork.playerName;
    //}

}
