using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float speed = 10.0f;        //移動スピード

    [SerializeField]
    private float jump_height = 11.0f;  //ジャンプの高さ

    private Rigidbody2D rb2D;

    private bool move;                  //移動

    private int jump_count = 0;         //ジャンプ回数

    public bool is_jump = false;        //ジャンプ

    float x;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(move)
        {
            //入力方向へ移動
            rb2D.velocity = new Vector2(x * speed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");

        //左か右を入力したら
        if (x != 0)
        {
            move = true;
        }
        else
        {
            move = false;
        }

        //ジャンプ回数が2回未満で、ジャンプ入力したら
        if (jump_count < 2 && Input.GetButtonDown("Jump"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jump_height);
            is_jump = true;
            jump_count++;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        //地面に着地したら
        if (layerName == "Ground")
        {
            is_jump = false;
            jump_count = 0;
        }

    }
}
