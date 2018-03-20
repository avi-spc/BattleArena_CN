using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : Photon.MonoBehaviour {

    public static PlayerMovement Instance;
   // [SerializeField]
    public Text _playerHealth;
    public Image healthFG;
    public Transform selfSpawnTransform;
    private PhotonView PhotonView;
    private Vector3 TargetPosition;
    private Quaternion TargetRotation;
    public GameObject cam;
    public GameObject playerGameObject, canvas, target;
    private Camera c;

    Vector3 d = new Vector3(Screen.width / 2, Screen.width / 2,0);

    public float max_health, curr_health, health;

    private void Awake() {

        
        Instance = this;
        PhotonView = GetComponent<PhotonView>();
        curr_health = max_health = 100;
        _playerHealth = GetComponentInChildren<Text>();
        c = cam.GetComponent<Camera>();
        health = 10;
        target = GameObject.FindGameObjectWithTag("target");   
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

        //Vector3 screenPos = Camera.main.WorldToScreenPoint(d);


        //    target.transform.position = d;
        //canvas.transform.rotation = Quaternion.LookRotation(target.transform.forward);

        //canvas.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        Debug.DrawRay(canvas.transform.position, canvas.transform.forward * 1000);

        if (PhotonView.isMine && PhotonNetwork.connectionState == ConnectionState.Connected) {
            CheckInput();
        }
        else
            SmoothMovement();

        if (curr_health <= 0)
        {
            gameObject.SetActive(false);
            Invoke("FurtherRespawn", 2f);
            //StartCoroutine(FurtherRespawn(selfSpawnTransform));
        }

     //   if (!PhotonView.isMine) {
            _playerHealth.text = PlayerNetwork.Instance.PlayerName;

        //}

       

        if (PhotonView.isMine)
        {
            GameUI.Instance.playerHealth.text = curr_health.ToString();
            
            //  PhotonView.RPC("RPC_PlayerUICameraFollow", PhotonTargets.OthersBuffered);

        }

        
        


    }



    public void RPC_SpawnPlayer(Transform spawnPoint, string shape) {
        
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", shape), spawnPoint.position , Quaternion.identity, 0);

    }

    [PunRPC]
    private void RPC_PlayerUICameraFollow() {

        canvas.transform.LookAt(this.cam.transform);

    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

        if (stream.isWriting) {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(curr_health);
        }
        else {
            TargetPosition = (Vector3) stream.ReceiveNext();
            TargetRotation = (Quaternion) stream.ReceiveNext();
            curr_health = (float) stream.ReceiveNext();
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
          //  Debug.Log(collider.gameObject.GetPhotonView());
            if (PhotonView != null && PhotonView.isMine) {
                curr_health -= health;
                healthFG.fillAmount = curr_health / max_health;
                PlayerManagement.Instance.ModifyHealth(PhotonView.owner, curr_health);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PhotonView pv;
        if (collision.gameObject.GetPhotonView() != null && PhotonView.isMine) {
            pv = collision.gameObject.GetPhotonView();
            Debug.Log(pv.viewID);

        }
            
    }

    private void FurtherRespawn() {

       curr_health = 100;
       gameObject.SetActive(true);
       gameObject.transform.position = selfSpawnTransform.position;

    }
}
