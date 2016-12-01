﻿/************************************************/
/* @file   Enemy_base.cs                        */
/* @brief  敵案１の索敵範囲のスクリプトファイル */
/* @date   2016/12/01                           */
/* @author 加藤 駿                              */
/************************************************/
using UnityEngine;
using System.Collections;

public class SearchArea : MonoBehaviour
{
    Enemy_1 enemy;

    /*--開始時に呼び出される--*/
    void Start ()
    {
        //親のコンポーネントを取得
        enemy = GetComponentInParent<Enemy_1>();
	}

    /*--当たった瞬間呼ばれる--*/
    void OnTriggerEnter2D(Collider2D c)
    {
        //プレイヤーを発見！
        enemy.isDiscovery = true;
    }

    /*--当たって離れた時に呼ばれる--*/
    void OnTriggerExit2D(Collider2D c)
    {
        //プレイヤーを見失う
        enemy.isDiscovery = false;
    }
}
