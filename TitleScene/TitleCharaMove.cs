using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*タイトルのキャラクターのモーション用クラス*/
public class TitleCharaMove : MonoBehaviour
{
    Vector3 target = new Vector3(5.5f, -3.5f, 0);//キャラクターの止まる
    private Animator animator;
    // Start is called before the first frame update
    public void TitleCharaMoveStart()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void TitleCharaMoveUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 15.0f * Time.deltaTime);

        if (transform.position == target)
        {
            animator.SetBool("arrive", true);
        }
    }
}
