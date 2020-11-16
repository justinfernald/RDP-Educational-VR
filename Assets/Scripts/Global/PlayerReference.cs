using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    [SerializeField]
    private OVRCameraRig cameraRigTarget;
    public static OVRCameraRig cameraRig;
    // Start is called before the first frame update
    void Start()
    {
        cameraRig = cameraRigTarget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
