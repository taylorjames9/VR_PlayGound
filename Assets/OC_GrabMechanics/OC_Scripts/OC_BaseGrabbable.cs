using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public delegate void GrabActive(GameObject grabbedObj, GameObject grabber);
    public static event GrabActive GrabStarted;

    public delegate void GrabFalse(GameObject grabbedObj, GameObject grabber);
    public static event GrabFalse GrabEnded;

    //expose the joint variables here for editing because the joint is added/destroyed at runtime
    // to understand how these variables work in greater depth see documentation for spring joint and fixed joint
    [SerializeField]
    protected float spring = 50f;
    [SerializeField]
    protected float damper = 1f;
    [SerializeField]
    protected float breakForce = 4f;
    [SerializeField]
    protected float breakTorque = 2f;
    [SerializeField]
    protected float tolerance = 0.05f;
    [SerializeField]
    protected Vector3 joint_anchor = new Vector3(0, 0.05f, 0.05f);
    [SerializeField]
    protected float minDistance = 0.25f;
    [SerializeField]
    protected float maxDistance;


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
        Debug.Log("Start Grab");
        myGrabber = grabber;
        grabber.HeldObject = gameObject;
        GrabStarted(gameObject, grabber.gameObject);
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
        GrabEnded(gameObject, grabber.gameObject);
        Debug.Log("End Grab");
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.transform.parent.transform.parent.GetComponent<OC_Grabber>())
        {
            Debug.Log("Our other's parent parent is a grabber");
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.yellow;
            OC_Grabber grbr = other.transform.parent.transform.parent.GetComponent<OC_Grabber>();
            if (grbr.GrabActive)
                StartGrab(grbr);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.transform.parent.GetComponent<OC_Grabber>())
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.white;
            Debug.Log("Trigger Exit");
        }
    }
}

