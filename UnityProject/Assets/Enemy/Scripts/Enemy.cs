using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField, Header("エネミーのスピード")]
    float _speed = 5f;
    [SerializeField, Header("エネミーのジャンプ力")]
    float _jumpPower = 3f;
    [SerializeField,Range(0.1f,1), Header("エネミーのジャンプのインターバル")]
    float _jumpInterval = 0.5f;
    [SerializeField, Header("当たり判定")]
    Collider2D _collider;
    [SerializeField, Header("エネミーのImage")]
    Renderer _renderer;
    [SerializeField, Header("")]
    Rigidbody2D _rb;

    [Tooltip("")]
    bool _isActive = false;
    [Tooltip("")]
    bool _onGround = false;
    [Tooltip("")]
    Transform _playerTransform;

    public bool IsActive => _isActive;

    public void Instance(Transform playerTransForm)
    {
        _playerTransform = playerTransForm;
        _isActive = false;
        _rb.isKinematic = true;
        _collider.enabled = false;
        _renderer.enabled = false;
        Observable.EveryUpdate()
            .Where(_ => _isActive)
            .Subscribe(_ =>
            {
                Move(_speed,_playerTransform);
            }).AddTo(this);
        Observable.EveryUpdate()
            .Where(_ => JumpJudge(_playerTransform))
            .Subscribe(_ =>
            {
                Jump(_jumpPower, _jumpInterval);
            }).AddTo(this);
    }

    public void Move(float speed, Transform playerTransform)
    {
        float distansX = playerTransform.position.x - transform.position.x;
        Debug.Log(distansX);
        if (Mathf.Abs(distansX) > 0.1f)
        {
            Vector2 moveVec = new Vector2(distansX, _rb.velocity.y);
            _rb.velocity = moveVec.normalized * speed;
        }
        else if (Mathf.Abs(distansX) <= 0.1f)
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
        }
    }

    public async void Jump(float jumpPower, float interval)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(interval));
        _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
        _onGround = false;
    }

    bool JumpJudge(Transform playerTransform)
    {
        float distansY = playerTransform.position.y - transform.position.y;
        if (distansY >= 1f && _onGround) return true;
        return false;
    }

    public void Create(Transform generatePos)
    {
        gameObject.transform.position = generatePos.position;
        _isActive = true;
        _rb.isKinematic = false;
        _collider.enabled = true;
        _renderer.enabled = true;
    }

    public void Death()
    {
        _isActive = false;
        _rb.isKinematic = true;
        _collider.enabled = false;
        _renderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Hit();
        }
        else if(collision.tag == "Ground")
        {
            _onGround = true;
        }
    }

    public void Hit()
    {

    }
}
