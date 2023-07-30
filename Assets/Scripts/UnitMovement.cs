using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public bool isSelected;
    public GameObject skid;
    private bool isSkidPickedUp = false;
    private bool isSkidAttached;
    private bool isCraftingAreaInRange;
    private Vector3 craftPos;

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
        localVelocity.z = speed * Input.GetAxis("Vertical");
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    public virtual void Rotate(Rigidbody rb,float rotationSpeed, float velocity)
    {
        if(velocity != 0)
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            rb.AddTorque(Vector3.up * rotationSpeed * localVelocity.z * Input.GetAxis("Horizontal"));
            localVelocity.x = 0f;
            rb.velocity = transform.TransformDirection(localVelocity);
        }
    }

    public virtual void Rotate(Rigidbody rb, float rotationSpeed)
    {
        // doesn't work as intended for a worker


        //rb.AddTorque(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal"));

        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        rb.transform.Rotate(Vector3.up, rotationSpeed * Input.GetAxis("Horizontal"));
        localVelocity.x = 0f;
        rb.velocity = transform.TransformDirection(localVelocity);

    }

    public virtual bool PickUpSkid()
    {
       isSkidPickedUp = true;
       // forkCollider.enabled = false;
        return isSkidPickedUp;
    }

    public virtual bool DropSkid()
    {
        isSkidPickedUp = false;
        isSkidAttached = false;
        skid = null;
        // forkCollider.enabled = false;
        return isSkidPickedUp;
    }

    public virtual void MoveSkid(Vector3 skidPos , GameObject forkLift)
    {
        if (skid != null && isSkidPickedUp)
        {
            skid.GetComponent<Rigidbody>().isKinematic = true;
            skid.GetComponent<Rigidbody>().mass = 0;
            skid.transform.position = skidPos;
            skid.transform.SetParent(forkLift.transform);
            isSkidAttached = true;
        }
        if(skid != null && !isSkidPickedUp && isSkidAttached)
        {
            //skid.GetComponent<Rigidbody>().isKinematic = false;
            skid.GetComponent<Rigidbody>().mass = 1;
            skid.transform.position = skidPos - new Vector3(0, 0.04f, -2);
            skid.transform.SetParent(null);
            isSkidAttached = false;
        }
    }

    public virtual void CraftSkid(GameObject prefab)
    {
        if (isCraftingAreaInRange)
        {
            Debug.Log("Coroutine called");
            StartCoroutine(InstantiateSkid(prefab));
        }
    }
    private IEnumerator InstantiateSkid(GameObject prefab)
    {
        yield return new WaitForSeconds(3);
        Instantiate(prefab, craftPos, prefab.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skids"))
        {
            skid = other.gameObject;
        }
        if (other.CompareTag("CraftingArea"))
        {
            Debug.Log("Area in range");
            isCraftingAreaInRange = true;
            craftPos = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Skids"))
        {
            skid = null;
        }
        if (other.CompareTag("CraftingArea"))
        {
            isCraftingAreaInRange = false;
            //craftPos = Vector3.zero;
        }
    }

}
