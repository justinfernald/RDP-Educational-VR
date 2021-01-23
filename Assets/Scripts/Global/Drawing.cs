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
            //Create a connector between the new point and the old point if the user is actively drawing
            if (wasDrawing)
            {
                //Create connector and set it to "Drawn" layer
                GameObject connector = Instantiate(drawingPointConnector, (rightHandLocation.position - lastDrawnPoint) / 2.0f + lastDrawnPoint, Quaternion.FromToRotation(Vector3.up, rightHandLocation.position - lastDrawnPoint));
                //connector.layer = LayerMask.NameToLayer("Drawn");
                var v3T = connector.transform.localScale;
                v3T.y = (rightHandLocation.position - lastDrawnPoint).magnitude;
                connector.transform.localScale = v3T;
            }
            wasDrawing = true;

            //Create a new drawing point and set the layer to "Drawn"
            Instantiate(drawingPoint, rightHandLocation.position, Quaternion.identity);
            //Instantiate(drawingPoint, rightHandLocation.position, Quaternion.identity).layer = LayerMask.NameToLayer("Drawn");
            lastDrawnPoint = rightHandLocation.position;
        } else
        {
            wasDrawing = false;
        }
    }
}
