using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour {

    private Animator animator;
    private PhotonView pv;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        pv = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) && pv.isMine) {
            //transform.Translate(transform.forward * Time.deltaTime*5);
            pv.RPC("Run", PhotonTargets.All);
        }
            
        else
            pv.RPC("StopRun", PhotonTargets.All);

        if (Input.GetKey(KeyCode.Mouse0) && pv.isMine)
            animator.SetBool("Attack", true);
        else
            animator.SetBool("Attack", false);
	}

    [PunRPC]
    private void Run() {
        animator.SetBool("Run", true);
    }

    [PunRPC]
    private void StopRun()
    {
        animator.SetBool("Run", false);
    }
}
