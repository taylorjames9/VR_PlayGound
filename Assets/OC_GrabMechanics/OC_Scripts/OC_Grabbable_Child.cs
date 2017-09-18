using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_Grabbable_Child : OC_Base_Grab {

    protected override void StartGrab(OC_Grabber grabber1) {
        base.StartGrab(grabber1);
        Debug.Log("Did base line.");
        transform.SetParent(grabber1.transform);
        Debug.Log("Did set parent.");

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Did isKinematic line.");

        transform.rotation = Quaternion.identity;
        Debug.Log("Did rotate line.");

    }

    protected override void EndGrab(OC_Grabber grabber1) {

        base.EndGrab(grabber1);
        Debug.Log("This is WHERE WE SHOULD BE RELEASING");
        //if (myOriginalParent == null)
        //    transform.SetParent(null);
        //else
        //    transform.SetParent(myOriginalParent);
        transform.SetParent(null);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }





}
