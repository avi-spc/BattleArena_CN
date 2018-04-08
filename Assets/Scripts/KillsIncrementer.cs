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
    public string[] winLose = new string[5];
    public GameObject WinLosePanel;
    public Text WinLoseText;
   
    // Use this for initialization
    public int j;
    public int timer;

    public GameObject scroller,rankCalc;
    public RankCalc rankCalcInstance;

    PhotonView pv;
    private void Awake() {
        j = 0;

        scroller = GameObject.FindGameObjectWithTag("Scroller");
        rankCalc = GameObject.FindGameObjectWithTag("Rank");
        timer = 2000;
        pv = GetComponent<PhotonView>();
        ePN = new string[PhotonNetwork.countOfPlayers];
        fePN = new string[PhotonNetwork.countOfPlayers];
        winLose = new string[PhotonNetwork.countOfPlayers];

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

        for (int i = 0; i < winLose.Length; i++)
        {
            winLose[i] = "";
        }

    }

    void Start () {
        rankCalcInstance = rankCalc.GetComponent<RankCalc>();
        Debug.Log(PhotonNetwork.countOfPlayers);

        WinLosePanel.SetActive(false);
    }


    // Update is called once per frame
    void Update () {

        timer--;

        if (timer < 0) {
            WinLose();
            WinLosePanel.SetActive(true);
        }

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

        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            GameObject go = scroller.transform.GetChild(i).gameObject;
            go.transform.GetChild(0).GetComponent<Text>().text = rankCalcInstance.fs[i];
        }



        //rankScore = eachPlayerScore;
        //Array.Sort(rankScore);

    }

    private void WinLose()
    {
        for (int i = 0; i < PhotonNetwork.countOfPlayers; i++)
        {
            if (rankCalcInstance.fs[i].Equals("1"))
            {
                winLose[i] = "Winner";
            }
            else
                winLose[i] = "Loser";
        }
    }


}
