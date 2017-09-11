using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_SpringJoint : Base_Grab {

    protected override void CreateTempJoint()
    {

        SpringJoint sj = gameObject.AddComponent<SpringJoint>();
        sj.breakForce = base.breakForce;
        sj.breakTorque = base.breakTorque;
        //sj.spring = base.spring;
        //sj.damper = base.damper;
    }
    protected override void StartGrab()
    {
        CreateTempJoint();
    }
    protected override void StayGrab()
    {

    }
    protected override void EndGrab()
    {

    }
}
