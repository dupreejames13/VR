using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingController : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // public to show button state in the Unity Inspector window
    public GameObject triggerObj;
    public GameObject sprayPart;
    public SpotDrawer spot;
    public SpotDrawer pinSpot;
    public Drawable[] drawables;

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        sprayPart.active = false;
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        spot.color = Color.HSVToRGB(Mathf.Repeat(Time.time * 0.05f, 1f), 1f, 1f);

        spot.UpdateDrawingMat();
        foreach (var drawable in drawables)
            spot.Draw(drawable);

        if (pressed)
        {
            triggerObj.transform.Rotate(0f, 0f, -8.5f);
            sprayPart.active = true;
            var cam = Camera.main;
            var pos = Input.mousePosition;
            pos.z = 5f;
            pos = cam.ScreenToWorldPoint(pos);
            pinSpot.transform.position = cam.transform.position;
            pinSpot.transform.LookAt(pos);

            pinSpot.color = Color.HSVToRGB(Mathf.Repeat(Time.time * 0.5f, 1f), 1f, 1f);
            pinSpot.UpdateDrawingMat();
            foreach (var drawable in drawables)
                pinSpot.Draw(drawable);
        }

        else
        {
            triggerObj.transform.Rotate(0f, 0f, 8.5f);
            sprayPart.active = false;
        }
    }
}