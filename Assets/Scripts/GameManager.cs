using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.MonoBehaviours;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private float zoomMin;
    [SerializeField] private float zoomMax;
    [SerializeField] private bool edgeScroll;
    private Vector3 cameraPosition;
    private float zoomSpeed;
    private float orthoSize = 400f;
    private float cameraSpeed;
    private float edgeSize = 30f;


    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.Setup(() => cameraPosition, () => orthoSize, true, true);
    }

    // Update is called once per frame
    void Update()
    {
        ManualCameraMovement();
    }

    private void ManualCameraMovement()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float scrollAxis = Input.GetAxis("Mouse ScrollWheel");
        cameraSpeed = 100f;
        zoomSpeed = 10f;

        //Turbo
        if (Input.GetKey(KeyCode.LeftShift))
        {
            zoomSpeed = zoomSpeed * 5;
            cameraSpeed = cameraSpeed * 5;
        }

        //Right
        if (horizontalAxis > 0 || Input.mousePosition.x > Screen.width - edgeSize) cameraPosition.x += cameraSpeed * Time.deltaTime;
        //Left
        if (horizontalAxis < 0|| Input.mousePosition.x <  edgeSize) cameraPosition.x -= cameraSpeed * Time.deltaTime;
        //Up
        if (verticalAxis > 0 || Input.mousePosition.y > Screen.height - edgeSize) cameraPosition.y += cameraSpeed * Time.deltaTime;
        //Down
        if (verticalAxis < 0 || Input.mousePosition.y < edgeSize) cameraPosition.y -= cameraSpeed * Time.deltaTime;
        
        
        
        //Scroll Positive/In
        if (scrollAxis > 0) orthoSize += zoomSpeed;
        //Scroll Negative/Out
        if(scrollAxis < 0) orthoSize -= zoomSpeed;

        //Camera Constraints 
        if (orthoSize <= zoomMin) orthoSize = zoomMin;
        if (orthoSize >= zoomMax) orthoSize = zoomMax;

    }
}
