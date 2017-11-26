using UniRx;
using UnityEngine;
using UnityEngine.UI;

/*
*	參考自 https://qiita.com/toRisouP/items/d0d32cf674a00f3a8427
*/
public class ObserveEveryValueChangedMono : MonoBehaviour
{
    public Text scoreText1;
    public Text scoreText2;
    public Text scoreText3;
    public Mono1 mono1;

    void Start ( )
    {
        // 數值一變就會執行，但只有 x => x == 100 || x < 0 成立才有
        mono1.ObserveEveryValueChanged( exam1 => exam1.c1.score ).Where( x => x == 100 || x < 0 )
           .Subscribe( score => scoreText1.text = score.ToString() );

        // 數值一變就會執行，所以一開始就會執行，bool型態 x == 100 印出true
        mono1.ObserveEveryValueChanged( exam1 => exam1.c1.score == 100 )
           .Subscribe( score => scoreText2.text = score.ToString() );

        // 數值一變就會執行，所以一開始就會執行，int型態
        mono1.ObserveEveryValueChanged( exam1 => exam1.c1.score )
           .Subscribe( score => scoreText3.text = score.ToString() );
    }
}

