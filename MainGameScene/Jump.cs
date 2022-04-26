using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プレイヤーキャラクターの挙動のクラス*/
public class Jump : MonoBehaviour
{

    bool inAir = false;//空中にいるか判定用
    bool doJump = false;//ジャンプ中であるか判定用
    bool pushJumpButton = false;//ジャンプボタンを押したか判定用
    bool playerFall = false;//プレイヤーが穴に落ちたか判定用
    public float jump;//ジャンプの強さ設定用
    public float gravity;//重力の強さ設定用
    private Animator animator;
    public static Vector3 player;//プレイヤーの座標をほかのオブジェクトに渡す用

    // Use this for initialization
    public void JumpStart()
    {
        animator = GetComponent<Animator>();
        player = new Vector3(0, 0, 0);
    }

    public void JumpUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            pushJumpButton = true;
        }//スペースキーでジャンプ
    }

    // Update is called once per frame
    public void JumpFixedUpdate()
    {

        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        Vector3 jumping = new Vector3(0.0f, jump, 0.0f);    // 力を設定
        Vector3 gv = new Vector3(0.0f, gravity, 0.0f);//重力設定用

        player = transform.position;

        player.y += 0.55f;//体の中心のための調整

        if (player.y < -1)
        {
            JudgeGameOver.gameOver = true;
            playerFall = true;
        }

        rb.AddForce(gv);

        doJump = false;

        if (pushJumpButton == true && JudgeGameOver.gameOver == false)
        {
            pushJumpButton = false;
            //Debug.Log("getkey");
            if (inAir == false)
            {
                rb.AddForce(jumping);
                //Debug.Log("jumping");
                animator.SetBool("jump", true);
                inAir = true;
                doJump = true;
            }//接地しているかつスペースキーを押したときジャンプする

        }

        //Debug.Log(one);

        if (JudgeGameOver.gameOver == true)
        {
            if (playerFall == false)
            {
                animator.SetBool("gameover", true);
                Invoke("AnimeSpeed", 1.5f);
            }//ゲームオーバーの時，穴に堕ちてなければゲームオーバー用モーションを行う
            else
            {
                Destroy(gameObject);
            }//ゲームオーバーの時，穴に落ちていればプレイヤーを消去
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            inAir = false;
            animator.SetBool("jump", false);
            animator.SetBool("skyjump", false);
            //Debug.Log("grounded");
        }//地面についたとき，普通の地面なら接地判定

        else if (col.gameObject.tag == "Needle")
        {
            JudgeGameOver.gameOver = true;
        }//地面についたとき，針の上ならゲームオーバー

    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            inAir = true;
        }//接地していなければ空中判定
        //Debug.Log("jumping");
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Obstacle" && doJump == false)
        {
            inAir = false;
            //Debug.Log("stay");
        }//接地していば地上判定


    }

    void AnimeSpeed()
    {
        animator.speed = 0.0f;
    }
}
