using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class KillsIncrementer : MonoBehaviour {

    public static KillsIncrementer Instance;

    public int[] eachPlayerKills = new int[5];
    public int[] eachPlayerDeaths = new int[5];
    public int[] eachPlayerScore = new int[5];
    public string[] eachPlayerName = new string[5];
    public string[] ePN = new string[5];
    public string[] fePN = new string[5];
   
    // Use this for initialization
    public int j;

    public GameObject scroller;

    PhotonView pv;
    private void Awake() {
        j = 0;

        scroller = GameObject.FindGameObjectWithTag("Scroller");
        
        pv = GetComponent<PhotonView>();
        ePN = new string[PhotonNetwork.countOfPlayers];
        fePN = new string[PhotonNetwork.countOfPlayers];

        for (int i = 0; i < eachPlayerKills.Length; i++) {
            eachPlayerKills[i] = 0;
        }
        for (int i = 0; i < eachPlayerDeaths.Length; i++)
        {
            eachPlayerDeaths[i] = 0;
        }
        for (int i = 0; i < eachPlayerScore.Length; i++)
        {
            eachPlayerScore[i] = 0;
        }
        for (int i = 0; i < eachPlayerName.Length; i++)
        {
            eachPlayerName[i] = "";
        }

      

    }

    void Start () {
        Debug.Log(PhotonNetwork.countOfPlayers);
    }

    // Update is called once per frame
    void Update () {
        Array.Sort(eachPlayerName);
        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++) {
            ePN[i] = eachPlayerName[4 - i];
        }
        Array.Reverse(ePN);

        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++) {
            fePN[i] = ePN[i].Remove(0,2);
        }


        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            GameObject go = scroller.transform.GetChild(i).gameObject;
            go.transform.GetChild(1).GetComponent<Text>().text = fePN[i];
        }

        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            GameObject go = scroller.transform.GetChild(i).gameObject;
            go.transform.GetChild(2).GetComponent<Text>().text = eachPlayerScore[i].ToString();
        }

        //rankScore = eachPlayerScore;
        //Array.Sort(rankScore);

    }

   
   
}
