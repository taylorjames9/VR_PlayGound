using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_TrackFollow : Base_Grab {

    protected override void StartGrab()
    {
        StayGrab();
    }
    protected override void StayGrab()
    {

        StartCoroutine(FollowGrab());
    }
    protected override void EndGrab()
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
