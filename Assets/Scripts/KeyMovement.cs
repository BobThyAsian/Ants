using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetAxis("Horizontal") != 0) moveX = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical") != 0) moveY = Input.GetAxis("Vertical");

        //Set Vector
        Vector3 moveVector = new Vector3(moveX, moveY).normalized;
        GetComponent<IMoveVelocity>().SetVelocity(moveVector);
    }
}
