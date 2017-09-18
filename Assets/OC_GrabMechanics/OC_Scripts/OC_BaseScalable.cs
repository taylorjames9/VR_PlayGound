using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OC_BaseScalable : MonoBehaviour {

    protected virtual void OnEnable()
    {
        OC_BaseGrabbable.GrabStarted += ScalarAdd;
        OC_BaseGrabbable.GrabEnded += ScalarRemove;
    }

    protected virtual void OnDisable()
    {
        OC_BaseGrabbable.GrabStarted -= ScalarAdd;
        OC_BaseGrabbable.GrabEnded -= ScalarRemove;

    }

    protected void Start()
    {
        Debug.Log("ran start.");
    }


    //if there are 1,2 or however many scalars attachedto the scalable object, and both grip buttons are pressed, 
    protected virtual void SnapShotOfScale()
    {
        snapShotOfScale = transform.localScale;
    }

    public void AttemptScale(List<GameObject> scalarsAttached)
    {
        Debug.Log("Ran attempt scale ... Number of grabbers = "+scalarsAttached.Count);
        if(scalarsAttached.Count >= minScalarNumForScale)
        {

            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.green;
            //Velocity
            //Multiply scale of this scalable object by the velocity of scalar1 and scalar2 (or however many)
            if (scaleByVelocity)
            {
                Debug.Log("We're inside scale and scale by velocity");
                foreach(GameObject sclr in scalarsAttached)
                {
                    Debug.Log("Velocity of scalar obj " +sclr.GetComponent<OC_BaseScalar>().Velocity.ToString());
                }
            }

            //Distance
            //Create a standard distance that the controls are when grip is pressed
            //That standard distance between controller corresponds to the localScale * scaleMultiplier
            if (scaleByDistance)
            {

            }
        }
    }

    public void ScalarAdd(GameObject grabbedObj, GameObject grabber)
    {
        Debug.Log("adding a scalar!");
        if (!scalarsAttachedList.Contains(grabber))
        {
            Debug.Log("this scalars attached list does not contain our grabber attached to this GameObject!");
            if (grabber.Equals(GetComponent<OC_BaseGrabbable>().MyGrabber))
            {
                scalarsAttachedList.Add(grabber);
                Debug.Log("Ran attempt scale ... Number of grabbers = " + scalarsAttachedList.Count);
            }
            AttemptScale(scalarsAttachedList);
        }
    }

    public virtual void ScalarRemove(GameObject grabbedObj, GameObject grabber)
    {
        if (grabber.Equals(GetComponent<OC_Grabber>()))
        {
            scalarsAttachedList.Remove(grabber);
        }
    }


    [Range(1, 5)]
    private float scaleMultiplier;
    [SerializeField]
    public bool scaleByVelocity = true;
    [SerializeField]
    private bool scaleByDistance;
    private bool readyToScale;
    private Vector3 snapShotOfScale;
    private int minScalarNumForScale = 1;
    //Add to the list if your object requires more than two scalars attached
    [SerializeField]
    private List<GameObject> scalarsAttachedList;

}
