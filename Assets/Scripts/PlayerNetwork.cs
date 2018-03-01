using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }

	// Use this for initialization
	private void Awake () {

        Instance = this;

        PlayerName = "Avdhesh#" + Random.Range(10000, 99999);
	}
	
}
