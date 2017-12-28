using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;
using System;
using System.Collections;

public class UniRxPractice : MonoBehaviour
{
    public Button btn;
    public Text text1,text2,text3;
    public int i;
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
