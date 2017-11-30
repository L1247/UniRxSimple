using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;

/// <summary>
/// Cold Observale 複數Steam
/// </summary>
public class ColdObservale_TimerSample : MonoBehaviour
{
    // Use this for initialization
    IEnumerator Start ( )
    {
        var intervalStream = Observable.Interval(TimeSpan.FromSeconds(1));
        intervalStream
            .Subscribe( x => Debug.Log( "[1]: " + Time.time.ToString( "F2" ) ) );

        yield return new WaitForSeconds( 0.1f );

        intervalStream
            .Subscribe( x => Debug.Log( "[2]: " + Time.time.ToString( "F2" ) ) );

        yield return new WaitForSeconds( 0.5f );

        intervalStream
            .Subscribe( x => Debug.Log( "[3]: " + Time.time.ToString( "F2" ) ) );

    }
}
