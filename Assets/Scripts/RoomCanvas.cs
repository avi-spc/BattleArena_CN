using UnityEngine;
using UnityEngine.UI;

public class RoomCanvas : MonoBehaviour {

    public string character = "";
    public Button[] characterButton = new Button[2];

    public void OnStartMatch() { 

        PhotonNetwork.room.IsOpen = true;
        PhotonNetwork.room.IsVisible = true;
        PhotonNetwork.LoadLevel(2);
        
    }

    public void Cube() {
        PlayerNetwork.Instance.cha = "Cube";
    }
    public void Sphere()
    {
        PlayerNetwork.Instance.cha = "Sphere";
    }

}
