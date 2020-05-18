using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAnimation : MonoBehaviour
{
    [SerializeField] private SpriteAnimator spriteAnimator;
    [SerializeField] private float frameRate;
    [SerializeField] private Sprite[] MoveAnimationFrameArray;
    [SerializeField] private Sprite[] BiteAnimationFrameArray;
    [SerializeField] private Sprite[] IdleAnimationFrameArray;
    public int animationRunning;
    private bool actionChange;
    private enum AnimationType
    {
        Move,
        Bite,
        Idle
    }
    private AnimationType activeAnimationType;
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        actionChange = false;
        spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    public void SetAnimation(int animationRunning) { this.animationRunning = animationRunning; this.actionChange = true; }

    private void Animate()
    {
        if (!actionChange) return;
        switch (animationRunning)
        {
            case 1:
                PlayAnimation(AnimationType.Move);
                break;
            case 2:
                PlayAnimation(AnimationType.Bite);
                break;
            case 3:
                PlayAnimation(AnimationType.Idle);
                break;
            default:
                PlayAnimation(AnimationType.Idle);
                break;
        }
        actionChange = false;

    }
    private void PlayAnimation(AnimationType animationType)
    {
        if (animationType != activeAnimationType)
        {
            activeAnimationType = animationType;
            switch (animationType)
            {
                case AnimationType.Move:
                    spriteAnimator.playAnimation(MoveAnimationFrameArray, .08f);
                    break;
                case AnimationType.Idle:
                    spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
                    break;
            }
        }
    }
}
