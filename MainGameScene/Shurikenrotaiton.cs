using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*手裏剣の回転を制御するクラス*/
public class Shurikenrotaiton : MonoBehaviour
{
    
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(-720, 0, 0) * Time.fixedDeltaTime, Space.World);
    }
}
