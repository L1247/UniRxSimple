using UnityEngine;
using System.Collections;
using System;
using UniRx;

/// <summary>
/// Hot Observale 單一Steam
/// </summary>
public class HotObservale_TimerSample : MonoBehaviour
{
    // Use this for initialization
    void Start ( )
    {
        var intervalStream = Observable.Interval(TimeSpan.FromSeconds(1)).Publish().RefCount();
        intervalStream
            .Subscribe( x => Debug.Log( "[1]: " + Time.time.ToString( "F2" ) ) );

        intervalStream
            .Subscribe( x => Debug.Log( "[2]: " + Time.time.ToString( "F2" ) ) );

        intervalStream
            .Subscribe( x => Debug.Log( "[3]: " + Time.time.ToString( "F2" ) ) );
    }
}
