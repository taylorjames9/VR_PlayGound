using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_FixedJoint : Base_Grab {

    protected override void CreateTempJoint() {
        
        FixedJoint fj = gameObject.AddComponent<FixedJoint>();
        fj.breakForce = base.breakForce;
        fj.breakTorque = base.breakTorque;
        //fj.spring = base.spring;
        //fj.damper = base.damper;
    }
    protected override void StartGrab(Grabber grabber1){
        CreateTempJoint();
    }
    protected override void StayGrab(Grabber grabber1) {

    }
    protected override void EndGrab(Grabber grabber1){

    }
}
