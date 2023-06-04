using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Attack : MonoBehaviour
{
    public SlashAttack specialAttackPrefab;//����U��
    public Transform attackPoint; //�a���̔��ˈʒu
    private int specialAttackPrefabCount = 0;
    [SerializeField] GameObject[] gameObjects;
    Animator _anim;
    PlayerSFXController _playerSFXController;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _playerSFXController = GetComponent<PlayerSFXController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���N���b�N �ʏ�U��
        {
            _anim.SetTrigger("Attack");
            _playerSFXController.AttackAudio();
        }

        if ((Input.GetMouseButtonDown(1)) && specialAttackPrefabCount < 3)//�E�N���b�N�@����U�� �����������Ɏa��
        {
            _anim.SetTrigger("Attack");
            _playerSFXController.SpecialAttackAudio();
            var slash = Instantiate(specialAttackPrefab);
            slash.Generate(transform);
            gameObjects[specialAttackPrefabCount].SetActive(false);
            specialAttackPrefabCount++;
        }
        
        
    }
}
