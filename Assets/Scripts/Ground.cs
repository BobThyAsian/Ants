using Extras.Utils;
using System.Collections.Generic;
using UnityEngine;


public class Ground : MonoBehaviour
{
    //[SerializeField] private HeatMapVisual heatMap;
    [SerializeField] private PathVisual pathVisual;
    //private Grid<HeatMapGridObject> ground;
    public float buffer = 0f;
    private List<Collider2D> colliders;
    private Pathfinding pathfinding;



    private void Awake()
    {
        pathfinding = new Pathfinding(100, 100);

    }
    // Start is called before the first frame update
    void Start()
    {
        colliders = GetAllCollidersOnlyInScene();
        pathVisual.SetGrid(pathfinding.GetGrid());
        foreach (Collider2D collider in colliders)
        {

            if (collider.gameObject.tag != "Environment") return;
            
            AddCollidersToPathfinding(collider);
            
        }
        //ground = new Grid<HeatMapGridObject>(50, 50, 10f, new Vector3(-250f, -250f), (Grid<HeatMapGridObject> g, int x, int y ) => new HeatMapGridObject());
        //heatMap.SetGrid(ground);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            Vector3 offset = new Vector3(0, 0);
            pathfinding.GetGrid().GetXY(position, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    //Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 5f + Vector3.one * 5f + offset, new Vector3(path[i + 1].x, path[i + 1].y) * 5f + Vector3.one * 2.5f + offset, Color.red, 10f);
                    //Debug.Log(path[i].x.ToString() + "," + path[i].y.ToString());
                }
            }

            //HeatMapGridObject heatMapGridObject = ground.GetGridObject(position);
            //if (heatMapGridObject != null)
            //{
            //    heatMapGridObject.AddValue(5);
            //    ground.SetGridObject(position, heatMapGridObject);
            //    EventManager.TriggerEvent("test");

            //}
            //ground.SetValue(position, true);
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Vector3 position = UtilsClass.GetMouseWorldPosition();
        //    pathfinding.GetGrid().GetXY(position, out int x, out int y);
        //    pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        //}
    }

    private void AddCollidersToPathfinding(Collider2D collider)
    {
        Vector3 botLef = collider.bounds.min;
        Vector3 topRig = collider.bounds.max;
        float gridSize = 5f;
        Vector3 offset = new Vector3(-1,-1);
        float length = collider.bounds.size.x;
        float height = collider.bounds.size.y;
        //Debug.Log(botLef.ToString() + "," + topRig.ToString() + "," + length.ToString() + "," + height.ToString());

        for (int x = 0; x  < length / gridSize; x++)
        {
            for (int y = 0; y <= height / gridSize; y++)
            {
                
                Vector3 position = botLef + new Vector3(x, y) * gridSize;
                pathfinding.GetGrid().GetXY(position, out int xP, out int yP);
                pathfinding.GetNode(xP, yP).SetIsWalkable(!pathfinding.GetNode(xP, yP).isWalkable);
                Debug.Log(position.ToString());
            }
        }
        //add collider's position to not walkable

    }

    private List<Collider2D> GetAllCollidersOnlyInScene()
    {
        List<Collider2D> objectsInScene = new List<Collider2D>();

        foreach (Collider2D go in Resources.FindObjectsOfTypeAll(typeof(Collider2D)) as Collider2D[])
        {
            objectsInScene.Add(go);
            //Debug.Log(go.ToString());
        }

        return objectsInScene;
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
