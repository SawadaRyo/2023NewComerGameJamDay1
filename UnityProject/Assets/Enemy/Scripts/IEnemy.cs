using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public bool IsActive { get; }

    /// <summary>
    /// エネミーの移動
    /// </summary>
    public void Move(float speed, Transform playerTransform);
    /// <summary>
    /// エネミーのジャンプ
    /// </summary>
    /// <param name="jumpPower"></param>
    /// <param name="playerTransform"></param>
    public void Jump(float jumpPower, float interval);
    /// <summary>
    /// エネミーのインスタンス時実行関数
    /// </summary>
    public void Instance(Transform playerTransform);
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
