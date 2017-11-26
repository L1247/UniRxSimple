using UnityEngine;
using UniRx.Triggers;
using UniRx;
using UnityEngine.UI;

public class ValueChangedMono : MonoBehaviour
{
    public Mono1 mono1;
    public Text scoreText;
    // Use this for initialization
    void Start ( )
    {
        // 數值改變，on this gameObjcet
        var isMonoListener = this.UpdateAsObservable().Select( _ => mono1.isMono ).
            DistinctUntilChanged().Where( x => x == true ).
            Subscribe( _ => print( mono1.isMono ) );
        // 數值改變，OnMainThreadDispatcher
        mono1.ObserveEveryValueChanged( exam1 => exam1.isMono ).Where( x => x == true )
            .Subscribe( newHp => scoreText.text = newHp.ToString() );
    }
}
