using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*ゲーム終了画面の挙動を制御するクラス*/
public class FinishGame : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Title");
        }//Enterでタイトルに戻る

        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }//Ecsキーでゲームを終了する
    }
}
