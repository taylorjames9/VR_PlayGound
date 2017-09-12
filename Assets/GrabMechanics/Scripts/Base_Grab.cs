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

    protected virtual void Start()
    {
        if (!GrabSpot)
            GrabSpot = gameObject;
    }

    protected virtual void CreateTempJoint(Grabber grabber1){}
    protected virtual void StartGrab(Grabber grabber1){
        held = true;
        Debug.Log("Started grabbing.");
        StayGrab(grabber1);
    }
    protected virtual void StayGrab(Grabber grabber1)
    {
        Debug.Log("Stay grabbing.");
        if (!grabber1.GrabActive)
            EndGrab(grabber1);
    }
    protected virtual void EndGrab(Grabber grabber1)
    {
        held = false;
        Debug.Log("End grabbing.");

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.transform.parent.transform.parent.GetComponent<Grabber>())
        {
            Debug.Log("Our other's parent parent is a grabber");
            Grabber grbr = other.transform.parent.transform.parent.GetComponent<Grabber>();
            if (grbr.GrabActive)
                StartGrab(other.transform.parent.transform.parent.GetComponent<Grabber>());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.transform.parent.GetComponent<Grabber>())
        {
            Grabber grbr = other.transform.parent.transform.parent.GetComponent<Grabber>();
            //if (grbr.GrabActive)
                StayGrab(grbr);
            Debug.Log("Trigger Stay");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.transform.parent.GetComponent<Grabber>())
        {
            Grabber grbr = other.transform.parent.transform.parent.GetComponent<Grabber>();
            //if (!grbr.GrabActive)
            //    EndGrab(other.GetComponent<Grabber>());
            Debug.Log("Trigger Exit");

        }
    }


}
