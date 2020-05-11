using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidbody2d;
    private Quaternion currentRotation;
    private Vector3 originalPosition;
    private Vector3 velocityVector;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    private void FixedUpdate()
    {
        HandleRotation();
        rigidbody2d.velocity = velocityVector * moveSpeed;
        //transform.rotation = Quaternion.LookRotation(velocityVector);

    }

    private void HandleRotation()
    {
        Vector2 vectorToTarget = rigidbody2d.velocity;
        // - transform.position;
        if (vectorToTarget != Vector2.zero)
        {
            transform.LookAt(transform.position + new Vector3(0, 0, 1), vectorToTarget);

        }
        //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
