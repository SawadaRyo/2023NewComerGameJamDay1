using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    [SerializeField] float slashSpeed = 1f;
    [SerializeField] float slashDuration = 10f;
    [SerializeField] int slashdDamage = 10;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        

        //��莞�Ԍ�Ɏa����j������
        Destroy(gameObject, slashDuration);
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
        rb.velocity = transform.right * slashSpeed;
    }
}
