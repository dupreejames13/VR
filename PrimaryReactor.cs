using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryReactor : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // public to show button state in the Unity Inspector window
    public GameObject triggerObj;
    public GameObject sprayPart;

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        sprayPart.active = false;
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;

        if (pressed)
        {
            triggerObj.transform.Rotate(0f, 0f, -8.5f);
            sprayPart.active = true;
        }

        else
        {
            triggerObj.transform.Rotate(0f, 0f, 8.5f);
            sprayPart.active = false;
        }
    }
}