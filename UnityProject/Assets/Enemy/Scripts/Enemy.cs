using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField, Header("エネミーのスピード")]
    float _speed = 5f;
    [SerializeField, Header("エネミーのアニメーション")]
    Animator _animator;
    [SerializeField, Header("当たり判定")]
    Collider2D _collider;
    [SerializeField, Header("エネミーの画像")]
    Renderer _renderer;
    [SerializeField, Header("")]
    Rigidbody2D _rb;

    [Tooltip("")]
    bool _isActive = false;
    [Tooltip("")]
    Transform _playerTransform;
    [Tooltip("")]
    EnemyManager _enemyManager;

    public bool IsActive => _isActive;

    public void Instance(EnemyManager enemyManager, Transform playerTransForm)
    {
        _enemyManager = enemyManager;
        _playerTransform = playerTransForm;
        _isActive = false;
        _rb.isKinematic = true;
        _collider.enabled = false;
        _renderer.enabled = false;
        Observable.EveryUpdate()
            .Where(_ => _isActive)
            .Subscribe(_ =>
            {
                Move(_speed, _playerTransform);
            }).AddTo(this);
    }

    public void Move(float speed, Transform playerTransform)
    {
        float distansX = playerTransform.position.x - transform.position.x;
        if (Mathf.Abs(distansX) > 0.1f)
        {
            Vector2 moveVec = new Vector2(distansX, 0).normalized;
            _rb.velocity = new Vector2(moveVec.x, _rb.velocity.y).normalized * speed;
        }
        else if (Mathf.Abs(distansX) <= 0.1f)
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
        }
    }
    public void Create(Transform generatePos)
    {
        gameObject.transform.position = generatePos.position;
        _animator.SetBool("Death", false);
        _isActive = true;
        _rb.isKinematic = false;
        _collider.enabled = true;
        _renderer.enabled = true;
    }

    public void Death()
    {
        
        _isActive = false;
        _renderer.enabled = false;
    }

    public void Hit()
    {
        if (_isActive)
        {
            _enemyManager.DeathCounter();
        }
        _collider.enabled = false;
        _rb.isKinematic = true;
        _animator.SetBool("Death", true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            Hit();
        }
        else if (collision.TryGetComponent<PlayerMove>(out _))
        {
            FindObjectOfType<GameManager>().State = GameManager.GameState.GameOver;
        }
        else if (collision.tag == "Ground")
        {
            _animator.SetTrigger("OnGround");
        }
    }

}
