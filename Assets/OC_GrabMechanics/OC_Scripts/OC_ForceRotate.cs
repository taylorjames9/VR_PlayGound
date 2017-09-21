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
                StartCoroutine(ForceRotate());
                break;
        }
    }

    protected override void UseEnded(object sender, ControllerInteractionEventArgs e)
    {
        base.UseEnded(sender, e);
        switch (ActivateUseButton)
        {
            case ButtonChoice.Trigger:

                break;
            case ButtonChoice.Touchpad:
                Debug.Log("TOUCHPAD Use is UNNNNactive");
                
                break;
        }
    }

    private IEnumerator ForceRotate()
    {
        Debug.Log("Inside of force rotate...");
        while (touchPadActive)
        {

            Debug.Log("Thumbstick position = " + ControllerEvents.GetTouchpadAxis());
            transform.Rotate(ControllerEvents.GetTouchpadAxis().x, ControllerEvents.GetTouchpadAxis().y, 0.01f);
            yield return 0;
        }
        yield return null;
    }


}
