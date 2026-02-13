using UnityEngine;
using Meta.XR;
using System;

public class DebugAnchorUUID : MonoBehaviour
{
    public OVRSpatialAnchor anchor;

    void Start()
    {
        if (anchor != null)
        {
            Debug.Log("Anchor UUID: " + anchor.Uuid);
        }
    }
}
