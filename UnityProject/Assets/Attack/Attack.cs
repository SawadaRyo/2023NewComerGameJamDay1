using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Attack : MonoBehaviour
{
    public GameObject specialAttackPrefab;//����U��
    public Transform attackPoint; //�a���̔��ˈʒu
    private int specialAttackPrefabCount = 0;
    [SerializeField] GameObject[] gameObjects;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���N���b�N �ʏ�U��
        {
            
        }

        if ((Input.GetMouseButtonDown(1)) && specialAttackPrefabCount < 3)//�E�N���b�N�@����U�� �����������Ɏa��
        {
            Instantiate(specialAttackPrefab, attackPoint.position, attackPoint.rotation);

            gameObjects[specialAttackPrefabCount].SetActive(false);
            specialAttackPrefabCount++;
            
            
        }
        
        
    }
}
