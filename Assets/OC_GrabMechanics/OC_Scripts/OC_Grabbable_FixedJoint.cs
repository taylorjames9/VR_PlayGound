using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_Grabbable_FixedJoint : OC_BaseGrabbable
{
    //Touch color
    public Color TouchColor;

    //expose the joint variables here for editing because the joint is added/destroyed at runtime
    // to understand how these variables work in greater depth see documentation for spring joint and fixed joint
    [SerializeField]
    protected float breakForce ;
    [SerializeField]
    protected float breakTorque ;
    [SerializeField]
    protected float tolerance ;
    [SerializeField]
    protected Vector3 joint_anchor ;
    [SerializeField]
    protected float minDistance ;
    [SerializeField]
    protected float maxDistance;

    protected override void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        base.Start();
        //CreateTempJoint();
    }

    protected override void CreateTempJoint(OC_Grabber grabber1)
    {
        if (!GetComponent<FixedJoint>())
        {
            gameObject.AddComponent<FixedJoint>();
            FixedJoint fj = gameObject.GetComponent<FixedJoint>();
            fj.connectedBody = grabber1.GetComponent<Rigidbody>();
            fj.anchor = joint_anchor;
            fj.breakForce = breakForce;
            fj.breakTorque = breakTorque;
            Debug.Log("SHOULD BE CREATING A TEMP JOINT");
        }
    }
    protected override void StartGrab(OC_Grabber grabber1)
    {
        base.StartGrab(grabber1);
        if (!GetComponent<SpringJoint>())
        {
            CreateTempJoint(grabber1);
        }
        //Debug.Log("RAN IMPORTTTTNNNAATT Start GRAB");
    }

    protected override void EndGrab(OC_Grabber grabber1)
    {
        base.EndGrab(grabber1);
        //Debug.Log("END GRAB DESTROYING FIXED JOINT");

        if (GetComponent<FixedJoint>() != null)
        {
            //GetComponent<FixedJoint>().an
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(gameObject.GetComponent<FixedJoint>());
            //Debug.Log("DESTRYOED THE FIXED JOINT");
        }
    }

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

    private Color originalColor;
}
