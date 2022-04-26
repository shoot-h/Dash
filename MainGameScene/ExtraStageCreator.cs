using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*エクストラステージを生成するクラス*/
public class ExtraStageCreator : ObjectCreator
{
    public int ZPos;

    public override void CreateObject()
    {
        if (transform.position.z < Jump.player.z)
        {
            GameObject stage = Instantiate(obj[Random.Range(0, obj.Length)]) as GameObject;
            stage.transform.position = new Vector3(0,0,ZPos);
            ZPos += 50;
            transform.position = new Vector3(0, 0, transform.position.z + 50);
        }//通常のステージが尽きたら候補のステージをランダムに出現させ続ける
    }
}
