using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_Grabbable_FixedJoint : OC_Base_Grab
{
    protected override void Start()
    {
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
}
