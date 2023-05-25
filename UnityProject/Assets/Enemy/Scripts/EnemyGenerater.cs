using UniRx;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Range(1,10),Header("敵の生成間隔")]
    float _intervalTime = 5;
    [SerializeField,Range(1, 10), Header("一度に生成する敵の数")]
    int _generateCount = 5;

    [Tooltip("生成間隔調整用のbool配列")]
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
