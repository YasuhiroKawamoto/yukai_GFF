using UnityEngine;
using System.Collections;

public class Enemy_move : MonoBehaviour
{
    //方向
    public enum DIRECTION
    {
        LEFT = -1,
        RIGHT = 1,
    }

    public int moveDistance = 1;          //片道の距離
    public DIRECTION startDirection       //開始時の方向
                        = DIRECTION.LEFT;
    private float countDistance = 0;      //距離のカウント
    private float x = 1;                  //右・左

    //コンポーネント
    Enemy_base enemy_base;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start ()
    {
        //コンポーネントを取得
        enemy_base = GetComponent<Enemy_base>();
        rb2d = GetComponent<Rigidbody2D>();

        //初期設定
        //開始時の方向を決定
        x = (int)startDirection;
    }

    // Update is called once per frame
    void Update ()
    {
        // 移動させる
        rb2d.velocity = new Vector2(x * enemy_base.speed, rb2d.velocity.y);
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
