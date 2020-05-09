using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour
{
    public Vector3 movePosition;


    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }
    public void RandomPosition()
    {

        Vector3 tempPos = Random.insideUnitCircle * Random.Range(10f,20f);
        SetMovePosition(tempPos);
        Debug.Log(tempPos.ToString());
    }
    private void Start()
    {
        InvokeRepeating("RandomPosition", 0.1f, 10f);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDir = (Vector3.Distance(transform.position, movePosition) < .1f) ? Vector3.zero : (movePosition - transform.position).normalized;
        GetComponent<IMoveVelocity>().SetVelocity(moveDir);
    }

}
