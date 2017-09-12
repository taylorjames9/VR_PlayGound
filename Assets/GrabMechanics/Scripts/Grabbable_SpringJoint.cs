using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_SpringJoint : Base_Grab
{

    protected override void Start()
    {
        base.Start();
        //CreateTempJoint();
    }

    protected override void CreateTempJoint(Grabber grabber1)
    {


        gameObject.AddComponent<SpringJoint>();
        SpringJoint sj = gameObject.GetComponent<SpringJoint>();
        sj.connectedBody = grabber1.GetComponent<Rigidbody>();
        //sj.minDistance = 0.5f;
        //sj.maxDistance = 3.0f;
        sj.anchor = new Vector3(0, 0.55f, 0.25f);
        sj.tolerance = 0.05f;
        //sj.breakForce = base.breakForce;
        //sj.breakTorque = base.breakTorque;
        sj.spring = 50f;
        sj.damper = 1f;
        sj.breakForce = 5f;
        sj.breakTorque = 3f;
        Debug.Log("SHOULD BE CREATING A TEMP JOINT");
    }
    protected override void StartGrab(Grabber grabber1)
    {
        base.StartGrab(grabber1);
        if (!GetComponent<SpringJoint>())
        {
            CreateTempJoint(grabber1);
        }
        Debug.Log("RAN IMPORTTTTNNNAATT Start GRAB");
    }

    protected override void EndGrab(Grabber grabber1)
    {
        base.EndGrab(grabber1);
        Debug.Log("END GRAB DESTROYING FIXED JOINT");
        if (GetComponent<SpringJoint>())
        {
            GetComponent<SpringJoint>().connectedBody = null;
            Destroy(gameObject.GetComponent<SpringJoint>());
            Debug.Log("DESTRYOED THE SPRING JOINT");

        }
    }
}
