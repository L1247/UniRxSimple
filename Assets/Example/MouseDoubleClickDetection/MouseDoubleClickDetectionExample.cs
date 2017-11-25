using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MouseDoubleClickDetectionExample : MonoBehaviour
{

    // Use this for initialization
    void Start ( )
    {
        var ClickStream = Observable.EveryUpdate()
    .Where( _ => Input.GetMouseButtonDown( 0 ) );

        var singleClickStream = ClickStream.Buffer( ClickStream.Throttle( TimeSpan.FromMilliseconds( 250 ) ) )
            .Where( xs => xs.Count == 1 );
        singleClickStream.Subscribe( xs => Debug.Log( "SingleClick Detected!" ) );
        var doubleClickStream = ClickStream.Buffer( ClickStream.Throttle( TimeSpan.FromMilliseconds( 200 ) ) )
            .Where( xs => xs.Count >= 2 );
        doubleClickStream.Subscribe( xs => Debug.Log( "DoubleClick Detected! Count:" + xs.Count ) );
    }
}
