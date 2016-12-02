/**********************************************/
/* @file   Enemy_base.cs                      */
/* @brief  敵の基底となるスクリプトファイル   */
/* @date   2016/12/01                         */ 
/* @author 加藤 駿                            */
/**********************************************/
using UnityEngine;
using System.Collections;

public class Enemy_base : MonoBehaviour
{

    //体力
    [SerializeField]
    public int hp = 1;

    //速度
    [SerializeField]
    public float speed = 0.0f;

    //攻撃力
    [SerializeField]
    public int power = 1;

    //接触時のダメージ
    [SerializeField]
    public int contactPower = 1;


    // 開始時に呼ばれる
    void Start()
    {
        // 回転させないように、zだけ固定	
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    //毎フレーム呼ばれる
    void Update()
    {
        //体力が０になった場合
        if (hp <= 0)
        {
            // 敵の削除
            Destroy(gameObject);
        }
    }

}
