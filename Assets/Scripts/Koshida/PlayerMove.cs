using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private float jump = 100.0f;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        //左か右を入力したら
        if (x != 0)
        {
            //入力方向へ移動
            rb2D.velocity = new Vector2(x * speed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        //Zキーを入力したら
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //rb2D.velocity = new Vector2(0,)
        }
    }
}
