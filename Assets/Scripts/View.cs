using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    private void OnEnable()
    {
        OnCreate();
    }
    private void OnDisable()
    {
        OnClose();
    }
    private void OnDestroy()
    {
        
    }

    protected virtual void OnCreate()
    {
        Debug.Log("View is created!");
    }
    protected virtual void OnClose()
    {
        Debug.Log("View is closed!");
    }
}
