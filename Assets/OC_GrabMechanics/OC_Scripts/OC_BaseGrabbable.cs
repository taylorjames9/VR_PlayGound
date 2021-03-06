﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


//Intended Usage//
//Attach a "grabbable_" script (a script that inherits from this) to any object that is meant to be grabbed
public abstract class OC_BaseGrabbable : MonoBehaviour
{
    public OC_Grabber MyGrabber { get { return myGrabber; } set { myGrabber = value; } }


    //I tend to leave vars protected unless I have the occasion to use them publicly, then I switch the access level to public
    protected OC_Grabber myGrabber;
    protected Transform myOriginalParent;
    protected bool multiGrabAvailable;
    protected GameObject GrabSpot;
    protected bool AwaitingGrab;
    protected Texture AwaitingGrabVisual;
    protected bool grabbable;
    protected bool StayAttachedOnTeleport;
    protected GameObject GrabAttachSpot;
    protected bool held;

    //public delegate void GrabActive(GameObject grabbedObj, GameObject grabber);
    public delegate void GrabActive(GameObject grabber);
    public static event GrabActive GrabStarted;

    public delegate void GrabFalse(GameObject grabber);
    public static event GrabFalse GrabEnded;

    //if a grab handle is not specified, assume that the attach point is the grabbable object's transform
    protected virtual void Start()
    {
        if (!GrabSpot)
            GrabSpot = gameObject;
    }

    //the next three functions provide basic behaviour. Extend from this base script in order to provide more specific functionality.
    protected virtual void CreateTempJoint(OC_Grabber grabber){}
    protected virtual void StartGrab(OC_Grabber grabber){
        held = true;
        Debug.Log("Start Grab -- from grabbbable");
        myGrabber = grabber;
        grabber.HeldObject = gameObject;
        if (GetComponent<OC_BaseScalable>())
        {
            GrabStarted(grabber.gameObject);
        }
        StartCoroutine(StayGrab(grabber));
    }
    protected virtual IEnumerator StayGrab(OC_Grabber grabber)
    {
        while (grabber.GrabActive)
        {
            yield return null;
        }
            EndGrab(grabber);
            yield return null;
    }
    protected virtual void EndGrab(OC_Grabber grabber)
    {
        held = false;
        myGrabber = null;
        grabber.HeldObject = null;
        if (GetComponent<OC_BaseScalable>())
        {
            GrabEnded(grabber.gameObject);
        }
        ///This is a hack. This shouldn't be here. It should be in a throwable script
        if (GetComponent<OC_BaseThrowable>() != null)
        {
            //GetComponent<Rigidbody>().velocity = (Vector3.one + grabber.GetComponent<Rigidbody>().velocity) * grabber.Strength * GetComponent<OC_ThrowableObject>().ThrowMultiplier;
            GetComponent<Rigidbody>().velocity = (VRTK_DeviceFinder.GetControllerVelocity(grabber.gameObject)) * grabber.Strength * GetComponent<OC_ThrowableObject>().ThrowMultiplier;
            GetComponent<Rigidbody>().angularVelocity = VRTK_DeviceFinder.GetControllerAngularVelocity(grabber.gameObject);
            //GetComponent<Rigidbody>().angularVelocity = grabber.GetComponent<Rigidbody>().angularVelocity;
            if (GetComponent<OC_BaseThrowable>().ZeroGravityThrow)
            {
                GetComponent<Rigidbody>().useGravity = false;
            }

            Debug.Log("THROWING! Veloctiy = "+ GetComponent<Rigidbody>().velocity);
        }
        ///
        Debug.Log("End Grab -- from grabbable");
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Enter");
        if (other.transform.parent != null)
        {
            if (other.transform.parent.parent != null)
            {
                if (other.transform.parent.parent.GetComponent<OC_Grabber>())
                {
                    //Debug.Log("Our other's parent parent is a grabber");
                    //Renderer rend = GetComponent<Renderer>();
                    //rend.material.color = Color.yellow;
                    OC_Grabber grbr = other.transform.parent.transform.parent.GetComponent<OC_Grabber>();
                    if (grbr.GrabActive)
                        StartGrab(grbr);
                }
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        //if (other.transform.parent.transform.parent.GetComponent<OC_Grabber>())
        //{
        //    //Renderer rend = GetComponent<Renderer>();
        //    //rend.material.color = Color.white;
        //    Debug.Log("Trigger Exit");
        //}
    }
}

