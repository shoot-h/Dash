using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*5ステージ目の球のバウンドを制御するクラス*/
public class GravityEdit : MonoBehaviour
{
    [SerializeField] private Vector3 localGravity;
    private Rigidbody rBody;

    // Use this for initialization
    private void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = false; //最初にrigidBodyの重力を使わなくする
    }

    private void FixedUpdate()
    {
        SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。
    }

    private void SetLocalGravity()
    {
        rBody.AddForce(localGravity, ForceMode.Acceleration);
    }
}
