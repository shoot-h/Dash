using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*スコアを計算し表示させるクラス*/
public class GameScore : MonoBehaviour {
    public static int score;
    private Text text;

    public void GameScoreStart()
    {
        score = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    public void GameScoreFixedUpdate()
    {
        if (JudgeGameOver.gameOver == false)
        {
            score += 12;
        }//50fpsの1フレームで12点追加する

        text.text = "Score:" + score.ToString();
    }
}
