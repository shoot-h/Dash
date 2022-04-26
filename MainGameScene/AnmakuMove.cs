using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*暗幕を移動させるクラス*/
public class AnmakuMove : MonoBehaviour
{

    void FixedUpdate()
    {
        Vector3 target = new Vector3(2, 4, 0);
        if (JudgeGameOver.gameOver == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Move.playerDeltaSpeed);
        }//プレイヤーの速度に合わせてフィールドの境が見えないようにする

        if (Jump.player.z - transform.position.z > 15)
        {
            Destroy(gameObject);
        }//視えなくなったら消去する
    }
}
