using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*タイトル画面の挙動を制御するクラス*/
public class Title : MonoBehaviour
{
    [SerializeField] TitleCharaMove titleCharaMove = null;
    public static bool rankingPage;
    // Use this for initialization
    void Start()
    {
        rankingPage = false;
        GameScore.score = 0;
        JudgeGameOver.gameOver = false;
        Cursor.visible = false;
        titleCharaMove.TitleCharaMoveStart();
    }

    // Update is called once per frame
    void Update()
    {
        SceneLoad();
        titleCharaMove.TitleCharaMoveUpdate();
    }

    void SceneLoad()
    {
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Explain");
        }//Enterキーで説明画面に遷移する

        if (Input.GetButton("Jump"))
        {
            SceneManager.LoadScene("Result");
            rankingPage = true;
        }//スペースキーでランキング画面に遷移する

        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }//ECSキーでアプリを終了する
    }
}