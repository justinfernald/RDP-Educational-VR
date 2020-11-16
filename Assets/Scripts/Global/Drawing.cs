using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Transform leftHandLocation;
    public Transform rightHandLocation;

    public GameObject drawingPoint;
    public GameObject drawingPointConnector;

    bool wasDrawing = false;
    Vector3 lastDrawnPoint;

    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            if (wasDrawing)
            {

                GameObject connector = Instantiate(drawingPointConnector, (rightHandLocation.position - lastDrawnPoint) / 2.0f + lastDrawnPoint, Quaternion.FromToRotation(Vector3.up, rightHandLocation.position - lastDrawnPoint));

                var v3T = connector.transform.localScale;
                v3T.y = (rightHandLocation.position - lastDrawnPoint).magnitude;
                connector.transform.localScale = v3T;
            }
            wasDrawing = true;

            Instantiate(drawingPoint, rightHandLocation.position, Quaternion.identity);

            lastDrawnPoint = rightHandLocation.position;
        } else
        {
            wasDrawing = false;
        }
    }
}
