using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyManager
{
    /// <summary>
    /// 敵が死亡した回数
    /// </summary>
    public int DeathCount { get; }
    /// <summary>
    /// 敵の初期生成
    /// </summary>
    /// <param name="enemy">生成する敵</param>
    /// <param name="count">生成する敵の数</param>
    void FirstInstance(Enemy enemy, int count);
    /// <summary>
    /// 敵の生成関数
    /// </summary>
    public void GenerateEnemy();
    /// <summary>
    /// 死亡回数計算
    /// </summary>
    public void DeathCounter();
}
