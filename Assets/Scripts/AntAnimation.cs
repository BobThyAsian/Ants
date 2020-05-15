using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAnimation : MonoBehaviour
{
    [SerializeField] private SpriteAnimator spriteAnimator;
    [SerializeField] private float frameRate;
    [SerializeField] private Sprite[] MoveAnimationFrameArray;
    [SerializeField] private Sprite[] IdleAnimationFrameArray;
    public bool moving;
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
        spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //If moving, animate
        if (!moving)
        {
            PlayAnimation(AnimationType.Idle);
        }else
        {
            PlayAnimation(AnimationType.Move);

        }
    }

    public void SetMoving(bool moving) { this.moving = moving; }
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
