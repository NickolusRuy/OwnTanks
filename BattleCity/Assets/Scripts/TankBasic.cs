using UnityEngine;
using System.Collections;

public abstract class TankBasic: MonoBehaviour
{

    #region Move Variables
    protected const int TOP_ANGLE = 0;
    protected const int LEFT_ANGLE = 90;
    protected const int BOTTOM_ANGLE = 180;
    protected const int RIGHT_ANGLE = 270;
    #endregion

    protected Rigidbody2D body;
    protected Animator anim;
    protected BoxCollider2D boxCol;
    protected Vector3 rotateVector = new Vector3();
    protected Transform shotingPoint;

    [SerializeField]
    protected float moveSpeed;

    protected abstract void Start();
    protected abstract void Update();
    protected abstract void Move();
    protected abstract void Shot();
    protected abstract void ManageAnimation(bool holdPosition = false);
    protected abstract void Die();
    protected abstract void OnTriggerEnter2D(Collider2D col);

    protected void InitComponents()
    {
        shotingPoint = transform.GetChild(0);
        body = GetComponent<Rigidbody2D>();
      //  anim = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
    }
}

public enum MoveDirection
{
    Top,
    Right,
    Bottom,
    Left,
    HoldPosition
}
