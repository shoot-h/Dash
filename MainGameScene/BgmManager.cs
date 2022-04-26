using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*BGMの挙動を制御するクラス*/
public class BgmManager : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(JudgeGameOver.gameOver == true)
        {
            audioSource.Stop();
        }//ゲームオーバーの時，BGMを止める
    }
}
