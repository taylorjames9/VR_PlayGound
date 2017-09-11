using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Grab : MonoBehaviour
{

    //protected variables

    protected Grabber myGrabber;
    protected Transform myOriginalParent;
    protected bool multiGrabAvailable;
    protected GameObject GrabSpot;
    protected bool AwaitingGrab;
    protected Texture AwaitingGrabVisual;
    protected bool grabbable;
    protected bool StayAttachedOnTeleport;
    protected GameObject GrabAttachSpot;
    protected bool held;

    //joint variables editable here
    protected float spring;
    protected float damper;
    protected float breakForce;
    protected float breakTorque;
    //add/expose more joint variables here as needed

    protected virtual void CreateTempJoint(){}
    protected virtual void StartGrab(Grabber grabber1){
        held = true;
        Debug.Log("Started grabbing.");
    }
    protected virtual void StayGrab(Grabber grabber1)
    {
        Debug.Log("Stay grabbing.");
}
    protected virtual void EndGrab(Grabber grabber1)
    {
        held = false;
        Debug.Log("End grabbing.");

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("LeftHand") || other.name.Equals("RightHand"))
        {
            StartGrab(other.GetComponent<Grabber>());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name.Equals("LeftHand") || other.name.Equals("RightHand"))
        {
            StayGrab(other.GetComponent<Grabber>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("LeftHand") || other.name.Equals("RightHand"))
        {
            EndGrab(other.GetComponent<Grabber>());
        }
    }


}
