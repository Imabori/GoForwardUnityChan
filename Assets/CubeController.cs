using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -0.2f;
    // 消滅位置
    private float deadLine = -10;

    //オーディオソースを格納する変数
    private AudioSource sound01;
    
    // Use this for initialization
    void Start()
    {
        sound01 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //ブロックが地面かブロックと衝突したか検知する
    void OnCollisionEnter2D(Collision2D other)
    {
        //ブロックと衝突した？
        if (other.gameObject.tag == "BlockTag")
        {
            sound01.PlayOneShot(sound01.clip);
            Debug.Log("SE Played");
        }
        //地面と衝突した？
        else if (other.gameObject.tag == "GroundTag")
        {
            sound01.PlayOneShot(sound01.clip);
            Debug.Log("SE Played");

        }
    }
}