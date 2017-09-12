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
        StartCoroutine(StayGrab(grabber1));
    }
    protected virtual IEnumerator StayGrab(Grabber grabber1)
    {
        while (grabber1.GrabActive)
        {
            Debug.Log("Stay grabbing.");
            yield return null;
        }
            EndGrab(grabber1);
            yield return null;
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
            Renderer rend = GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("Specular");
            //rend.material.shader = Shader.PropertyToID;
            //rend.material.SetColor("_SpecColor", Color.yellow);
            rend.material.color = Color.yellow;
            Grabber grbr = other.transform.parent.transform.parent.GetComponent<Grabber>();
            if (grbr.GrabActive)
                StartGrab(other.transform.parent.transform.parent.GetComponent<Grabber>());
        }
    }

    void OnTriggerStay(Collider other)
    {
        //if (other.transform.parent.transform.parent.GetComponent<Grabber>())
        //{
        //    Grabber grbr = other.transform.parent.transform.parent.GetComponent<Grabber>();
        //    //if (grbr.GrabActive)
        //    StayGrab(grbr);
        //    Debug.Log("Trigger Stay");

        //}
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.transform.parent.GetComponent<Grabber>())
        {
            Renderer rend = GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("Specular");
            //rend.material.SetColor("_SpecColor", Color.white);
            rend.material.color = Color.white;

            //Grabber grbr = other.transform.parent.transform.parent.GetComponent<Grabber>();
            //if (!grbr.GrabActive)
            //    EndGrab(other.GetComponent<Grabber>());
            Debug.Log("Trigger Exit");

        }
    }


}
