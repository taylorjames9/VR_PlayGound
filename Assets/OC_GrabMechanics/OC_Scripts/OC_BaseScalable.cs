using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OC_BaseScalable : MonoBehaviour {


    public List<GameObject> ScalarsAttachedList { get { return scalarsAttachedList; } set { scalarsAttachedList = value; } }

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
        snapShotOfScaleVec = transform.localScale;
    }

    public void AttemptScale()
    {
        Debug.Log("Ran attempt scale ... Number of grabbers = "+scalarsAttachedList.Count);
        if(scalarsAttachedList.Count >= minScalarNumForScale)
        {

            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.green;
            //Velocity
            //Multiply scale of this scalable object by the velocity of scalar1 and scalar2 (or however many)
            if (scaleByVelocity)
            {
                Debug.Log("We're inside scale and scale by velocity");
                foreach(GameObject sclr in scalarsAttachedList)
                {
                    Debug.Log("Velocity of scalar obj " +sclr.GetComponent<OC_BaseScalar>().Velocity.ToString());
                }
            }

            //Distance
            //Create a standard distance that the controls are when grip is pressed
            //That standard distance between controller corresponds to the localScale * scaleMultiplier
            if (scaleByDistance)
            {
                if (scalarsAttachedList.Count == 2)
                {
                    float dist = Vector3.Distance(scalarsAttachedList[0].transform.position, scalarsAttachedList[1].transform.position);
                    Debug.Log("Scaling by distance. Distance = " + dist);
                    snapShotDistance = dist;
                    snapShotOfScaleFloat = transform.localScale.x;
                    currentlyScaling = true;
                    StartCoroutine(PerformScaling());
                }

            }
        }
    }

    public void ScalarAdd(GameObject grabbedObj, GameObject grabber)
    {
        Debug.Log("adding a scalar!");
        if (!scalarsAttachedList.Contains(grabber))
        {
            Debug.Log("this scalars attached list does not contain our grabber attached to this GameObject!");
            if (grabber.Equals(GetComponent<OC_BaseGrabbable>().MyGrabber.gameObject))
            {
                scalarsAttachedList.Add(grabber);
                Debug.Log("Ran attempt scale ... Number of grabbers = " + scalarsAttachedList.Count);
                AttemptScale();
            }
            
        }
    }

    public virtual void ScalarRemove(GameObject grabbedObj, GameObject grabber)
    {
        //if (grabber.Equals(GetComponent<OC_Grabber>()))
        if(scalarsAttachedList.Contains(grabber))
        {
            scalarsAttachedList.Remove(grabber);
            Debug.Log("Removed a scalar "+grabber.name);
        }
    }

    public virtual IEnumerator PerformScaling()
    {
        while (currentlyScaling)
        {
            if (scalarsAttachedList.Count >= minScalarNumForScale)
            {
                float currDistance = Vector3.Distance(scalarsAttachedList[0].transform.position, scalarsAttachedList[1].transform.position);
                Debug.Log("SnapShot Dist = " + snapShotDistance);
                Debug.Log("Current Dist = " + currDistance);
                //transform.localScale =  Vector3.one * currDistance/snapShotDistance * SnapShotOfScale /*multiplier * distFromUser*/;
                transform.localScale = Vector3.one * ((currDistance / snapShotDistance) * snapShotOfScaleFloat) /*multiplier * distFromUser*/;
                Debug.Log("Current SCALE = " + transform.localScale);
            }
            yield return 0;
        }
        yield return null;
    }


    [Range(1, 5)]
    private float scaleMultiplier =1.0f;
    [SerializeField]
    public bool scaleByVelocity = false;
    [SerializeField]
    private bool scaleByDistance = true;
    private bool readyToScale;
    private Vector3 snapShotOfScaleVec;
    private float snapShotOfScaleFloat;
    private int minScalarNumForScale = 2;
    private bool currentlyScaling;
    private float snapShotDistance;
    //Add to the list if your object requires more than two scalars attached
    [SerializeField]
    private List<GameObject> scalarsAttachedList;

}
