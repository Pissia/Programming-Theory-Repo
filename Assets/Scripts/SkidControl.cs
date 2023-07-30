using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidControl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadingArea"))
        {
            GetComponentInParent<UnitMovement>().DropSkid();
            UIcontrol.instance._score++;
            gameObject.SetActive(false);
        }
    }
}
