using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*コインの挙動とスコア加算を処理するクラス*/
public class ScoreAddition : MonoBehaviour
{

    public Rigidbody rb;
    private bool GetCoinState = false; //コインをとっている状態か判定
    private bool scoreAdd = false; //スコア加算が完了したかの判定
    private AudioSource audioSource;
    public AudioClip audioClip;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 360, 0) * Time.fixedDeltaTime, Space.World);//コインを回転させる
        if (GetCoinState == true)
        {
            transform.localScale = new Vector3(
                transform.localScale.x - 0.56f,
                transform.localScale.y - 2.52f,
                transform.localScale.z - 0.56f);
        }//コイン取得前にコインを小さくしていく
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            transform.position = Vector3.MoveTowards(transform.position, Jump.player, Move.playerDeltaSpeed * 3.5f);//コインに近づくとプレイヤーに近づいてい行く

            if (GetCoinState == false && scoreAdd == false)
            {
                GetCoinState = true;
            }

            if (scoreAdd == false)
            {
                Invoke("ScoreAdd", 0.1f);
                scoreAdd = true;
            }


        }

    }
    /*スコアを加算する関数*/
    void ScoreAdd()
    {
        GameScore.score += 1000;
        audioSource.PlayOneShot(audioClip);
        transform.localScale = new Vector3(0, 0, 0);
        GetCoinState = false;
        Destroy(gameObject, 0.3f);
    }
}
