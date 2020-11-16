using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine) return;
        head.gameObject.SetActive(false);
        leftHand.gameObject.SetActive(false);
        rightHand.gameObject.SetActive(false);
        MapPosition(head, VRNode.Head);
        MapPosition(leftHand, VRNode.LeftHand);
        MapPosition(rightHand, VRNode.RightHand);
    }

    void MapPosition(Transform target, VRNode node)
    {
        OVRCameraRig cr = PlayerReference.cameraRig;
        switch (node)
        {
            case VRNode.Head:
                //OVRPose tracker = OVRManager.tracker.GetPose();
                //target.position = tracker.position;
                //target.rotation = tracker.orientation;
                target.position = cr.trackerAnchor.position;
                target.rotation = cr.trackerAnchor.rotation;
                break;
            case VRNode.LeftHand:
                //target.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
                //target.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
                target.position = cr.leftHandAnchor.position;
                target.rotation = cr.leftHandAnchor.rotation;
                break;
            case VRNode.RightHand:
                //target.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                //target.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
                target.position = cr.rightHandAnchor.position;
                target.rotation = cr.rightHandAnchor.rotation;
                break;
        }
    }

    enum VRNode
    {
        Head,
        LeftHand,
        RightHand
    }
}
