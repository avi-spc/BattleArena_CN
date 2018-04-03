using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour {

    [SerializeField]
    private Text _roomName;
    private Text RoomName {
        get { return _roomName; }
    }

    //public bool con=false;

    public void OnCreateRoom() {

        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 5 };

        roomOptions.PlayerTtl = 6000;
        roomOptions.EmptyRoomTtl = 6000;

        if (PhotonNetwork.CreateRoom(RoomName.text,roomOptions,TypedLobby.Default)) {
            Debug.Log("Request for room creation sent successfully.");
        }
        else {
            Debug.Log("Request for room creation failed.");
        }

      //  con = true;
      //  if (con == true)
       //     idf();
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage) {

        Debug.Log("Room creation failed : " + codeAndMessage);

    }

    private void OnCreatedRoom() {

        Debug.Log("Room created successfully.");

    }

    //private void idf() {
    //    PlayerNetwork.Instance.eachPlayerName[((PhotonNetwork.player.ID) - 1) % 5] = PhotonNetwork.playerName;
    //}
	
}
