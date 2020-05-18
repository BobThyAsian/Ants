using System.Collections;
using System.Collections.Generic;
using Extras;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    private List<Vector3> vectorPath;
    private AntAnimation antAnimation;
    private int currentPIndex;
    public Vector3 target;
    private Vector3 moveDir;
    private float distance;


    private void Awake()
    {
        antAnimation = GetComponent<AntAnimation>();
    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        Movement();
        //Debug.Log(target.ToString());

    }

    private void Movement()
    {
        if (vectorPath != null)
        {
            target = vectorPath[currentPIndex];
            distance = Vector3.Distance(transform.position, target);
            if ( distance > 1f)
            {
                moveDir = (target - transform.position).normalized;
                Debug.Log(moveDir.ToString());
                transform.LookAt(transform.position + new Vector3(0, 0, 1), moveDir);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
                antAnimation.SetAnimation(1);
            } else
            {
                currentPIndex++;
                if (currentPIndex >= vectorPath.Count) { StopMoving(); }
                antAnimation.SetAnimation(3);
            }
        }

    }

    private void StopMoving()
    {
        vectorPath = null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetMovePosition(Vector3 movePosition)
    {
        currentPIndex = 0;
        vectorPath = Pathfinding.Instance.FindPath(GetPosition(), movePosition);
        if (vectorPath != null && vectorPath.Count > 1)
        {
            vectorPath.RemoveAt(0);
        }
    }

    public void RandomPosition()
    {
        Vector3 tempPos = Random.insideUnitCircle * 20;
        SetMovePosition(tempPos);
    }

}
