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
    /// �G�̏�������
    /// </summary>
    /// <param name="enemy">��������G</param>
    /// <param name="count">��������G�̐�</param>
    void FirstInstance(Enemy enemy, int count);
    /// <summary>
    /// �G�̐����֐�
    /// </summary>
    public void GenerateEnemy();
    /// <summary>
    /// ���S�񐔌v�Z
    /// </summary>
    public void DeathCounter();
}
