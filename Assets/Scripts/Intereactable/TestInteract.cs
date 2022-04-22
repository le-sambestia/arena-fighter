using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteract : Interactable
{
    public override void OnFocus()
    {
        Debug.Log("Looking at " + gameObject.name);
    }

    public override void OnInterect()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        Debug.Log("Stopped looking at " + gameObject.name);
    }
}
