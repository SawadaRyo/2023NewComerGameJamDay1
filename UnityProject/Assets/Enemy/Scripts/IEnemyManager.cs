using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyManager
{
    /// <summary>
    /// “G‚ª€–S‚µ‚½‰ñ”
    /// </summary>
    public int DeathCount { get; }
    /// <summary>
    /// “G‚Ì‰Šú¶¬
    /// </summary>
    /// <param name="enemy">¶¬‚·‚é“G</param>
    /// <param name="count">¶¬‚·‚é“G‚Ì”</param>
    void FirstInstance(Enemy enemy, int count);
    /// <summary>
    /// “G‚Ì¶¬ŠÖ”
    /// </summary>
    public void GenerateEnemy();
    /// <summary>
    /// €–S‰ñ”ŒvZ
    /// </summary>
    public void DeathCounter();
}
