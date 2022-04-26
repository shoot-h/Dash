using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*オブジェクト生成の抽象クラス*/
public abstract class ObjectCreator : MonoBehaviour
{
    public GameObject[] obj = null;

    private void Update()
    {
        CreateObject();
    }

    /*オブジェクト生成の基本関数*/
    public virtual void CreateObject()
    {
        if (Jump.player.z > transform.position.z)
        {
            GameObject stage = Instantiate(obj[Random.Range(0, obj.Length)]) as GameObject;
            Destroy(gameObject);
        }
    }
}
