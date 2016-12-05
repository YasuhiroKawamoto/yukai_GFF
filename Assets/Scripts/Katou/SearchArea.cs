/************************************************/
/* @file   Enemy_base.cs                        */
/* @brief  敵案１の索敵範囲のスクリプトファイル */
/* @date   2016/12/01                           */
/* @author 加藤 駿                              */
/************************************************/
using UnityEngine;
using System.Collections;

public class SearchArea : MonoBehaviour
{
    //当たっているかどうか
    private bool m_isDiscovery = false;
    public bool m_IsDiscovery
    {
        get { return m_isDiscovery; }
    }


    //当たっている位置
    private Vector2 m_hitPos;
    public Vector2 m_HitPos
    { get { return m_hitPos; } }


    /*--開始時に呼び出される--*/
    void Start ()
    {

    }

    /*--当たった瞬間呼ばれる--*/
    void OnTriggerEnter2D(Collider2D c)
    {
        //プレイヤーを発見！
        if (c.tag=="Player")
        {
           m_isDiscovery = true;
           m_hitPos = c.transform.position;
        }
    }

    /*--当たっている間呼ばれ続ける--*/
    void OnTriggerStay2D(Collider2D c)
    {
        //プレイヤーの位置を取得
        if (c.tag == "Player")
        {
            m_hitPos = c.transform.position;
        }
    }

    /*--当たって離れた時に呼ばれる--*/
    void OnTriggerExit2D(Collider2D c)
    {
        //プレイヤーを見失う
        if (c.tag == "Player")
        {
            m_isDiscovery = false;
        }
    }
}
