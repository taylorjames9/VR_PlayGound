using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_Child : Base_Grab {

    protected override void StartGrab(Grabber grabber1) {
        base.StartGrab(grabber1);
        Debug.Log("Did base line.");
        transform.SetParent(grabber1.transform);
        Debug.Log("Did set parent.");

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Did isKinematic line.");

        transform.rotation = Quaternion.identity;
        Debug.Log("Did rotate line.");

    }

    protected override void EndGrab(Grabber grabber1) {
        base.EndGrab(grabber1);
        if (myOriginalParent == null)
            transform.SetParent(null);
        else
            transform.SetParent(myOriginalParent);
    }





}
