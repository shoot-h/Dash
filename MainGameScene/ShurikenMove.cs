using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*手裏剣の挙動を制御するクラス*/
public class ShurikenMove : MonoBehaviour
{
    
    void FixedUpdate()
    {
        Vector3 target = new Vector3(2, 4, 0);
        if (JudgeGameOver.gameOver == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 5.0f * Time.deltaTime);
        }

        if (Jump.player.z - transform.position.z > 15)
        {
            Destroy(gameObject);
        }//視えなくなったら削除する
    }
}
