using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveMatch : MonoBehaviour {

    public void OnLeaveMatch() {

        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(1);
    }
}
