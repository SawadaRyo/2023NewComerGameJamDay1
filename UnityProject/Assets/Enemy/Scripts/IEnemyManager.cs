using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyManager
{
    /// <summary>
    /// �G�����S������
    /// </summary>
    public int DeathCount { get; }
    /// <summary>
    /// �G�̐����֐�
    /// </summary>
    public void GenerateEnemy();
    public void DeathCounter();
}
