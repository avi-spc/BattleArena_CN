using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovement : Photon.MonoBehaviour {

    private PhotonView PhotonView;
    private Vector3 TargetPosition;
    private Quaternion TargetRotation;
    public GameObject cam;

    private void Awake() {

        PhotonView = GetComponent<PhotonView>();
        //cam = GetComponent<GameObject>();
        //  MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
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

	}

    public void RPC_SpawnPlayer()
    {

        float randomHeight = Random.Range(0, 10f);
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Cube"), Vector3.up * randomHeight, Quaternion.identity, 0);
        
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

        if (stream.isWriting) {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else {
            TargetPosition = (Vector3) stream.ReceiveNext();
            TargetRotation = (Quaternion) stream.ReceiveNext();
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
}
