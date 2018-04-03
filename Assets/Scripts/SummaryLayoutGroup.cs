using System.Collections.Generic;
using UnityEngine;

public class SummaryLayoutGroup : MonoBehaviour
{

    [SerializeField]
    private GameObject _summaryListingPrefab;
    private GameObject SummaryListingPrefab {
        get { return _summaryListingPrefab; }
    }


    private void Start()
    {
        GameObject summaryListingObject = Instantiate(SummaryListingPrefab);
        summaryListingObject.transform.SetParent(transform, false);

        RoomListing roomListing = summaryListingObject.GetComponent<RoomListing>();
       // RoomListingButtons.Add(roomListing);
    }

    private void Update()
    {
        

    }

}
