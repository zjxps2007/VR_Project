using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public OVRInput.Button shootButton;
    private OVRGrabbable _grabbable;
    private AudioSource _audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        _grabbable = GetComponent<OVRGrabbable>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
