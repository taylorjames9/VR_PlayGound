using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_Child : Base_Grab {

    protected override void StartGrab() {
        transform.SetParent(myGrabber.GrabHandle.transform);
        transform.rotation = Quaternion.identity;
    }

    protected override void EndGrab() {
        if (myOriginalParent == null)
            transform.SetParent(null);
        else
            transform.SetParent(myOriginalParent);
    }

}
