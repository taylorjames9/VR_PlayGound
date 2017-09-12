using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_SpringJoint : Base_Grab {

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
        sj.anchor = new Vector3(0, 1.0f, 0.5f);
        sj.tolerance = 0.05f;
        //sj.breakForce = base.breakForce;
        //sj.breakTorque = base.breakTorque;
        sj.spring = 10f;
        sj.damper = 0.5f;
        sj.breakForce = 5;
        sj.breakTorque = 5;
        Debug.Log("SHOULD BE CREATING A TEMP JOINT");
    }
    protected override void StartGrab(Grabber grabber1)
    {
        base.StartGrab(grabber1);
        CreateTempJoint(grabber1);
        Debug.Log("RAN IMPORTTTTNNNAATT Start GRAB");
    }
    protected override void StayGrab(Grabber grabber1)
    {
        base.StayGrab(grabber1);
    }
    protected override void EndGrab(Grabber grabber1)
    {
        base.EndGrab(grabber1);
        Debug.Log("END GRAB DESTROYING FIXED JOINT");
        if (GetComponent<SpringJoint>())
        {
            GetComponent<SpringJoint>().connectedBody = null;
            Destroy(gameObject.GetComponent<SpringJoint>());
        }
    }
}
