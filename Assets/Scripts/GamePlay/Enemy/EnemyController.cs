using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float walkDistance = 6.0f;
    [SerializeField] private float patrolSpeed = 1.0f;
    [SerializeField] private float ChasingSpeed = 3.0f;
    [SerializeField] private float timeDuration = 5.0f;
    [SerializeField] private float timeToChase = 3.0f;
    [SerializeField] private float minDistanceToPlayer = 1.5f;

    private Rigidbody2D _enemyRidgitbody2D;
    private Transform _playerTransform;
    private Vector2 _isLeftBoundaryPosision;
    private Vector2 _isRightBoundaryPosition;
    private Vector2 _nextPoint;

    private bool _isFacingRight = true;
    private bool _isWait = false;
    private bool _isChasingPlayer = false;

    private float _waitTime;
    private float _chaseTime;
    private float _walkSpeed;

    public bool IsFacingRight
    {
        get => _isFacingRight;
    }

    public void StartChasingPleyer()
    {
        _isChasingPlayer = true;
        _chaseTime = timeToChase;
        _walkSpeed = ChasingSpeed;
    }
    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _enemyRidgitbody2D = gameObject.GetComponent<Rigidbody2D>();

        _isLeftBoundaryPosision = transform.position;

        _isRightBoundaryPosition = _isLeftBoundaryPosision + Vector2.right * walkDistance;

        _waitTime = timeDuration;
        _chaseTime = timeToChase;
        _walkSpeed = patrolSpeed;
    }

    private void Update()
    {
        if (_isChasingPlayer)
        {
            StartChasingTimer();

        }

        if (_isWait && !_isChasingPlayer)
        {
            StartWatingTimer();
        }



        if (ShouldWait())
        {
            _isWait = true;
        }
    }
    private void FixedUpdate()
    {
        _nextPoint = Vector2.right * _walkSpeed * Time.fixedDeltaTime;
        if (_isChasingPlayer && Mathf.Abs(DistanceToPlayer()) < minDistanceToPlayer)
        { return; }


        if (_isChasingPlayer)
        {
            ChasingPlayer();
        }
        if (!_isWait && !_isChasingPlayer)
        {
            Patrol();

        }

    }
    private void Patrol()
    {
        if (!_isFacingRight)
            _nextPoint *= -1;

        _enemyRidgitbody2D.MovePosition((Vector2)transform.position + _nextPoint);
    }
    private void ChasingPlayer()
    {
        float distance = DistanceToPlayer();
        float multiplaer = distance > 0 ? 1 : -1;
        _nextPoint *= multiplaer;
        if (distance > 0.2f && !_isFacingRight)
            Flip();
        else if (distance < 0.2f && _isFacingRight)
            Flip();

        _enemyRidgitbody2D.MovePosition((Vector2)transform.position + _nextPoint);
    }

    private float DistanceToPlayer()
    {
        return _playerTransform.position.x - transform.position.x;
    }

    private void StartWatingTimer()
    {
        _waitTime -= Time.deltaTime;
        if (_waitTime < 0f)
        {
            _waitTime = timeDuration;
            _isWait = false;
            Flip();
        }

    }

    private void StartChasingTimer()
    {
        _chaseTime -= Time.deltaTime;
        if (_chaseTime < 0f)
        {
            _walkSpeed = patrolSpeed;
            _isChasingPlayer = false;
            _chaseTime = timeToChase;
        }

    }

    private bool ShouldWait()
    {
        bool isOutOfRigtBoundory = _isFacingRight && transform.position.x >= _isRightBoundaryPosition.x;
        bool isOutOfLeftBoundory = !_isFacingRight && transform.position.x <= _isLeftBoundaryPosision.x;

        return isOutOfLeftBoundory || isOutOfRigtBoundory;

    }
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = this.gameObject.transform.GetChild(0).transform.localScale;
        playerScale.x *= -1;
        this.gameObject.transform.GetChild(0).transform.localScale = playerScale;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_isLeftBoundaryPosision, _isRightBoundaryPosition);
    }

}
