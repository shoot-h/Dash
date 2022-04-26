using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*リザルト画面の挙動を制御するクラス*/
public class Result : MonoBehaviour
{
    private int score = GameScore.score;//プレイしたスコア
    public static int[] highscore = new int[3];//歴代3位までのハイスコア
    private int scoretmp;//スコア一時格納用
    private float time;//タイマー
    public Text myScoreText;
    public Text pressEnterText;
    public Text sceneTitleText;
    public Text[] highscoreText = new Text[3];
    public Image newRecordImage1;
    public Image newRecordImage2;
    public Image newRecordImage3;
    public AudioClip scoreSE;
    public AudioClip newRecordSE;
    private AudioSource audioSource;
    private bool clip1;
    private bool clip2;

    void Start()
    {
        Cursor.visible = false;
        for (int i = 0; i < highscore.Length; i++)
        {
            highscore[i] = PlayerPrefs.GetInt("Score" + (i + 1));
            highscoreText[i].text = "Score:" + highscore[i].ToString();
        }//各ハイスコアを取り出してくる
        myScoreText.enabled = false;
        myScoreText.text = "Score:" + score.ToString();
        pressEnterText.enabled = false;
        newRecordImage1.enabled = false;
        newRecordImage2.enabled = false;
        newRecordImage3.enabled = false;
        clip1 = false;
        clip2 = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Title.rankingPage == false)
        {
            ResultScene();
        }//メインゲーム画面から来た時の処理

        if (Title.rankingPage == true)
        {
            ChangeTextforRanking();

            if (Input.GetButton("Submit")) SceneManager.LoadScene("Title");
        }//スタート画面からきたときの処理，Enterでタイトルに戻る

        if (Input.GetButton("Cancel")) SceneManager.LoadScene("GameOver");//ECSキーでゲーム終了画面に遷移

        if (Input.GetKeyDown(KeyCode.R)) ScoreReset();//Rキーでスコアリセット
    }

    private void ResultScene()
    {
        time += Time.deltaTime;

        if (time > 1.0f && clip1 == false)
        {
            myScoreText.enabled = true;
            audioSource.PlayOneShot(scoreSE);
            clip1 = true;
        }//遷移から1秒経ったらスコア表示

        if (time > 2.0f && clip2 == false)
        {
            if (score >= highscore[2])
            {
                UpdateHighscore();
                DispNewRecord();
            }
            pressEnterText.enabled = true;
            clip2 = true;
        }//遷移から2秒経ったらハイスコア更新

        if (Input.GetButtonDown("Submit"))
        {
            if (time > 2.0f)
            {
                GameScore.score = 0;
                JudgeGameOver.gameOver = false;
                SceneManager.LoadScene("Main");
            }
            else if (time > 1.0f) time = 2.0f;
            else time = 1.0f;
        }//Enterキーは各タイマーによる動作の早送りとゲームメイン画面への遷移をおこなう
    }

    /*ハイスコアを更新する関数*/
    private void UpdateHighscore()
    {
        for (int i = 0; i < highscore.Length; i++)
        {
            if (score >= highscore[i])
            {
                scoretmp = highscore[i];
                highscore[i] = score;
                score = scoretmp;
                PlayerPrefs.SetInt("Score" + (i + 1), highscore[i]);
                highscoreText[i].text = "Score:" + highscore[i].ToString();
            }
        }
        audioSource.PlayOneShot(newRecordSE);
    }

    /*NewRecordの画像を表示させる関数*/
    private void DispNewRecord()
    {
        if (highscore[0] == GameScore.score)
        {
            newRecordImage1.enabled = true;
        }
        else if (highscore[1] == GameScore.score)
        {
            newRecordImage2.enabled = true;
        }
        else if (highscore[2] == GameScore.score)
        {
            newRecordImage3.enabled = true;
        }
    }

    /*ランキングページ用の文に変える関数*/
    private void ChangeTextforRanking()
    {
        sceneTitleText.text = "Ranking";
        pressEnterText.text = "Press Enter";
        pressEnterText.enabled = true;
    }

    /*スコアリセットする関数*/
    private void ScoreReset()
    {
        for (int i = 0;i < 3;i++)
        {
            highscore[i] = 0;
            PlayerPrefs.SetInt("Score" + (i+1), highscore[i]);
            highscoreText[i].text = "Score:" + highscore[i].ToString();
        }
    }
}

