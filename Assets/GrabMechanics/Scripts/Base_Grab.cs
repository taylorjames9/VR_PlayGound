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
    protected virtual void StartGrab(){
        held = true;
    }
    protected virtual void StayGrab(){}
    protected virtual void EndGrab(){
        held = false;
    }

}
