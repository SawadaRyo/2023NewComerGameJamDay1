using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float _speed;
    Animator _anim;
    SpriteRenderer _sp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       _anim = GetComponent<Animator>();

        _sp = GetComponent<SpriteRenderer>(); 


    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * _speed,0) ;
        if(h != 0 )
        { 
            if (h < 0)
            {
                //_sp.flipX = true;
                transform.rotation = Quaternion.Euler(0,180,0);
            }
            else
            {
                //_sp.flipX= false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        Vector3 pos = transform.position;
        //ˆÚ“®”ÍˆÍ‚ð•t‚¯‚½
        if(transform.position.x < -7 && h == -1)
        {
           pos.x = -7;
        }
        else if(transform.position.x > 8 && h == 1)
        {
            pos.x = 8;
        }
        transform.position = pos ;

        _anim.SetFloat("Move", rb.velocity.magnitude);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Enemy"))
    //    {
    //        _anim.SetBool("Death",true);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Enemy>(out _))
    //    {
    //        //_anim.SetBool("Death", true);
    //    }
    //}
}
