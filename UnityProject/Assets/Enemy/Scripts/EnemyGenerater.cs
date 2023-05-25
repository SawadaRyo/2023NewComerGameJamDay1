using UniRx;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Range(1,10),Header("“G‚Ì¶¬ŠÔŠu")]
    float _intervalTime = 5;
    [SerializeField,Range(1, 10), Header("ˆê“x‚É¶¬‚·‚é“G‚Ì”")]
    int _generateCount = 5;

    [Tooltip("¶¬ŠÔŠu’²®—p‚Ìbool”z—ñ")]
    bool[] _intervalAdjustment = null;

    float IntervalTime => Random.Range(1, _intervalTime);
    float GenerateCount => Random.Range(1, _generateCount);

    void Start()
    {
        _intervalAdjustment = new bool[(int)_intervalTime];
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                GenerateEnemy();
            }).AddTo(this);
    }

    public void GenerateEnemy()
    {

    }
}
