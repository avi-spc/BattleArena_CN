using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RankCalc : MonoBehaviour {

    GameObject KI;
    KillsIncrementer KII;

    public int[] rankScore = new int[5];
    public int[] rS = new int[5];
    public string[] s = new string[5];
    public string[] fs = new string[5];
    public string[] d = new string[5];

    PhotonView pv;

	// Use this for initialization
	void Start () {
        rankScore = new int[PhotonNetwork.countOfPlayers];
        rS = new int[PhotonNetwork.countOfPlayers];
        s = new string[PhotonNetwork.countOfPlayers];
        fs = new string[PhotonNetwork.countOfPlayers];
        d = new string[PhotonNetwork.countOfPlayers];
        
        KI = GameObject.FindGameObjectWithTag("Kills");
        KII = KI.GetComponent<KillsIncrementer>();

        pv = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
        pv.RPC("SetRank", PhotonTargets.AllBuffered);
    }

    [PunRPC]
    private void SetRank() {
        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            rankScore[i] = KII.eachPlayerScore[i];
        }

        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            rS[i] = Int32.Parse(rankScore[i].ToString() + i);
        }


        Array.Reverse(rS);

        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            s[i] = (rS[i]).ToString()+(i+1);
        }

        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            fs[Int32.Parse(s[i].Substring(s[i].Length - 2, 1))] = s[i].Substring(s[0].Length - 1);
        }



    }
}
