/**********************************************/
/* @file   Enemy_base.cs                      */
/* @brief  敵案１のスクリプトファイル         */
/* @date   2016/12/01                         */
/* @author 加藤 駿                            */
/**********************************************/
using UnityEngine;
using System.Collections;

public class Enemy_1 : MonoBehaviour
{
    //方向
    public enum DIRECTION
    {
        LEFT = -1,
        RIGHT = 1,
    }

    //コンポーネント
    Enemy_base enemy_base;
    Rigidbody2D rb2d;
    SearchArea searchArea;
    
    public int moveDistance = 1;          //片道の距離
    public DIRECTION startDirection       //開始時の方向
                        = DIRECTION.LEFT;
    public float jumpHeight = 1.0f;       //ジャンプ力
    public float jumpSpeed = 1.0f;        //ジャンプ時のスピード
    public LayerMask groundLayer;         //Linecastで判定するLayer

    private float countDistance = 0;      //距離のカウント
    private float x = 1;                  //右・左
    private bool isGround = false;        //足元が地面かどうかの判定
    private bool isDiscovery = false;      //プレイヤーを発見したかどうかの判定


    /*--開始時に呼び出される--*/
    void Start ()
    {
        //キャッシュ
        enemy_base = GetComponent<Enemy_base>();
        rb2d = GetComponent<Rigidbody2D>();

        //子のコンポーネントを取得
        searchArea = GetComponentInChildren<SearchArea>();

        //初期設定
        //開始時の方向を決定
        x = (int)startDirection;
    }


    /*--毎フレーム呼び出される--*/
    void Update ()
    {
        //足元が地面かどうかの判定
        isGround = Physics2D.Linecast(
        transform.position + transform.up * 0.5f,
        transform.position - transform.up * 0.5f,
        groundLayer);
 
        //isDiscovery=searchArea.
        /*--プレイヤーを発見したかどうかの判定--*/
        if (isDiscovery)
        {        
            /*プレイヤーを発見している場合*/

            //プレイヤーとの位置関係を確認

            // 移動させる
            rb2d.velocity = new Vector2(x * jumpSpeed, rb2d.velocity.y);
            
            /*--足元が地面かどうかの判定--*/
            if (isGround)
            {
                //足元が地面の場合
                //ジャンプ
                rb2d.AddForce(Vector2.up * jumpHeight);

                //地面の判定を外す
                isGround = false;
            }
        }
        else
        {
            /*プレイヤーを発見していない場合*/

            /*--足元が地面がどうかの判定--*/
            if (isGround)
            {
                // 移動させる
                rb2d.velocity = new Vector2(x * enemy_base.speed, rb2d.velocity.y);
            }

            //移動距離をカウント
            countDistance += enemy_base.speed;

            /*--移動距離が規定値を超えた場合--*/
            if (countDistance >= moveDistance)
            {
                //方向を変える
                x *= -1;

                //カウントをリセットする
                countDistance = 0;
            }
        }
    }
}

