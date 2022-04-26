using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*砂嵐を生成するクラス*/
public class SandStormCreator : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Jump.player.z >= 195)
        {
            Instantiate(particle);
            Destroy(gameObject);
        }//暗幕がある間に砂嵐を生成する
    }
}
