using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    [SerializeField] float slashSpeed = 1f;
    [SerializeField] float slashDuration = 10f;
    [SerializeField] int slashdDamage = 10;

    private Rigidbody2D rb;
    Vector2 vec = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        

        //��莞�Ԍ�Ɏa����j������
        Destroy(gameObject, slashDuration);
    }
    public void Generate(Transform playerTrans)
    {
        transform.position = playerTrans.position;
        if(playerTrans.rotation.y <= -0.5f)
        {
            vec = Vector2.left;
            
        }
        else if(playerTrans.rotation.y > -0.5f)
        {
            vec = Vector2.right;
        }
        transform.rotation = playerTrans.rotation;
    }
    // Update is called once per frame
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        //���������I�u�W�F�N�g��"Enemy"�^�O�����Ƃ��A�_���[�W��^����
    //        //collision.GetComponent<EnemyHealth>().TakeDamage(slashdDamage);
    //    }
    //}
    private void Update()
    {
        //�a���̔��˕����Ɉړ�������
        rb.velocity = vec * slashSpeed;

    }
}
