using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public class OnSecondEventArgs : EventArgs
    {
        public int second;
    }

    public static event EventHandler<OnSecondEventArgs> onSecond;
    private const float LENGTH_OF_SECOND = 1f;

    private int second;
    private float timer;


    private void Awake()
    {
        second = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= LENGTH_OF_SECOND)
        {
            timer -= LENGTH_OF_SECOND;
            second++;
            if(onSecond != null) onSecond(this, new OnSecondEventArgs { second = second });
            //Debug.Log(second);
            
        }
    }
}
