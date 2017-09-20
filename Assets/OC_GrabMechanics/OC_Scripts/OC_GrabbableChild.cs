using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_GrabbableChild : OC_BaseGrabbable
{

    protected override void StartGrab(OC_Grabber grabber1) {
        base.StartGrab(grabber1);
        //base.GrabStarted(gameObject, grabber.gameObject);

        Debug.Log("Did base line.");
        transform.SetParent(grabber1.transform);
        Debug.Log("Did set parent.");

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Did isKinematic line.");

    }

    protected override void EndGrab(OC_Grabber grabber1) {

        base.EndGrab(grabber1);
        //OC_BaseGrabbable.GrabEnded(gameObject, grabber1.gameObject);
        Debug.Log("This is WHERE WE SHOULD BE RELEASING");
        //if (myOriginalParent == null)
        //    transform.SetParent(null);
        //else
        //    transform.SetParent(myOriginalParent);
        transform.SetParent(null);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
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

    protected override void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        base.Start();
        //CreateTempJoint();
    }

    private Color originalColor;
}
