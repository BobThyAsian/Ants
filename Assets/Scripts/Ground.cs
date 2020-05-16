using Extras.Utils;
using System.Collections.Generic;
using UnityEngine;


public class Ground : MonoBehaviour
{
    //[SerializeField] private HeatMapVisual heatMap;
    //[SerializeField] private HeatMapVisualBool heatBool;
    //private Grid<HeatMapGridObject> ground;
    private Pathfinding pathfinding;

    // Start is called before the first frame update
    void Start()
    {
        //ground = new Grid<HeatMapGridObject>(50, 50, 10f, new Vector3(-250f, -250f), (Grid<HeatMapGridObject> g, int x, int y ) => new HeatMapGridObject());
        pathfinding = new Pathfinding(100, 100);
        
        //heatMap.SetGrid(ground);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 position = UtilsClass.GetMouseWorldPosition();
        //    Vector3 offset = new Vector3(-250,-250);
        //    pathfinding.GetGrid().GetXY(position, out int x, out int y);
        //    List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
        //    if(path != null)
        //    {
        //        for (int i = 0; i < path.Count - 1; i++)
        //        {
        //            Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f + offset, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f + offset, Color.red, 10f);
        //            Debug.Log(path[i].x.ToString() + "," + path[i].y.ToString());
        //        }
        //    }
            
        //    //HeatMapGridObject heatMapGridObject = ground.GetGridObject(position);
        //    //if (heatMapGridObject != null)
        //    //{
        //    //    heatMapGridObject.AddValue(5);
        //    //    ground.SetGridObject(position, heatMapGridObject);
        //    //    EventManager.TriggerEvent("test");

        //    //}
        //    //ground.SetValue(position, true);
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Vector3 position = UtilsClass.GetMouseWorldPosition();
        //    pathfinding.GetGrid().GetXY(position, out int x, out int y);
        //    pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        //}
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
