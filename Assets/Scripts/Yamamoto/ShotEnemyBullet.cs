using UnityEngine;
using System.Collections;

public class ShotEnemyBullet : MonoBehaviour
{
    [SerializeField,Range(1.0f,10.0f)]
    private float speed_ = 1.0f;                // 弾の速度

    [SerializeField]
    private Transform playerTransform_;         // プレイヤートランスフォーム

    [SerializeField, Range(1.0f, 50.0f)]
    private float movwDistance_ = 0.0f;                // 移動距離

    private float popPosX_;         // 生成座標
    private int directionX_ = 1;     // x座標移動方向

    void Awake()
    {
        // 生成座標記憶
        popPosX_ = transform.position.x;

        // プレイヤーのいる方向を判定
        if (playerTransform_.position.x <= transform.position.x)
            directionX_ = -1 * directionX_;
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * (speed_*directionX_);
    }

    void Update()
    {
        if (transform.position.x <= popPosX_ + (movwDistance_ * directionX_))
        {
            Destroy(gameObject);
        }
    }
}
