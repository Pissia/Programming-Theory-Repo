using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrokliftUnit : UnitMovement
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeedMultipleyer;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject skidPositionObj;
    [SerializeField] CapsuleCollider forkCollider;
    [SerializeField] GameObject centerOfMass;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // rb.centerOfMass = centerOfMass.transform.position;
        forkCollider = GetComponentInChildren<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isSelected)
        {
            //Inheritaed methods from Unit Movement class
            Move(speed, rb);
            Rotate(rb, rotationSpeedMultipleyer, rb.velocity.z);
            MoveSkid(skidPositionObj.transform.position, rb.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpSkid();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropSkid();
        }
    }
}
