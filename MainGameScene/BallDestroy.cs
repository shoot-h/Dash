using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ボールを消去するクラス*/
public class BallDestroy : MonoBehaviour
{
    
    void Update()
    {
        if (Jump.player.z - transform.position.z > 15)
        {
            Destroy(gameObject);
        }//視えなくなったら消去する
    }
}
