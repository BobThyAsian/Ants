using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListenerComponent : MonoBehaviour
{
    private UnityAction listenerComponent1;

    private void Awake()
    {
        listenerComponent1 = new UnityAction(SomeFunction);
    }
    private void OnEnable()
    {
        EventManager.StartListening("test", listenerComponent1);
    }

    private void OnDisable()
    {
        EventManager.StopListning("test", listenerComponent1);
    }

    void SomeFunction()
    {
        Debug.Log("Function called.");
    }
}
