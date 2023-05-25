using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    /// <summary>
    /// �G�l�~�[�̓���
    /// </summary>
    public void Move();
    /// <summary>
    /// �G�l�~�[�̃C���X�^���X�����s�֐�
    /// </summary>
    public void Instance();
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
