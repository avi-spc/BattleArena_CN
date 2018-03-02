using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour {

    [SerializeField]
    private RoomLayoutGroup _roomLayoutGroup;
    private RoomLayoutGroup RoomLayoutGroup {
        get { return _roomLayoutGroup; }
    }

    public void OnJoinRoom(string roomName) {

        if (PhotonNetwork.JoinRoom(roomName)) {
        }
        else {
            Debug.Log("Join room failed");
        }

    }
}
