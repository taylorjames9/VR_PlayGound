using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_GrabbableSimple : OC_BaseGrabbable { 

    private Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Specify the target and turn off gravity. Otherwise gravity will interfere with desired grab effect
    /// </summary>
    protected override void StartGrab(OC_Grabber grabber1)
    {
        base.StartGrab(grabber1);
        if(rb)
            rb.useGravity = false;
        Debug.Log("Grabbable Simple knows that it's being grabbed");
    }

    /// <summary>
    /// On release turn garvity back on the so the object falls and set the target back to null
    /// </summary>
    protected override void EndGrab(OC_Grabber grabber1)
    {
        base.EndGrab(grabber1);
        if(rb)
            rb.useGravity = true;
    }

    private void Update()
    {
        if (myGrabber)
        {
            if(GetComponent<OC_ScalableObject>().ScalarsAttachedList.Count==1)
                transform.position = myGrabber.GrabHandle.position;
        }
    }

}
