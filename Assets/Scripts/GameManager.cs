using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extras.MonoBehaviours;
using Extras;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float zoomMin;
    [SerializeField] private float zoomMax;
    public GameObject workerPrefab;
    public GameObject enemyPrefab;
    private GameController gameController;
    private Vector3 cameraPosition;
    private float zoomSpeed;
    public float orthoSize = 66.7f;
    private float cameraSpeed;
    private float edgeSize = 30f;


    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");


        cameraFollow.Setup(() => cameraPosition, () => orthoSize, true, true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.workers.Count > 0)
        {
            cameraPosition = gameController.workers[0].gameObject.transform.position;
        }
        if (playerTransform)
        {
            FollowCameraZoom();

        }
        else
        {
            ManualCameraMovement();

        }
    }

    private void FollowCameraZoom()
    {
        float scrollAxis = Input.GetAxis("Mouse ScrollWheel");
        zoomSpeed = 1f;

        //Turbo
        if (Input.GetKey(KeyCode.LeftShift)) zoomSpeed = zoomSpeed * 2;

        //Scroll Positive/In
        if (scrollAxis < 0 || Input.GetKey(KeyCode.E)) orthoSize += zoomSpeed;
        //Scroll Negative/Out
        if (scrollAxis > 0 || Input.GetKey(KeyCode.Q)) orthoSize -= zoomSpeed;

        //Camera Constraints 
        if (orthoSize <= zoomMin) orthoSize = zoomMin;
        if (orthoSize >= zoomMax) orthoSize = zoomMax;
        cameraPosition = playerTransform.position;

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

        //Right|| Input.mousePosition.x > Screen.width - edgeSize
        if (horizontalAxis > 0 ) cameraPosition.x += cameraSpeed * Time.deltaTime;
        //Left|| Input.mousePosition.x <  edgeSize
        if (horizontalAxis < 0) cameraPosition.x -= cameraSpeed * Time.deltaTime;
        //Up || Input.mousePosition.y > Screen.height - edgeSize
        if (verticalAxis > 0) cameraPosition.y += cameraSpeed * Time.deltaTime;
        //Down || Input.mousePosition.y < edgeSize
        if (verticalAxis < 0) cameraPosition.y -= cameraSpeed * Time.deltaTime;
        
        
        
        //Scroll Positive/In
        if (scrollAxis < 0) orthoSize += zoomSpeed;
        //Scroll Negative/Out
        if(scrollAxis > 0) orthoSize -= zoomSpeed;

        //Camera Constraints 
        if (orthoSize <= zoomMin) orthoSize = zoomMin;
        if (orthoSize >= zoomMax) orthoSize = zoomMax;

    }
    public void CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(20f, 0f, 0f), Quaternion.identity) as GameObject;
        enemy.GetComponent<MovePositionPathfinding>().movePosition = new Vector3(20f, 0f, 0f);
    }

    public void CreateWorker()
    {
        GameObject worker = Instantiate(workerPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity) as GameObject;
        worker.GetComponent<MovePositionPathfinding>().movePosition = new Vector3(10f, 0f, 0f);
    }
}
