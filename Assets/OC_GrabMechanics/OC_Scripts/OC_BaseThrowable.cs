using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OC_BaseThrowable: MonoBehaviour {


    public float ThrowMultiplier { get { return throwMultiplier; } set { throwMultiplier = value; } }
    public bool ZeroGravityThrow { get { return zeroGravityThrow; } set { zeroGravityThrow = value; } }

    protected virtual void BeginThrow()
    {
        Debug.Log("Begin throw detected.");
    }

    protected virtual void MidThrow()
    {
        Debug.Log("mid throw...");
    }

    protected virtual void ReleaseThrow()
    {
        Debug.Log("Throw release...");
    }

    protected virtual void OnThrowCanceled()
    {
        Debug.Log("Throw canceled");
    }

    [SerializeField]
    private float throwMultiplier;

    [SerializeField]
    private bool zeroGravityThrow;

}
