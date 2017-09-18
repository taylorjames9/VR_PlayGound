﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HoloToolkit.Unity.InputModule;
//using UnityEngine.XR.WSA.Input;
using VRTK;


public abstract class OC_Base_Grabber : MonoBehaviour {

    /// <summary>
    /// Emitted when the grab button is pressed.
    /// </summary>
    public event ControllerInteractionEventHandler GrabButtonPressed;
    /// <summary>
    /// Emitted when the grab button is released.
    /// </summary>
    public event ControllerInteractionEventHandler GrabButtonReleased;

    [Tooltip("The controller to listen for the events on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
    public VRTK_ControllerEvents ControllerEvents;

    //Intended Usage//
    //Attach grabber script (children of this script) to an object responsible for doing the grabbing - likely a controller

    public Transform GrabHandle { get { return grabAttachSpot; } set { grabAttachSpot = value; } }
    public bool GrabActive { get { return grabActive; } set { grabActive = value; } }
    public GameObject HeldObject { get { return heldObject; } set { heldObject = value; } }



    protected virtual void OnEnable()
    {
        //Subscribe GrabStart and GrabEnd to InputEvents for Select and DeSelect
        /////GrabButtonPressed += GrabStart;
        /////GrabButtonReleased += GrabEnd;
        ControllerEvents.GripPressed += GrabStart;
        ControllerEvents.GripReleased += GrabEnd;

        //ControllerEvents.grab += GrabEnd;
        Debug.Log("Ran Enabled on BASE grabber.");
    }

    protected virtual void OnDisable()
    {

        ControllerEvents.GripPressed -= GrabStart;
        ControllerEvents.GripReleased -= GrabEnd;

        //ControllerEvents.grab += GrabEnd;
        Debug.Log("Ran Disabled on BASE grabber.");
    }

    void Start()
    {
        if (GrabHandle == null)
        {
            GrabHandle = transform;
        }
    }

    //private void Update()
    //{
    //    if (ControllerEvents.)
    //    {
    //        grabActive = true;

    //    } else
    //    {
    //        grabActive = false;
    //    }
    //    Debug.Log("Grab Active = " + grabActive);
    //}

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
    //protected GrabButton activateGrabButton;
    private bool holding;
    private GameObject heldObject;

}

public enum ActiveGrabButton{
    None,
    Trigger,
    Grip,
    Touchpad
}