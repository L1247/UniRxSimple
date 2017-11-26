using UnityEngine;
using UniRx.Triggers;
using UniRx;
using UnityEngine.UI;

public class UpdateTickEvent : MonoBehaviour
{
    public IntReactiveProperty score = new IntReactiveProperty(0);
    public Text scroeText;
    // Use this for initialization
    void Start ( )
    {
        score.SubscribeToText( scroeText );
        var updateScore = this.UpdateAsObservable().Subscribe( _ => { score.Value++; } );

        //Stop By Space Key Down.
        var KeyDownStream = this.UpdateAsObservable()
        .Where( _ => Input.GetKeyDown( KeyCode.Space ) )
        .Subscribe( _ => {
            //Disable Observer
            updateScore.Dispose();
        } );
    }
}
