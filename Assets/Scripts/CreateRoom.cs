﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour {

    [SerializeField]
    private Text _roomName;
    private Text RoomName {
        get { return _roomName; }
    }

    public void OnCreateRoom() {

        RoomOptions roomOptions = new RoomOptions() { isVisible = true, IsOpen = true, MaxPlayers = 5 };

        if (PhotonNetwork.CreateRoom(RoomName.text,roomOptions,TypedLobby.Default)) {
            Debug.Log("Request for room creation sent successfully.");
        }
        else {
            Debug.Log("Request for room creation failed.");
        }
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage) {

        Debug.Log("Room creation failed : " + codeAndMessage);

    }

    private void OnCreatedRoom() {

        Debug.Log("Room created successfully.");

    }
	
}
