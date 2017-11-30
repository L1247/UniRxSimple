using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SkipCountCall : MonoBehaviour
{
    public Button btn;
    public Text text1,text2;
    // Use this for initialization
    void Start ( )
    {
        //Press 3 Times, text1.text = 3.
        btn.OnClickAsObservable().Buffer( 3 ).
            SubscribeToText( text1 , _ => text1.text = "3" );
        //Press 3 Times, text1.text = 3. 推薦使用Skip
        btn.OnClickAsObservable().Skip( 2 ). 
            SubscribeToText( text1 , _ => text2.text = "3" );
    }
}
