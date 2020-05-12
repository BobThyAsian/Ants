using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Extras;
using UnityEngine;

public class MoveVelocity : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    private Rigidbody2D rigidbody2d;
    private Vector3 movePosition;
    private float dist;
    private Vector3 moveDir;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }

    private void FixedUpdate()
    {
        dist = Vector3.Distance(movePosition, transform.position);
        moveDir = (movePosition - transform.position).normalized;
        HandleRotation();
        HandleMovement();
        //EDebug.TextUpdater(() => movePosition.ToString() + " - " + transform.position.ToString() + " = " + moveDir.ToString() + " " + dist.ToString(), new Vector3(10f, 40f, 1f));
    }

    private void HandleRotation()
    {
        Vector3 vectorToTarget = moveDir;
        if (dist > .3f)
        {
            transform.LookAt(transform.position + new Vector3(0, 0, 1), vectorToTarget);

        }

    }
    private void HandleMovement()
    {
        if (dist > .3f)
        {
            rigidbody2d.velocity = moveDir * speed;
        }
        if (dist < .3f)
        {
            rigidbody2d.MovePosition(movePosition);
            rigidbody2d.velocity = Vector3.zero;

        }


    }
}
