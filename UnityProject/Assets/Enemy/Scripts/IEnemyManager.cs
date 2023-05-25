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
    /// “G‚Ì¶¬ŠÖ”
    /// </summary>
    public void GenerateEnemy();
    public void DeathCounter();
}
