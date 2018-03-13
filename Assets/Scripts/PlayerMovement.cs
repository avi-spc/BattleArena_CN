using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : Photon.MonoBehaviour {

    public static PlayerMovement Instance;
   // [SerializeField]
    public Transform selfSpawnTransform;
    private PhotonView PhotonView;
    private Vector3 TargetPosition;
    private Quaternion TargetRotation;
    public GameObject cam;
    public GameObject playerGameObject;

    public int Health;

    private void Awake() {

        Instance = this;
        PhotonView = GetComponent<PhotonView>();
        Health = 100;
    }

    private void Start()
    {
        if (PhotonView.isMine)
        {
            cam.SetActive(true);
        }
        else { cam.SetActive(false);
        }

    }

    void Update () {

        if (PhotonView.isMine/* && PhotonNetwork.connectionState == ConnectionState.Connected*/) {
            CheckInput();            
        }
        else
            SmoothMovement();

        if (Health <= 0)
        {
            gameObject.SetActive(false);
            Invoke("FurtherRespawn", 2f);
            //StartCoroutine(FurtherRespawn(selfSpawnTransform));
        }
        
    }

    

    public void RPC_SpawnPlayer(Transform spawnPoint, string shape)
    {

        //float randomHeight = Random.Range(4, 10f);
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", shape), spawnPoint.position , Quaternion.identity, 0);
        //selfSpawnTransform = spawnPoint;
       // PlayerNetwork.Instance.CurrentPlayer = playerGameObject.GetComponent<PlayerMovement>();

    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

        if (stream.isWriting) {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(Health);
        }
        else {
            TargetPosition = (Vector3) stream.ReceiveNext();
            TargetRotation = (Quaternion) stream.ReceiveNext();
            Health = (int) stream.ReceiveNext();
        }

        

    }

    private void SmoothMovement() {

        transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.2f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, 500 * Time.deltaTime);

    }

    private void CheckInput() {

        float moveSpeed = 100f;
        float rotateSpeed = 500f;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += transform.forward * vertical * moveSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, horizontal * rotateSpeed * Time.deltaTime, 0));

    }
    private void OnTriggerEnter(Collider collider)
    {


        //if (!PhotonNetwork.isMasterClient)
        //    return;

        // PhotonView photonView = collider.GetComponent<PhotonView>();
        if (collider.gameObject.tag == "Armor") {
           // Health -= 10;
            if (PhotonView != null && PhotonView.isMine) {
                Health -= 10;
                PlayerManagement.Instance.ModifyHealth(PhotonView.owner, Health);
            }
        }
        


    }

    private void FurtherRespawn() {

        Health = 100;
       gameObject.SetActive(true);
        gameObject.transform.position = selfSpawnTransform.position;

        //yield return new WaitForSeconds(4f);

    }
}
