using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Attack : MonoBehaviour
{
    public GameObject specialAttackPrefab;//特殊攻撃
    public Transform attackPoint; //斬撃の発射位置
    private int specialAttackPrefabCount = 0;
    [SerializeField] GameObject[] gameObjects;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //左クリック 通常攻撃
        {
            
        }

        if ((Input.GetMouseButtonDown(1)) && specialAttackPrefabCount < 3)//右クリック　特殊攻撃 向いた方向に斬撃
        {
            Instantiate(specialAttackPrefab, attackPoint.position, attackPoint.rotation);

            gameObjects[specialAttackPrefabCount].SetActive(false);
            specialAttackPrefabCount++;
            
            
        }
        
        
    }
}
