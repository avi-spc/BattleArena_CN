using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillsIncrementer : MonoBehaviour {

    public static KillsIncrementer Instance;

    public int[] eachPlayerKills = new int[5];
    public int[] eachPlayerDeaths = new int[5];
    public int[] eachPlayerScore = new int[5];
    public string[] eachPlayerName = new string[5];
    // Use this for initialization

    private void Awake() {
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
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
