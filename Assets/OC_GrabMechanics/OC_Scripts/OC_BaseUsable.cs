using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public abstract class OC_BaseUsable : MonoBehaviour {

    public ButtonChoice ActivateUseButton;

    //fires an event called UseActive
    public delegate void UseActivated();
    public static event UseActivated UseStartedEvent;

    public delegate void UseDeactivated();
    public static event UseDeactivated UseEndedEvent;

    [Tooltip("The controller to listen for the events on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
    public VRTK_ControllerEvents ControllerEvents;

    protected virtual void OnEnable()
    {
        switch (ActivateUseButton)
        {
            case ButtonChoice.Trigger:
                ControllerEvents.TriggerPressed += UseStarted;
                ControllerEvents.TriggerReleased += UseEnded;
                break;
            case ButtonChoice.Touchpad:
                ControllerEvents.TouchpadTouchStart += UseStarted;
                ControllerEvents.TouchpadTouchEnd += UseEnded;
                break;
        }

    }

    protected virtual void OnDisable()
    {
        switch (ActivateUseButton)
        {
            case ButtonChoice.Trigger:
                ControllerEvents.TriggerPressed -= UseStarted;
                ControllerEvents.TriggerReleased -= UseEnded;
                break;
            case ButtonChoice.Touchpad:
                ControllerEvents.TouchpadTouchStart -= UseStarted;
                ControllerEvents.TouchpadTouchEnd -= UseEnded;
                break;

        }
    }

    protected virtual void UseStarted(object sender, ControllerInteractionEventArgs e)
    {
        touchPadActive = true;
        UseStartedEvent();
        //switch(ActivateUseButton){
        //    case ButtonChoice.Trigger:

        //    break;
        //    case ButtonChoice.Touchpad:
        //        Debug.Log("TOUCHPAD Use is active");
        //        UseStartedEvent();
        //        break;
        //}
    }

    protected virtual void UseEnded(object sender, ControllerInteractionEventArgs e)
    {
        touchPadActive = false;

        //switch (ActivateUseButton)
        //{
        //    case ButtonChoice.Trigger:

        //        break;
        //    case ButtonChoice.Touchpad:
        //        Debug.Log("TOUCHPAD Use is UNNNNNAAAActive");
        //        UseEndedEvent();
        //        break;
        //}
    }




    protected bool touchPadActive;

}
