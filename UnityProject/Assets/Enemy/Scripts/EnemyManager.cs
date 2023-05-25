using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEnemyManager
{
    [SerializeField, Header("¶¬‚·‚é“G‚ÌƒvƒŒƒnƒu")]
    Enemy[] _enemy = null;
    [SerializeField, Header("’ÇÕ‚·‚éƒvƒŒƒCƒ„[")]
    Transform _playerTransform = null;
    [SerializeField, Header("¶¬‚·‚é“G‚ÌÀ•W")]
    Transform[] _generatePos = null;
    [SerializeField, Range(3, 10), Header("“G‚Ì¶¬ŠÔŠu")]
    float _intervalTime = 5;
    [SerializeField, Range(1, 100), Header("“G‚Ì‰Šú¶¬")]
    int _enemyCount = 0;


    [Tooltip("")]
    bool _generateEnabled = false;
    [Tooltip("¶¬ŠÔŠu’²®—p‚Ìbool”z—ñ")]
    bool[] _intervalAdjustment = null;
    [Tooltip("")]
    IntReactiveProperty _deathCount = new();
    [Tooltip("")]
    List<IEnemy>[] _enemyList = new List<IEnemy>[3];

    float IntervalTime => UnityEngine.Random.Range(3f, _intervalTime);

    public IReadOnlyReactiveProperty<int> DeathCountForUI => _deathCount;
    public int DeathCount => _deathCount.Value;

    void Start()
    {
        foreach (var enemy in _enemy)
        {
            FirstInstance(enemy, _enemyCount);
        }
        _intervalAdjustment = new bool[(int)_intervalTime];
        _generateEnabled = true;
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                GenerateEnemy();
            }).AddTo(this);
    }

    public void FirstInstance(Enemy enemy, int count)
    {
        for (int i = 0; i < _enemyList.Length; i++)
        {
            _enemyList[i] = new();
            for (int j = 0; j < count; j++)
            {
                var enemyPrefab = Instantiate<Enemy>(enemy);
                enemyPrefab.Instance(this, _playerTransform);
                _enemyList[i].Add(enemyPrefab);
            }
        }
    }

    public async void GenerateEnemy()
    {
        var enemy = _enemyList[UnityEngine.Random.Range(0, _enemyList.Length)];
        foreach (var e in enemy)
        {
            if (e.IsActive || !_generateEnabled) continue;
            else if (!e.IsActive && _generateEnabled)
            {
                e.Create(_generatePos[UnityEngine.Random.Range(0, _generatePos.Length)]);
                float time = IntervalTime;
                _generateEnabled = false;
                await UniTask.Delay(TimeSpan.FromSeconds(time));
                _generateEnabled = true;
                break;
            }
        }
    }

    public void DeathCounter()
    {
        _deathCount.Value++;
    }
    public void OnDisable()
    {
        _deathCount.Dispose();
    }
}
