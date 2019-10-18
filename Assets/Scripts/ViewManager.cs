using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public static ViewManager instance;

    private List<View> views;

    public Transform root;
    public string firstView;

    public void BackView()
    {
        if (views.Count > 1)
        {
            views.RemoveAt(views.Count - 1);
            views[views.Count - 1].gameObject.SetActive(true);
        }
    }
    public void StartView(string path)
    {
        GameObject viewObj = Resources.Load(path) as GameObject;
        viewObj.transform.parent = root;
        View view = viewObj?.GetComponent<View>();

        if (view)
        {
            if(views.Count > 0) views[views.Count - 1].gameObject.SetActive(false);
            views.Add(view);
        }
        else
        {
            DestroyImmediate(viewObj);
            Debug.LogError(view + "doesnt have View component");
        }
    }

    private void Awake()
    {
        if (instance) DestroyImmediate(this);

        instance = this;
        StartView(firstView);
    }
}
