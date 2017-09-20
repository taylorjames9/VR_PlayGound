using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_Grabbable_TrackFollow : OC_BaseGrabbable
{

    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    private Rigidbody rb;
    //private Vector3 mytransform = target;

    protected override void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    protected override void StartGrab(OC_Grabber grabber1)
    {

        base.StartGrab(grabber1);
        target = grabber1.gameObject;
        rb.useGravity = false;
    }
    ////protected override void StayGrab(Grabber grabber1)
    ////{

    ////    StartCoroutine(FollowGrab());
    ////}
    protected override void EndGrab(OC_Grabber grabber1)
    {
        base.EndGrab(grabber1);
        rb.useGravity = true;
        target = null;
    }

    ////follow the object
    //IEnumerator FollowGrab()
    //{
    //    while (held)
    //    {
    //        GrabAttachSpot.transform.position = myGrabber.GrabHandle.transform.position;
    //        //Do more...
    //        yield return 0;
    //    }
    //    yield return null;
    //}

    void Update()
    {
        if(target)
            // Time.time/50f
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.time / 5000f);
        //rotate to look at the player
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);

        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2.0f);
        //move towards the player
        // transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    public Color TouchColor;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = TouchColor;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
    }

    private Color originalColor;

}
