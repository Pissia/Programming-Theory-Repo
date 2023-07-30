using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerUnit : UnitMovement
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;
    [SerializeField] GameObject skidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            Move(speed, rb);
            Rotate(rb, rotationSpeed);
            if (Input.GetKeyDown(KeyCode.F))
            {
                CraftSkid(skidPrefab);
                Debug.Log("Button Pressed");
            }
        }
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", rb.velocity.magnitude);
        }
    }
}
