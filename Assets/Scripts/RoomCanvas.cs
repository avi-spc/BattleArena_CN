using UnityEngine;

public class RoomCanvas : MonoBehaviour {

    public void OnStartMatch() {

        PhotonNetwork.LoadLevel(1);

    }

}
