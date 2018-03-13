using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCanvas : MonoBehaviour {

    public InputField PlayerName;
    //public string playerName;

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

    public void Update()
    {
        PhotonNetwork.playerName = PlayerName.text.ToString();
        
    }

}
