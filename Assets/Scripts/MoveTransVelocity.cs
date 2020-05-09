using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransVelocity : MonoBehaviour, IMoveVelocity
{

    [SerializeField] private float moveSpeed;

    private Vector3 velocityVector;
    //private Character_Base characterBase;

    private void Awake()
    {
        //characterBase = GetComponent<Character_Base>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    private void Update()
    {
        transform.position += velocityVector * moveSpeed * Time.deltaTime;

        //characterBase.PlayMoveAnim(velocityVector);
    }
}

