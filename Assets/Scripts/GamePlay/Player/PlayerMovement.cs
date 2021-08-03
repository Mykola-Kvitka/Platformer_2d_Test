using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ZeroInvokerEvent
{
    [SerializeField] private float speedX = 1f;

    //[SerializeField] private Animator animator;

    private Rigidbody2D _rb;

    private float _horizontal;

    private const float _jumpForceX = 500.0f;
    private const float _jumpForceY = 0.0f;
    private const float _speedMultiplaer = 50f;

    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFacingRight = true;
    private bool _isFinish = false;
    private bool _isLeverArm = false;


    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        unityEventsZ.Add(EventName.Finish, new FinishEvent());
        EventManager.AddZeroInvoker(EventName.Finish, this); 
        unityEventsZ.Add(EventName.MovePlayer, new MovePlayerEvent());
        EventManager.AddZeroInvoker(EventName.MovePlayer, this);
        unityEventsZ.Add(EventName.Set_Active, new Set_ActiveEvent());
        EventManager.AddZeroInvoker(EventName.Set_Active, this);      
        unityEventsZ.Add(EventName.LeverArmActive, new LeverArmActiveEvent());
        EventManager.AddZeroInvoker(EventName.LeverArmActive, this);

        EventManager.AddZeroListener(EventName.LeverArm, isLeverArmEvent_);

    }

    // Update is called once per frame
    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W) && _isGround)
            _isJump = true;
        if (Input.GetKeyDown(KeyCode.F) && _isFinish)
        {
            unityEventsZ[EventName.Finish].Invoke();
        }     
        if (Input.GetKeyDown(KeyCode.F) && _isLeverArm)
        {
            unityEventsZ[EventName.Set_Active].Invoke();
            unityEventsZ[EventName.LeverArmActive].Invoke();
         }

    }
    private void FixedUpdate()
    {
        Move();
        if (_isJump) 
            Jump();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_horizontal * speedX * _speedMultiplaer * Time.fixedDeltaTime, _rb.velocity.y);

        if (_horizontal > 0f && !_isFacingRight)
            Flip();
        else if (_horizontal < 0f && _isFacingRight)
            Flip();
        else
            unityEventsZ[EventName.MovePlayer].Invoke();

    }

    private void Jump()
    {
        _rb.AddForce(new Vector2(_jumpForceY, _jumpForceX)) ;
        _isGround = false;
        _isJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            _isGround = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            _isFinish = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            _isFinish = false;
        }
    }
    private void Flip()
    {
        unityEventsZ[EventName.MovePlayer].Invoke();
        _isFacingRight = !_isFacingRight;
        
        Vector3 playerScale = this.gameObject.transform.GetChild(0).transform.localScale;
        playerScale.x *= -1;
        this.gameObject.transform.GetChild(0).transform.localScale = playerScale;
    }

    private void isLeverArmEvent_()
    {
        if (!_isLeverArm)
            _isLeverArm = true;
        else
            _isLeverArm = false;
    }
  
}
