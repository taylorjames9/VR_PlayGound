using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Grabber : Base_Grabber {



    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void GrabStart(object sender, ControllerInteractionEventArgs e)
    {
        //Do something
        //preform animation
        //change controller model 
        base.GrabStart(sender, e);
    }

    public override void GrabEnd(object sender, ControllerInteractionEventArgs e)
    {
        //Do something
        base.GrabEnd(sender, e);

        //preform animation
        //change controller model 
    }

}
