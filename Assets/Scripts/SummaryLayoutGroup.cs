using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryLayoutGroup : MonoBehaviour
{

    [SerializeField]
    private GameObject _summaryListingPrefab;
    private GameObject SummaryListingPrefab {
        get { return _summaryListingPrefab; }
    }

    PhotonView pv;

    private void Awake()
    {
        pv = gameObject.GetComponent<PhotonView>();
    }

    private void Start()
    {
        
        pv.RPC("playerDetails", PhotonTargets.All);
       // RoomListingButtons.Add(roomListing);
    }

    private void Update()
    {
        

    }

    [PunRPC]
    private void playerDetails() {
        GameObject summaryListingObject = Instantiate(SummaryListingPrefab);
        summaryListingObject.transform.SetParent(transform, false);

        Text[] summaryChildren = summaryListingObject.GetComponentsInChildren<Text>();
        //switch (PhotonNetwork.player.ID % 5) {
        //    case 1: summaryChildren[1].text = KillsIncrementer.Instance.eachPlayerName[0];
        //        break;
        //    case 2: summaryChildren[1].text = KillsIncrementer.Instance.eachPlayerName[1];
        //        break;
        //    default:
        //        break;
        //}
        
        //RoomListing roomListing = summaryListingObject.GetComponent<RoomListing>();
    }

}
