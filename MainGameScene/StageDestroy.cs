using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ステージを削除するクラス*/
public class StageDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Jump.player.z - transform.position.z > 55)
        {
            Destroy(gameObject);
        }/*プレイヤーが離れたらステージ削除*/
    }
}
