using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class PlayerNetwork : Photon.MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    [SerializeField]
    public int PlayersInGame = 0;
    //[SerializeField]
    public bool mc, wasAlreadyConnected;
    public int numofplayer = 0;    

    private PhotonView PhotonView;
    public string cha;

	private void Awake () {
        
        Instance = this;
        PhotonView = GetComponent<PhotonView>();
        wasAlreadyConnected = false;

        PlayerName = "Avdhesh#" + Random.Range(10000, 99999);

        PhotonNetwork.sendRate = 200;
        PhotonNetwork.sendRateOnSerialize = 60;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
	}

    private void Update()
    {   
        numofplayer = PhotonNetwork.playerList.Length;
        if (PhotonNetwork.isMasterClient)
            mc = true;
        else
            mc = false;
    }

    public void OnPhotonPlayerDisconnected() {

        PlayersInGame--;
      
    }

    private void OnDisconnectedFromPhoton() {
        wasAlreadyConnected = true;
        
        PhotonNetwork.ReconnectAndRejoin();
        
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
       
        if (scene.name == "Game") {

            if (PhotonNetwork.isMasterClient) {
                
                MasterLoadedGame();
            }
                
            else
                NonMasterLoadedGame();
        }

    }

    private void MasterLoadedGame() {
       // PhotonView.RPC("RPC_SpawnPlayer", PhotonTargets.MasterClient);
        // wasAlreadyConnected = true;
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
        Debug.Log("M spwaned");

    }

    private void NonMasterLoadedGame() {
        
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.OthersBuffered);
      //  wasAlreadyConnected = true;
        Debug.Log("C spwaned");

    }



    [PunRPC]
    private void RPC_LoadGameOthers() {

        PhotonNetwork.LoadLevel(2);

    }

    [PunRPC]
    private void RPC_LoadedGameScene() {

        PlayersInGame++;
        if (PlayersInGame == PhotonNetwork.playerList.Length) {
            Debug.Log("All players are in scene.");
          //  PhotonView.RPC("RPC_SpawnPlayer", PhotonTargets.All);
        }

    }

   // [PunRPC]
   
}
