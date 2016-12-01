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
    private int m_hp;          // 体力
    [SerializeField]
    private int m_atk;         // 攻撃力(接触ダメージ)
    [SerializeField,Range(0,50)]
    private int m_spd_x;         // x速度
    [SerializeField, Range(0, 200)]
    private int m_spd_y;         // y速度
    [SerializeField]
    private Transform player;         // プレイヤートランスフォーム

    private direction_t m_direction;    // 向き

    private bool m_isLanded = true;

    // Use this for initialization
    void Start()
    {
        // player_scr = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのいる方向を判定
        if (player.position.x <= transform.position.x)
        {
            m_direction = direction_t.LEFT;
        }
        else
        {
            m_direction = direction_t.RIGHT;
        }

        // 地面に着地しているとき基本移動(プレイヤのいる方向へ跳ぶ)
        if (m_isLanded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2((int)m_direction * m_spd_x, m_spd_y));
            m_isLanded = false;
        }

        // 消滅判定
        if (m_hp <= 0)
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
            m_isLanded = true;
        }
    }
}
