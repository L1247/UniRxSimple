using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;

/// <summary>
/// 故意刪除此物件，這樣參考會消失，從而導致錯誤出現。
/// </summary>
public class AvoidNullReferenceError : MonoBehaviour
{
    public Text Text1,Text2 , Text3;
    // Use this for initialization
    void Start ( )
    {
        // 第一種作法，不會跳出Null。
        //this.UpdateAsObservable()
        Observable.EveryUpdate()
            .Select( _ => transform.position )
            .Subscribe(
            _ => { Text1.text = _.ToString(); } ,
            ex => { Debug.Log( "OnError" ); } ,
            ( ) => { Debug.Log( "OnComplete" ); } );

        // 第二種作法，因為Null時也會.ToString()，所以出現Exception.
        Observable.EveryUpdate()
            .Select( _ => transform.position )
            .SubscribeToText( Text2 );

        // 第三種方式，自動丟棄，偵測該物件是否被刪除，如果是，則自動Dispose。
        Observable.EveryUpdate()
           .Select( _ => transform.position )
           .SubscribeToText( Text3 )
           .AddTo(gameObject);
    }
}
