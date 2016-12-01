using UnityEngine;
using System.Collections;
enum direction_t
{
    RIGHT = 1,
    LEFT = -1
};
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int hp;          // 体力
    [SerializeField]
    private int atk;         // 攻撃力(接触ダメージ)
    [SerializeField]
    private int spd;         // 移動速度

    private Player player_scr;

    private direction_t direction;    // 向き

    private bool isLanded = true;

    // Use this for initialization
    void Start()
    {
        // player_scr = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのいる方向を判定
        //if(player_scr.transform.position.x <= transform.position.x)
        //{
        //    direction = direction_t.LEFT;
        //}
        //else
        //{
        //    direction = direction_t.RIGHT;
        //}

        // 地面に着地しているとき基本移動(プレイヤのいる方向へ跳ぶ)
        if (isLanded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * 20, 150));
            isLanded = false;
        }

        // 消滅判定
        if (hp <= 0)
        {
            // 消滅処理
            Destroy(gameObject);
        }
    }

    // 接触時の処理
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Land")
        {
            isLanded = true;
        }
    }
}
