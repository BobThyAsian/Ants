﻿using Extras.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<MovePositionPathfinding>().SetMovePosition(UtilsClass.GetMouseWorldPosition());
        }
    }



}
