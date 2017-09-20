using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_GrabbableChild : OC_BaseGrabbable
{

    protected override void StartGrab(OC_Grabber grabber1) {
        base.StartGrab(grabber1);
        //base.GrabStarted(gameObject, grabber.gameObject);

        Debug.Log("Did base line.");
        transform.SetParent(grabber1.transform);
        Debug.Log("Did set parent.");

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Did isKinematic line.");

    }

    protected override void EndGrab(OC_Grabber grabber1) {

        base.EndGrab(grabber1);
        //OC_BaseGrabbable.GrabEnded(gameObject, grabber1.gameObject);
        Debug.Log("This is WHERE WE SHOULD BE RELEASING");
        //if (myOriginalParent == null)
        //    transform.SetParent(null);
        //else
        //    transform.SetParent(myOriginalParent);
        transform.SetParent(null);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    //private void Update()
    //{
    //    if (myGrabber)
    //    {
    //        if (GetComponent<OC_ScalableObject>().ScalarsAttachedList.Count == 1)
    //            transform.position = myGrabber.GrabHandle.position;
    //    }
    //}
}
