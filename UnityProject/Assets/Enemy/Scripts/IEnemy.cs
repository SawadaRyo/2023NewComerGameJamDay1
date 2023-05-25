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
    /// エネミーのインスタンス時実行関数
    /// </summary>
    public void Instance();
    /// <summary>
    /// エネミーの生成時実行関数
    /// </summary>
    public void Create(Transform generatePos);
    /// <summary>
    /// プレイヤーの攻撃ヒット時関数
    /// </summary>
    public void Hit();
    /// <summary>
    /// エネミーの死亡時実行関数
    /// </summary>
    public void Death();
}
