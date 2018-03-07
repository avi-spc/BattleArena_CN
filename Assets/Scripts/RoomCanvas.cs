using UnityEngine;

public class RoomCanvas : MonoBehaviour {

    public void OnStartMatch() {

     //   if (PhotonNetwork.isMasterClient) {

            PhotonNetwork.room.IsOpen = true;
            PhotonNetwork.room.IsVisible = true;
            PhotonNetwork.LoadLevel(2);

     //
        
        
    }

}
