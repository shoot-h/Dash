using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

/*説明画面の挙動のクラス*/
public class Explain : MonoBehaviour
{
    public Text pressEnterText;
    // Use this for initialization
    void Start()
    {
        pressEnterText.enabled = false;
        Cursor.visible = false;
        Invoke("DelayMethod", 2.0f);//2秒後にエンターでスタートを表示させる
    }

    // Update is called once per frame
    void DelayMethod()
    {
        pressEnterText.enabled = true;
    }

    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Main");
        }//エンターでメインのプレイ画面に

        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }//ESCキーでアプリ終了
    }
}
