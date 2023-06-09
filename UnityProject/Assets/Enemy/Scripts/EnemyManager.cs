using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEnemyManager
{
    [SerializeField, Header("生成する敵のプレハブ")]
    Enemy[] _enemy = null;
    [SerializeField, Header("追跡するプレイヤー")]
    Transform _playerTransform = null;
    [SerializeField, Header("生成する敵の座標")]
    Transform[] _generatePos = null;
    [SerializeField, Range(0.1f, 10), Header("敵の生成間隔")]
    float _intervalTime = 5;
    [SerializeField, Range(1, 100), Header("敵の初期生成")]
    int _enemyCount = 0;


    [Tooltip("")]
    bool _generateEnabled = false;
    [Tooltip("生成間隔調整用のbool配列")]
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
                Debug.Log($"{i}:{j}");
                enemyPrefab.Instance(this, _playerTransform);
                _enemyList[i].Add(enemyPrefab);
            }
        }
    }

    public async void GenerateEnemy()
    {
        var enemy = _enemyList[UnityEngine.Random.Range(0, _enemyList.Length - 1)];
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
