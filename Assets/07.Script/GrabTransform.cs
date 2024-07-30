using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTransform : MonoBehaviour
{
    [SerializeField] private OVRGrabbable grabbable;
    public Transform[] OffsetList = new Transform[2];
    //0 = Left, 1 = Right
    public bool isPistol;

    void Start()
    {
        grabbable = this.GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        if (grabbable.isGrabbed && grabbable.grabbedBy.GetController() == OVRInput.Controller.LTouch)
        {
            Debug.Log(grabbable.grabbedBy);
            this.grabbable.swapOffset(OffsetList[0]);
            Debug.Log("왼손");
        }
        else if (grabbable.isGrabbed)
        {
            Debug.Log(grabbable.grabbedBy);
            this.grabbable.swapOffset(OffsetList[1]);
            Debug.Log("오른손");
        }
    }
}