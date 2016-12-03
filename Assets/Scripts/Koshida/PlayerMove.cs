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

    private bool move_entered;          //移動キー入力済み

    private float push_interval;        //キー入力間隔

    private bool dush_pend;             //ダッシュ待ち

    public bool is_jump = false;        //ジャンプ

    public enum InputType               //入力方法
    {
        KEY,        //キーボード
        PAD         //ゲームパッド
    }

    public InputType input_type;

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
        //入力タイプがパッド
        if(input_type == InputType.PAD)
        {
            x = Input.GetAxis("Horizontal");

            //左か右を入力
            if (x != 0)
            {
                move = true;
            }
            else
            {
                move = false;
            }
        }

        //入力タイプがキーボード
        if(input_type == InputType.KEY)
        {
            //右矢印キーを入力
            if(Input.GetKey(KeyCode.RightArrow))
            {
                move = true;
                move_entered = true;
                //ダッシュ待機中にもう一度入力
                if(dush_pend)
                {
                    x = 1.0f;
                }
                else
                {
                    x = 0.5f;
                }
            }
            //左矢印キーを入力
            else if(Input.GetKey(KeyCode.LeftArrow))
            {
                move = true;
                move_entered = true;
                //ダッシュ待機中にもう一度入力
                if (dush_pend)
                {
                    x = -1.0f;
                }
                else
                {
                    x = -0.5f;
                }
            }
            else
            {
                move = false;
                //一度移動キー入力済み
                if (move_entered)
                {
                    dush_pend = true;
                    push_interval += Time.deltaTime;
                    //0.2秒後に初期化
                    if (push_interval > 0.2)
                    {
                        push_interval = 0;
                        dush_pend = false;
                        move_entered = false;
                    }
                }
            }
        }

        //ジャンプ回数が2回未満で、ジャンプ入力
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

        //地面に着地
        if (layerName == "Ground")
        {
            is_jump = false;
            jump_count = 0;
        }
    }
}
