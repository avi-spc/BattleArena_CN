using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private int PlayersInGame = 0;

    private PhotonView PhotonView;
	
	private void Awake () {

        Instance = this;
        PhotonView = GetComponent<PhotonView>();

        PlayerName = "Avdhesh#" + Random.Range(10000, 99999);

        PhotonNetwork.sendRate = 200;
        PhotonNetwork.sendRateOnSerialize = 60;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {

        if (scene.name == "Game") {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            else
                NonMasterLoadedGame();
        }

    }

    private void MasterLoadedGame() {

        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);

    }

    private void NonMasterLoadedGame() {

        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);

    }

    [PunRPC]
    private void RPC_LoadGameOthers() {

        PhotonNetwork.LoadLevel(1);

    }

    [PunRPC]
    private void RPC_LoadedGameScene() {

        PlayersInGame++;
        if (PlayersInGame == PhotonNetwork.playerList.Length) {
            Debug.Log("All players are in scene.");
            PhotonView.RPC("RPC_SpawnPlayer", PhotonTargets.All);
        }

    }

    [PunRPC]
    private void RPC_SpawnPlayer() {

        float randomHeight = Random.Range(0, 10f);
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Cube"), Vector3.up * randomHeight, Quaternion.identity,0);

    }
}
