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
            Draw(rightHandLocation.position);
        }
        else if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            Draw(leftHandLocation.position);
        }
        else
        {
            wasDrawing = false;
        }
    }

    void Draw(Vector3 position)
    {
        //Create a connector between the new point and the old point if the user is actively drawing
        if (wasDrawing)
        {
            //Create connector and set it to "Drawn" layer
            GameObject connector = Instantiate(drawingPointConnector, (position - lastDrawnPoint) / 2.0f + lastDrawnPoint, Quaternion.FromToRotation(Vector3.up, position - lastDrawnPoint));
            //connector.layer = LayerMask.NameToLayer("Drawn");
            var v3T = connector.transform.localScale;
            v3T.y = (position - lastDrawnPoint).magnitude;
            connector.transform.localScale = v3T;
        }
        wasDrawing = true;

        //Create a new drawing point and set the layer to "Drawn"
        Instantiate(drawingPoint, position, Quaternion.identity);
        //Instantiate(drawingPoint, rightHandLocation.position, Quaternion.identity).layer = LayerMask.NameToLayer("Drawn");
        lastDrawnPoint = position;
    }
}
