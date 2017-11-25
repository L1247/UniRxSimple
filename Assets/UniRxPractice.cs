using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UniRxPractice : MonoBehaviour
{
    public IntReactiveProperty score = new IntReactiveProperty(0);
    //public int score;
    public Text scoreText1;
    public Text scoreText2;
    public Text scoreText3;
    bool b;
    public int hp;
    public Mono1 mono1;
    // Use this for initialization
    void Start ( )
    {
        //score.SubscribeToText( scoreText );

        //var updateScore = this.UpdateAsObservable().Subscribe( _ => { score.Value++; } );
        //var KeyDownStream = this.UpdateAsObservable()
        //.Where( _ => Input.GetKeyDown( KeyCode.Space ) )
        //.Subscribe( _ => {
        //    print( "Dispose sbuscribe" );
        //    updateScore.Dispose();
        //} );

        //數值改變，on this gameObjcet
        //this.UpdateAsObservable().Select( _ => mono1.isMono ).
        //    DistinctUntilChanged().Where( x => x == true ).
        //    Subscribe( _ => print( mono1.isMono ) );
        //數值改變，OnMainThreadDispatcher
        //Once per second, execute command to damage player
        //mono1.ObserveEveryValueChanged( exam1 => exam1.isMono ).Where( x => x == true )
        //    .Subscribe( newHp => scoreText.text = newHp.ToString() );

        //數值一變就會執行，但只有 x => x == 100 || x < 0 成立才有
        mono1.ObserveEveryValueChanged( exam1 => exam1.c1.score ).Where( x => x == 100 || x < 0 )
           .Subscribe( score => scoreText1.text = score.ToString() );

        //數值一變就會執行，所以一開始就會執行，bool型態
        mono1.ObserveEveryValueChanged( exam1 => exam1.c1.score ==100) 
           .Subscribe( score => scoreText2.text = score.ToString() );

        //數值一變就會執行，所以一開始就會執行，int型態
        mono1.ObserveEveryValueChanged( exam1 => exam1.c1.score  )
           .Subscribe( score => scoreText3.text = score.ToString() );
    }

    private void ExecutedamagePerSecondTick ( )
    {
        print( "ExecutedamagePerSecondTick" );
    }

    // Update is called once per frame
    void Update ( )
    {

    }
}
