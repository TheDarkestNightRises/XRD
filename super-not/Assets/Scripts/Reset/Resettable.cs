using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resettable : MonoBehaviour
{
    public abstract void ResetHandler(); 

    public virtual void Start()
    {
        ResetManager.Instance.ResetEvent += ResetHandler;
    }

    public virtual void OnDestroy()
    {
        ResetManager.Instance.ResetEvent -= ResetHandler;
    }
}