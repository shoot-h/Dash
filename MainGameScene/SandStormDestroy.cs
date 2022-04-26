using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*砂嵐を消去するクラス*/
public class SandStormDestroy : MonoBehaviour
{
    void Update()
    {
        if (Jump.player.z >= 395)
        {
            Destroy(gameObject);
        }//暗幕の間に砂嵐を消す
    }
}
