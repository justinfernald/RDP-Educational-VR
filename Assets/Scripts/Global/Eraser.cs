using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private bool erase;

    void Update()
    {
        if(OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            erase = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy any colliding object in the layer "Drawn" while the user
        //is holding down the trigger and is using the eraser
        if (collision.gameObject.layer == LayerMask.NameToLayer("Drawn") && erase)
        {
            Destroy(collision.gameObject);
        }
    }
}
