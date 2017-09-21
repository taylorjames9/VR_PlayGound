using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OC_ForceRotate : OC_BaseUsable
{

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void UseStarted(object sender, ControllerInteractionEventArgs e)
    {
        base.UseStarted(sender, e);
        switch (ActivateUseButton)
        {
            case ButtonChoice.Trigger:

                break;
            case ButtonChoice.Touchpad:
                Debug.Log("TOUCHPAD Use is active");
                ForceRotate();
                break;
        }
    }

    protected override void UseEnded(object sender, ControllerInteractionEventArgs e)
    {
        base.UseEnded(sender, e);
    }

    private IEnumerator ForceRotate()
    {
        while (touchPadActive)
        {

            Debug.Log("Thumbstick position = " + ControllerEvents.GetTouchpadAxis());
            yield return 0;
        }
        yield return null;
    }


}
