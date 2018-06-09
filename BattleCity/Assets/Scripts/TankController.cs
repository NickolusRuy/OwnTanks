using UnityEngine;
using System.Collections;

public class TankController : TankBasic
{
    private MoveDirection direction = MoveDirection.Top;
    private const int FAST_STAGE = 2;
    private int currentStage = 0;

    protected override void Start()
    {
        InitComponents();
    }

    protected override void Update()
    {
        HandleInput();
        Move();
        Shot();
    }

    private void HandleInput()
    {
        //w - top
        // s - bot
        //d - right
        //a - left

        if(Input.GetKey(KeyCode.W))
        {
            direction = MoveDirection.Top;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            direction = MoveDirection.Bottom;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = MoveDirection.Left;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            direction = MoveDirection.Right;
        }
        else // no key pressed
        {
            direction = MoveDirection.HoldPosition;
        }
    }

    protected override void Move()
    {
        switch (direction)
        {
            case MoveDirection.Top:
                {
                    rotateVector = new Vector3(0, 0, TOP_ANGLE);
                    body.velocity = new Vector2(0, moveSpeed);
                }
                break;

            case MoveDirection.Bottom:
                {
                    rotateVector = new Vector3(0, 0, BOTTOM_ANGLE);
                    body.velocity = new Vector2(0, -moveSpeed);
                }
                break;

            case MoveDirection.Left:
                {
                    rotateVector = new Vector3(0, 0, LEFT_ANGLE);
                    body.velocity = new Vector2(-moveSpeed, 0);
                }
                break;

            case MoveDirection.Right:
                {
                    rotateVector = new Vector3(0, 0, RIGHT_ANGLE);
                    body.velocity = new Vector2(moveSpeed, 0);
                }
                break;

            case MoveDirection.HoldPosition:
                {
                    body.velocity = Vector2.zero;
                }
                break;

        }

        transform.eulerAngles = rotateVector;
        ManageAnimation();
    }

    protected override void ManageAnimation(bool holdPosition = false)
    {
        if(direction == MoveDirection.HoldPosition)
        {
            
        }
    }

    protected override void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet b = Pool.Instance.GetBullet();
            b.transform.eulerAngles = rotateVector;
            b.transform.position = shotingPoint.position;
            Vector2 dir = (shotingPoint.position - transform.position).normalized;
            b.Trow(dir, currentStage == FAST_STAGE);
        }
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {

    }

 
}
