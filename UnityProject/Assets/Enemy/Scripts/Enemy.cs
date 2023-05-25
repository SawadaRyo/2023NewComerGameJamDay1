using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    [SerializeField,Header("�����蔻��")]
    Collider2D _collider;
    [SerializeField,Header("Enemy��Image")]
    Renderer _renderer;

    public void Move()
    {
        
    }

    public void Create()
    {
        _collider.enabled = true;
        _renderer.enabled = true;
    }

    public void Death()
    {
        _collider.enabled = false;
        _renderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            Death();
        }
    }
}
