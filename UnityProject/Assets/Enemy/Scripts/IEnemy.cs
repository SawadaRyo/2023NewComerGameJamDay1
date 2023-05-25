using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public bool IsActive { get; }

    /// <summary>
    /// �G�l�~�[�̈ړ�
    /// </summary>
    public void Move(float speed, Transform playerTransform);
    /// <summary>
    /// �G�l�~�[�̃W�����v
    /// </summary>
    /// <param name="jumpPower"></param>
    /// <param name="playerTransform"></param>
    public void Jump(float jumpPower, float interval);
    /// <summary>
    /// �G�l�~�[�̃C���X�^���X�����s�֐�
    /// </summary>
    public void Instance(Transform playerTransform);
    /// <summary>
    /// �G�l�~�[�̐��������s�֐�
    /// </summary>
    public void Create(Transform generatePos);
    /// <summary>
    /// �v���C���[�̍U���q�b�g���֐�
    /// </summary>
    public void Hit();
    /// <summary>
    /// �G�l�~�[�̎��S�����s�֐�
    /// </summary>
    public void Death();
}
