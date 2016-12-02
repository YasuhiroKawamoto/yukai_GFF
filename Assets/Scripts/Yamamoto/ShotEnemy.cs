using UnityEngine;
using System.Collections;

public class ShotEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet_;  // 弾
    [SerializeField,Range(0.1f,5.0f)]
    private float bulletDelayTime__ = 3.0f;  // 弾待機時間

    // Startをコルーチンで呼ぶ
    IEnumerator Start()
    {
        bool init = true;

        while (true)
        {
            if (init)
            {
                init = false;
            }
            else
            {
                // 弾を作成
                Instantiate(bullet_, transform.position, transform.rotation);
            }

            // 3.0秒待つ
            yield return new WaitForSeconds(bulletDelayTime__);
        }
    }


    // 更新処理
	void Update ()
    {
    }
}
