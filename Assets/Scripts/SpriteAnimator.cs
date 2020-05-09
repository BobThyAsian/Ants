using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public event EventHandler OnLoopFirst;
    public event EventHandler OnLoop;

    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float frameRate = .1f;
    private SpriteRenderer spriteRenderer;
    private bool loop = true;
    private bool isPlaying = true;
    private int LoopCount = 0;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (!isPlaying)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            if( !loop && currentFrame == 0)
            { 
                StopPlaying(); 
            } 
            else
            { 
                spriteRenderer.sprite = frameArray[currentFrame]; 
            }

            if(currentFrame == 0)
            {
                LoopCount++;
                if(LoopCount == 1)
                {
                    if (OnLoopFirst != null) OnLoopFirst(this, EventArgs.Empty);
                }
                if (OnLoop != null) OnLoop(this, EventArgs.Empty);
            }

        }
    }

    private void StopPlaying()
    {
        isPlaying = false;
    }

    public void playAnimation(Sprite[] frameArray, float framerate)
    {
        this.frameRate = framerate;
        this.frameArray = frameArray;
        currentFrame = 0;
        timer = 0f;
        spriteRenderer.sprite = frameArray[currentFrame];
    }
}
