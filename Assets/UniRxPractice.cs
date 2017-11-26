using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;


public class UniRxPractice : MonoBehaviour
{
    public Button btn;
    public Text text1,text2,text3;
    // Use this for initialization
    void Start ( )
    {
        //Press 3 Times, text1.text = 3.
        btn.OnClickAsObservable().Buffer( 3 ).
            SubscribeToText( text1 , _ => text1.text = "3");
        //Press 3 Times, text1.text = 3. 推薦使用Skip
        btn.OnClickAsObservable().Skip( 2 ).
            SubscribeToText( text1 , _ => text2.text = "3" );
    }
}
