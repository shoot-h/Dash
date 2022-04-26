using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ステージの切り替え時に出現する暗幕を生成するクラス*/
public class AnmakuCreater : ObjectCreator
{
    int i = 0;
    int stagenum = 4;
    // Update is called once per frame
    public override void CreateObject()
    {

        if (Jump.player.z - (200 * i) > 184 && i < stagenum)
        {
            GameObject anmaku = Instantiate(obj[0]) as GameObject;
            anmaku.transform.localPosition = new Vector3(35, 5, Jump.player.z + 26);
            i++;
        }//各ステージの間で暗幕を表示させる

    }
}

