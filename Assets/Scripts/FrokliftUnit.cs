using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrokliftUnit : UnitMovement
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeedMultipleyer;
    [SerializeField] Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        Move(speed, rb);       
        Rotate(rb, rotationSpeedMultipleyer, -rb.velocity.x);
    }

    private void FixedUpdate()
    {
       
    }
}
