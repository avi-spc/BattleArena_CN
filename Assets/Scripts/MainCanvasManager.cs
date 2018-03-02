﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour {

    public static MainCanvasManager Instance;

    [SerializeField]
    private LobbyCanvas _lobbyCanvas;
    public LobbyCanvas LobbyCanvas {
        get { return _lobbyCanvas; }
    }

    [SerializeField]
    private RoomCanvas _roomCanvas;
    public RoomCanvas RoomCanvas {
        get { return _roomCanvas; }
    }

    private void Awake() {

        Instance = this;

    }
}
