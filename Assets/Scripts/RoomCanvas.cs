﻿using UnityEngine;
using UnityEngine.UI;

public class RoomCanvas : MonoBehaviour {

    public string character = "";
    //public Button[] characterButton = new Button[5];

    public void OnStartMatch() {
      //  if (PhotonNetwork.isMasterClient)
        //{
            PhotonNetwork.room.IsOpen = true;
            PhotonNetwork.room.IsVisible = true;
            PhotonNetwork.LoadLevel(2);

        //}

        
    }

    public void Dragon() {
        PlayerNetwork.Instance.cha = "DragonM";
    }
    public void Condor()
    {
        PlayerNetwork.Instance.cha = "CondorM";
    }

    public void Chicken()
    {
        PlayerNetwork.Instance.cha = "ChickenM";
    }

}
