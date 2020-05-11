using Extras;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour
{
    public Vector3 movePosition;
    private Vector3 moveDir;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        moveDir = (movePosition - transform.position);
        float dist = Vector3.Distance(movePosition, transform.position);
        GetComponent<MoveVelocity>().SetVelocity(moveDir.normalized);
        //Debugging
        EDebug.TextUpdater( () => movePosition.ToString() + " - " + transform.position.ToString() + " = " + moveDir.ToString() , new Vector3(10f,40f, 1f));
    }
    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }
    public void RandomPosition()
    {
        Vector3 tempPos = Random.insideUnitCircle*20;
        SetMovePosition(tempPos.normalized);
    }


}
