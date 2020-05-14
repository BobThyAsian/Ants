using Extras.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Grid<bool> ground;
    // Start is called before the first frame update
    void Start()
    {
        ground = new Grid<bool>(50, 50, 10f, new Vector3(-250f, -250f));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) ground.AddValue(UtilsClass.GetMouseWorldPosition(), 10, 2, 15);
    }
}
