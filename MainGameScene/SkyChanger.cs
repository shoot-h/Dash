using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*背景の空を変化させるクラス*/
public class SkyChanger : MonoBehaviour
{
    public Material[] sky;
    int num = 0;
    bool max = false;

    public void SkyChangerUpdate()
    {
        if (Jump.player.z - (num * 200)>= 194 && max == false)
        {
            num += 1;
        }

        if (num >= sky.Length)
        {
            num = sky.Length - 1;
            max = true;
        }

        RenderSettings.skybox = sky[num];
    }
}
