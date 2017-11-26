using UnityEngine;
using UniRx.Triggers;
using UniRx;
using UnityEngine.UI;

public class AddScroeKeyEventByKeyDown : MonoBehaviour
{
    public IntReactiveProperty score = new IntReactiveProperty(0);
    public Text scroeText;
    // Use this for initialization
    void Start ( )
    {
        score.SubscribeToText( scroeText );

        //Add Score Value By Space KeyDown.
        var KeyDownStream = this.UpdateAsObservable()
        .Where( _ => Input.GetKeyDown( KeyCode.Space ) )
        .Subscribe( _ => {
            score.Value ++;
        } );
    }

}
