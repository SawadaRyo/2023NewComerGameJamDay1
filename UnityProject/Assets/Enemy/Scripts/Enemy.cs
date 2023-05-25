using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    [SerializeField,Header("“–‚½‚è”»’è")]
    Collider2D _collider;
    [SerializeField,Header("Enemy‚ÌImage")]
    Renderer _renderer;

    public void Move()
    {

    }

    public void Instance()
    {

    }

    public void Create(Transform generatePos)
    {
        gameObject.transform.position = generatePos.position;
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

    public void Hit()
    {
        throw new System.NotImplementedException();
    }
}
