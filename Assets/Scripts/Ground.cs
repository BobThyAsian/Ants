using Extras.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static Grid<HeatMapGridObject>;

public class Ground : MonoBehaviour
{
    [SerializeField] private HeatMapVisual heatMap;
    //[SerializeField] private HeatMapVisualBool heatBool;
    private Grid<HeatMapGridObject> ground;

    // Start is called before the first frame update
    void Start()
    {
        ground = new Grid<HeatMapGridObject>(50, 50, 10f, new Vector3(-250f, -250f), () => new HeatMapGridObject());
        
        
        heatMap.SetGrid(ground);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            HeatMapGridObject heatMapGridObject = ground.GetGridObject(position);
            if (heatMapGridObject != null)
            {
                heatMapGridObject.AddValue(5);
                ground.SetGridObject(position, heatMapGridObject);
                EventManager.TriggerEvent("test");

            }
            //ground.SetValue(position, true);
        }
    }
}

public class HeatMapGridObject
{
    private const int MIN = 0;
    private const int MAX = 100;
    public int value;

    public void AddValue(int addvalue)
    {
        value += addvalue;
        value = Mathf.Clamp(value, MIN, MAX);
    }

    public int IntValue()
    {
        return (int)value;
    }

    public float GetNormalized()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
