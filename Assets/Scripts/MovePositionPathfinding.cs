using Extras;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour
{
    public Vector3 movePosition;

    private void Awake()
    {

    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        GetComponent<MoveVelocity>().SetVelocity(movePosition);
        //Debugging
        
    }
    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }
    public void RandomPosition()
    {
        Vector3 tempPos = Random.insideUnitCircle*20;
        SetMovePosition(tempPos);
    }



}
