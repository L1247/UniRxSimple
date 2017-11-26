using UnityEngine;
using UniRx.Triggers;
using UniRx;

/// <summary>
/// 刪除有加上此腳本的遊戲物件時會呼叫OnComplete
/// </summary>
public class KeyDownObserver : MonoBehaviour
{
    // Use this for initialization
    void Start ( )
    {
        var KeyDownStream = this.UpdateAsObservable()
        .Where( _ => Input.GetKeyDown( KeyCode.Space ) )
        .Subscribe(
            _ => { print( "OnNext" );},
            ex => { Debug.Log( "OnError" ); }
        , ( ) => { Debug.Log( "OnComplete" ); } );
    }
}
