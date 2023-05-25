using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    /// <summary>
    /// エネミーの動き
    /// </summary>
    public void Move();
    /// <summary>
    /// エネミーが生成された時
    /// </summary>
    public void Create();
    /// <summary>
    /// エネミーが死んだときの処理
    /// </summary>
    public void Death();
}
