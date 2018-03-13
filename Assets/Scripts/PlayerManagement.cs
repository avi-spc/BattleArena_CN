using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{

    public static PlayerManagement Instance;
    private PhotonView PhotonView;

    private List<PlayerStats> PlayerStats = new List<PlayerStats>();
    [SerializeField]
    private int h;

    private void Awake()
    {

        Instance = this;
        PhotonView = GetComponent<PhotonView>();

    }

    private void Update()
    {
        h = PlayerMovement.Instance.Health;
    }

    public void AddPlayerStats(PhotonPlayer photonPlayer)
    {

        int index = PlayerStats.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if (index == -1)
        {
            PlayerStats.Add(new PlayerStats(photonPlayer, h));
        }
        
    }

    public void ModifyHealth(PhotonPlayer photonPlayer, int healthValue)
    {
        
        int index = PlayerStats.FindIndex(x => x.PhotonPlayer == photonPlayer);
        
        if (index != -1)
        {
            PlayerStats playerStats = PlayerStats[index];
            playerStats.Health = healthValue;
            Debug.Log(playerStats.Health);
            //PlayerNetwork.Instance.ChangeHealth(photonPlayer, playerStats.Health);
        }

    }

}

public class PlayerStats
{

    public PlayerStats(PhotonPlayer photonPlayer, int health)
    {

        PhotonPlayer = photonPlayer;
        Health = health;
       
    }

    public readonly PhotonPlayer PhotonPlayer;
    public int Health;

}

