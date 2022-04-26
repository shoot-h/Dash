using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ゲームオーバーか判定するクラス*/
public class JudgeGameOver : MonoBehaviour
{

    public static bool gameOver;

    private void OnTriggerEnter(Collider col)
    {
        /*ものに衝突するか針に刺さるとゲームオーバー*/
        if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Needle")
        {
            gameOver = true;
        }

    }
}