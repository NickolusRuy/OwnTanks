using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private Vector2 vel;

    private const string BANG_ANIM = "Bang";
    private const string IDLE_ANIM = "Idle";
    private int speed = 10;
    private int speedForFast = 15;


    void Start()
    {

    }

    void Update()
    {
        if(body != null)
        {
            body.velocity = vel;
        }
    }

    public void Trow(Vector2 dir, bool isFast = false)
    {
        if (isFast)
        {
            dir *= speed;
        }
        else
        {
            dir *= speedForFast;
        }
        vel = dir;
    }

    public void ResetBullet()
    {
        vel = Vector2.zero;
        anim.Play(IDLE_ANIM);
        Pool.Instance.AddBullet(this);
    }

    public void InitComponents()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    private void RunBangAnim()
    {
        vel = Vector2.zero;
        anim.Play(BANG_ANIM);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(GameManager.BULLET_TAG))
        {
            RunBangAnim();
        }
        else if(col.CompareTag(GameManager.ENEMY_TAG))
        {
            RunBangAnim();
        }
        else if(col.CompareTag(GameManager.PLAYER_TAG))
        {
            RunBangAnim();
        }
        else if (col.CompareTag(GameManager.CONCRETE_TAG))
        {
            RunBangAnim();
        }
        else if (col.CompareTag(GameManager.BRICKS_TAG))
        {
            col.gameObject.SetActive(false);
            RunBangAnim();
        }
    }
}
