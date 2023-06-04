using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Attack : MonoBehaviour
{
    public SlashAttack specialAttackPrefab;//特殊攻撃
    public Transform attackPoint; //斬撃の発射位置
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
        if (Input.GetMouseButtonDown(0)) //左クリック 通常攻撃
        {
            _anim.SetTrigger("Attack");
            _playerSFXController.AttackAudio();
        }

        if ((Input.GetMouseButtonDown(1)) && specialAttackPrefabCount < 3)//右クリック　特殊攻撃 向いた方向に斬撃
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
