using UniRx;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEnemyManager
{
    [SerializeField, Header("生成する敵のプレハブ")]
    Enemy _enemy = null;
    [SerializeField, Header("一度に生成する敵の数")]
    Transform[] _generateCount = null;
    [SerializeField,Range(1,10),Header("敵の生成間隔")]
    float _intervalTime = 5;

    [Tooltip("生成間隔調整用のbool配列")]
    bool[] _intervalAdjustment = null;
    [Tooltip("")]
    float _time = 0f;

    float IntervalTime => Random.Range(1, _intervalTime);

    public int DeathCount => throw new System.NotImplementedException();

    void Start()
    {
        _intervalAdjustment = new bool[(int)_intervalTime];
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                GenerateEnemy();
            }).AddTo(this);
    }

    void FirstInstance(Enemy enemy,int count)
    {
        for(int i = 0; i < count; i++)
        {
            var enemyPrefab = Instantiate<Enemy>(enemy);
            enemyPrefab.Instance();
        }
    }

    public void GenerateEnemy()
    {
        _time += Time.deltaTime;
    }

    public void DeathCounter()
    {
        throw new System.NotImplementedException();
    }
}
