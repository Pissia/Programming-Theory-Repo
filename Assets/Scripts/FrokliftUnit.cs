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



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forkCollider = GetComponentInChildren<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            Move(speed, rb);
            Rotate(rb, rotationSpeedMultipleyer, -rb.velocity.x);
            MoveSkid(skidPositionObj.transform.position, rb.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpSkid(forkCollider);
        }
    }

    private void FixedUpdate()
    {
       
    }
}
