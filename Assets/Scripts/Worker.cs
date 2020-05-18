using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    private GameObject selectedGameObject;
    private AntAnimation antAnimation;

    private void Awake()
    {
        selectedGameObject = transform.Find("Selected").gameObject;
        antAnimation = GetComponent<AntAnimation>();
        SetSelectedVisible(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);

    }
}
