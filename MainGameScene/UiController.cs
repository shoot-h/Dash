using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*メイン画面の画面遷移を行うクラス*/
public class UiController : MonoBehaviour
{

    public Text gameOverText;
    public Text enterText;
    public Image uiBack;

    // Use this for initialization
    public void UiControllerStart()
    {
        gameOverText.enabled = false;
        enterText.enabled = false;
        uiBack.enabled = false;
    }

    // Update is called once per frame
    public void UiControllerUpdate()
    {
        if (JudgeGameOver.gameOver)
        {
            gameOverText.enabled = true;
            uiBack.enabled = true;
            Invoke("PressEnter", 1.0f);
        }

    }


    private void PressEnter()
    {
        enterText.enabled = true;
    }
}