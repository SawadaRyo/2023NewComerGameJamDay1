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
    /// �G�l�~�[���������ꂽ��
    /// </summary>
    public void Create();
    /// <summary>
    /// �G�l�~�[�����񂾂Ƃ��̏���
    /// </summary>
    public void Death();
}
