﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extras.Utils;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTrans;
    private Vector3 startPosition;
    private Vector3 endPostion;
    private Collider2D[] collider2DArray;
    public List<Worker> workers;
    private Text uiText1;


    private void Awake()
    {
        workers = new List<Worker>();
        selectionAreaTrans.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        uiText1 = GameObject.Find("UIText1").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Left mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = UtilsClass.GetMouseWorldPosition();
            selectionAreaTrans.gameObject.SetActive(true);
        }
        //Left mouse button hold
        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
                );
            Vector3 upperRight = new Vector3(
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
                );

            selectionAreaTrans.position = lowerLeft;
            selectionAreaTrans.localScale = upperRight - lowerLeft;

        }
        //Left mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            endPostion = UtilsClass.GetMouseWorldPosition();
            selectionAreaTrans.gameObject.SetActive(false);
            collider2DArray = Physics2D.OverlapAreaAll(startPosition, endPostion);

            //      ************   Clear List ***********
            foreach (Worker worker in workers)
            {
                worker.SetSelectedVisible(false);
            }
            workers.Clear();

            //        ************   Add To List   *************
            foreach (Collider2D collider2D in collider2DArray)
            {
                Worker worker = collider2D.GetComponent<Worker>();
                if (worker != null)
                {
                    worker.SetSelectedVisible(true);
                    workers.Add(worker);
                }
            }
        }
        uiText1.text = "Start: " + startPosition.ToString();
        uiText1.text += " | End: " + endPostion.ToString();

    }

}
