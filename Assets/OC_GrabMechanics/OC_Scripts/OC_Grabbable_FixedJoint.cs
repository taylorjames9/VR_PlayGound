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

    protected override void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        base.Start();
        //CreateTempJoint();
    }

    protected override void CreateTempJoint(OC_Grabber grabber1)
    {

        gameObject.AddComponent<FixedJoint>();
        FixedJoint sj = gameObject.GetComponent<FixedJoint>();
        sj.connectedBody = grabber1.GetComponent<Rigidbody>();
        sj.anchor = new Vector3(0, 0.05f, 0.05f);
        sj.breakForce = 4f;
        sj.breakTorque = 2.0f;
        Debug.Log("SHOULD BE CREATING A TEMP JOINT");
    }
    protected override void StartGrab(OC_Grabber grabber1)
    {
        base.StartGrab(grabber1);
        if (!GetComponent<SpringJoint>())
        {
            CreateTempJoint(grabber1);
        }
        Debug.Log("RAN IMPORTTTTNNNAATT Start GRAB");
    }

    protected override void EndGrab(OC_Grabber grabber1)
    {
        //base.EndGrab(grabber1);
        Debug.Log("END GRAB DESTROYING FIXED JOINT");

        if (GetComponent<FixedJoint>() != null)
        {
            //GetComponent<FixedJoint>().an
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(gameObject.GetComponent<FixedJoint>());
            Debug.Log("DESTRYOED THE FIXED JOINT");
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
