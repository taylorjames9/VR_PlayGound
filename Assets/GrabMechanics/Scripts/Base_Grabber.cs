using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HoloToolkit.Unity.InputModule;
//using UnityEngine.XR.WSA.Input;


public abstract class Base_Grabber : MonoBehaviour {



    //Intended Usage//
    //Attach grabber script (children of this script) to an object responsible for doing the grabbing - likely a controller

    public Transform GrabHandle { get { return grabAttachSpot; } set { grabAttachSpot = value; } }



    void OnEnable()
    {
        //Subscribe GrabStart and GrabEnd to InputEvents for Select and DeSelect
    }

    //Responsibilities
    public virtual void GrabStart()
    {
        //Do something
        grabActive = true;
        Debug.Log("Grab Initiated.");
    }

    public virtual void GrabEnd()
    {
        //Do something
        grabActive = false;
        Debug.Log("Grab Ended.");
    }


    //protected variables
    protected Transform grabAttachSpot;
    protected bool grabActive;
    protected float grabForgivenessRadius;
    protected ActiveGrabButton activateGrabButton;

}

public enum ActiveGrabButton{
    None,
    Trigger,
    Grip,
    Touchpad
}
