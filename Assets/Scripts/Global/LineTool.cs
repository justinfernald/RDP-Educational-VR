using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTool : MonoBehaviour
{
    public Transform leftHandLocation;
    public Transform rightHandLocation;

    private List<Vector3> points;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            AddPoint(rightHandLocation.position);
        }

        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            AddPoint(leftHandLocation.position);
        }
    }

    void AddPoint(Vector3 point) {

        points.Add(point);

        //If there are 2 points create a new line renderer and set start and end points
        if (points.Count == 2)
        {
            GameObject newLine = new GameObject("Line");
            LineRenderer lineRenderer = newLine.AddComponent<LineRenderer>();
            lineRenderer.SetPositions(points.ToArray());
            lineRenderer.endWidth = .05f;
            lineRenderer.startWidth = .05f;
            points.Clear();
        }
    }
}
