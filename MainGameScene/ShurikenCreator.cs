using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*手裏剣を生成するクラス*/
public class ShurikenCreator : ObjectCreator
{

    public override void CreateObject()
    {
        if (Jump.player.z > transform.position.z)
        {
            GameObject shuriken = Instantiate(obj[0]) as GameObject;
            shuriken.transform.localPosition = new Vector3(0, transform.position.y, transform.position.z + 17);
            Destroy(gameObject);
        }
    }
}
