using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*カメラとプレイヤーを横移動させるクラス*/
public class Move : MonoBehaviour
{
    public float playerSpeed = 5.0f; //カメラとプレイヤーの速度
    public static float playerDeltaSpeed; //1フレーム当たりの速度
    public float targetX = 1000.0f; //プレイヤーの移動先の仮目的地
    private int stageNumber = 1; //今のステージ番号
    private float acceleration = 0.01f; //加速量

    // Update is called once per frame
    public void MoveFixedUpdate()
    {
        /*ゲームオーバーでない限り以下を実行*/
        if (JudgeGameOver.gameOver == false)
        {
            playerDeltaSpeed = playerSpeed * Time.deltaTime;
            targetX += playerDeltaSpeed;
            Vector3 target = new Vector3(0, 0, targetX);
            transform.position = Vector3.MoveTowards(transform.position, target, playerDeltaSpeed); //1000m先の目的地に向かって走る

            /*ステージが変わるたびに速度を1上げる*/
            if (transform.position.z - (200 * stageNumber) > -5 && stageNumber != 5)
            {
                playerSpeed += acceleration;
                if (playerSpeed >= stageNumber + 5)
                {
                    playerSpeed = stageNumber + 5;
                    stageNumber++;
                    acceleration += 0.01f;
                }

                //Debug.Log(speed);
            }

        }
    }

}
