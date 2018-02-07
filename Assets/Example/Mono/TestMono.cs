using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class TestMono : MonoBehaviour
{
    [SerializeField] private GameObject button;

    private void Start()
    {
        
        var trigger = button.AddComponent<ObservableLongPointerDownTrigger>();

        trigger.OnLongPointerDownAsObservable().Subscribe(_ => Debug.Log("Click"));
    }
}
