using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAnimation : MonoBehaviour
{
    [SerializeField] private SpriteAnimator spriteAnimator;
    [SerializeField] private float frameRate;
    [SerializeField] private Sprite[] MoveAnimationFrameArray;
    [SerializeField] private Sprite[] IdleAnimationFrameArray;
    private enum AnimationType
    {
        Move,
        Idle
    }
    private AnimationType activeAnimationType;
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //If moving, animate
        if (rBody.velocity.magnitude == 0)
        {
            PlayAnimation(AnimationType.Idle);
        }else
        {
            PlayAnimation(AnimationType.Move);

        }
    }
    private void PlayAnimation(AnimationType animationType)
    {
        if (animationType != activeAnimationType)
        {
            activeAnimationType = animationType;
            switch (animationType)
            {
                case AnimationType.Move:
                    spriteAnimator.playAnimation(MoveAnimationFrameArray, .1f);
                    break;
                case AnimationType.Idle:
                    spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
                    break;
            }
        }
    }
}
