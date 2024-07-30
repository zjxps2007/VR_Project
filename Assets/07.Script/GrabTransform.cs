using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTransform : MonoBehaviour
{
    [SerializeField] private OVRGrabbable _grabbable;
    
    // Start is called before the first frame update
    void Start()
    {
        _grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_grabbable.grabbedBy.GetController() == OVRInput.Controller.LTouch)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -90);
            Debug.Log("왼손");
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 180, -90);
            Debug.Log("오른손");
        }
    }
}
