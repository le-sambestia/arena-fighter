using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteract : Interactable
{
    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInterect()
    {
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stopped looking at " + gameObject.name);
    }
}
