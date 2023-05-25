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
    /// 敵の生成関数
    /// </summary>
    public void GenerateEnemy();
    public void DeathCounter();
}
