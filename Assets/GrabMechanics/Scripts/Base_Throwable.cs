using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Throwable {


    public float Throw_Acceleration { get { return throw_acceleration; } set { throw_acceleration = value; } }
    private float throw_acceleration;

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


}
