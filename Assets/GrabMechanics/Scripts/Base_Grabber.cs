using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HoloToolkit.Unity.InputModule;
//using UnityEngine.XR.WSA.Input;
using VRTK;


public abstract class Base_Grabber : MonoBehaviour {

    /// <summary>
    /// Emitted when the grab button is pressed.
    /// </summary>
    public event ControllerInteractionEventHandler GrabButtonPressed;
    /// <summary>
    /// Emitted when the grab button is released.
    /// </summary>
    public event ControllerInteractionEventHandler GrabButtonReleased;

    //Intended Usage//
    //Attach grabber script (children of this script) to an object responsible for doing the grabbing - likely a controller

    public Transform GrabHandle { get { return grabAttachSpot; } set { grabAttachSpot = value; } }
    public bool GrabActive { get { return grabActive; } set { grabActive = value; } }


    void OnEnable()
    {
        //Subscribe GrabStart and GrabEnd to InputEvents for Select and DeSelect
        GrabButtonPressed += GrabStart;
        GrabButtonReleased += GrabEnd;

    }

    void Start()
    {
        if (GrabHandle == null)
        {
            GrabHandle = transform;
        }
    }

    //Responsibilities
    public virtual void GrabStart(object sender, ControllerInteractionEventArgs e)
    {
        //Do something
        grabActive = true;
        Debug.Log("Grab Initiated.");
    }

    public virtual void GrabEnd(object sender, ControllerInteractionEventArgs e)
    {
        //Do something
        grabActive = false;
        Debug.Log("Grab Ended.");
    }


    //protected variables
    [SerializeField]
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
