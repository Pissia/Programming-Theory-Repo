using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public bool isSelected;

    public virtual bool SelectedUnit()
    {
        isSelected = true;
        return isSelected;
    }

    public virtual bool DeselectUnit()
    {
        isSelected = false;
        return isSelected;
    }
    public virtual void Move(float speed, Rigidbody rb)
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = -speed * Input.GetAxis("Vertical");
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    public virtual void Rotate(Rigidbody rb,float rotationSpeed, float velocity)
    {
        if(velocity != 0)
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            rb.AddTorque(Vector3.up * rotationSpeed * -localVelocity.x * Input.GetAxis("Horizontal"));
            localVelocity.z = 0f;
            rb.velocity = transform.TransformDirection(localVelocity);
        }
    }

    public virtual void Rotate(Rigidbody rb, float rotationSpeed)
    {
        // doesn't work as intended for a worker


        //rb.AddTorque(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal"));

        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        rb.transform.Rotate(Vector3.up, rotationSpeed * Input.GetAxis("Horizontal"));
        localVelocity.z = 0f;
        rb.velocity = transform.TransformDirection(localVelocity);

    }
}
