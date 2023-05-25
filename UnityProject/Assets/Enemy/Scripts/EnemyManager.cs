using UniRx;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEnemyManager
{
    [SerializeField, Header("¶¬‚·‚é“G‚ÌƒvƒŒƒnƒu")]
    Enemy _enemy = null;
    [SerializeField, Header("ˆê“x‚É¶¬‚·‚é“G‚Ì”")]
    Transform[] _generateCount = null;
    [SerializeField,Range(1,10),Header("“G‚Ì¶¬ŠÔŠu")]
    float _intervalTime = 5;

    [Tooltip("¶¬ŠÔŠu’²®—p‚Ìbool”z—ñ")]
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
