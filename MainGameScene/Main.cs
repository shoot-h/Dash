using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*メインゲーム画面の制御クラス*/
public class Main : MonoBehaviour
{
    [SerializeField] Move move = null;
    [SerializeField] SkyChanger skyChanger = null;
    [SerializeField] Jump jump = null;
    [SerializeField] UiController uiController = null;
    [SerializeField] GameScore gameScore = null;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        if (jump != null) jump.JumpStart();
        uiController.UiControllerStart();
        gameScore.GameScoreStart();
    }

    // Update is called once per frame
    void Update()
    {
        skyChanger.SkyChangerUpdate();
        if (jump != null) jump.JumpUpdate();
        uiController.UiControllerUpdate();

        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("GameOver");
        }//ECSキーで終了画面に

        if (Input.GetButton("Submit") && JudgeGameOver.gameOver)
        {
            SceneManager.LoadScene("Result");
        }//ゲームオーバー時，Enterキーでリザルト画面に
    }

    private void FixedUpdate()
    {
        move.MoveFixedUpdate();
        if(jump != null)jump.JumpFixedUpdate();
        gameScore.GameScoreFixedUpdate();
    }
}
