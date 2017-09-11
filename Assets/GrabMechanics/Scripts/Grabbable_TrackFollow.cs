using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_TrackFollow : Base_Grab {

    protected override void StartGrab(Grabber grabber1)
    {
        StayGrab(grabber1);
    }
    protected override void StayGrab(Grabber grabber1)
    {

        StartCoroutine(FollowGrab());
    }
    protected override void EndGrab(Grabber grabber1)
    {
        
    }
    
    //follow the object
    IEnumerator FollowGrab()
    {
        while (held)
        {
            GrabAttachSpot.transform.position = myGrabber.GrabHandle.transform.position;
            //Do more...
            yield return 0;
        }
        yield return null;
    }
}
