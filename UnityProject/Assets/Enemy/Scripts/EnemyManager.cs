using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEnemyManager
{
    [SerializeField, Header("��������G�̃v���n�u")]
    Enemy _enemy = null;
    [SerializeField,Header("�ǐՂ���v���C���[")]
    Transform _playerTransform = null;
    [SerializeField, Header("��������G�̍��W")]
    Transform[] _generatePos = null;
    [SerializeField,Range(3,10),Header("�G�̐����Ԋu")]
    float _intervalTime = 5;
    [SerializeField, Range(1, 100), Header("�G�̏�������")]
    int _enemyCount = 0;


    [Tooltip("")]
    bool _generateEnabled = false;
    [Tooltip("�����Ԋu�����p��bool�z��")]
    bool[] _intervalAdjustment = null;
    [Tooltip("")]
    int _deathCount = 0;
    [Tooltip("")]
    List<IEnemy> _enemyList = new List<IEnemy>();

    float IntervalTime => UnityEngine.Random.Range(3f, _intervalTime);

    public int DeathCount => _deathCount;

    void Start()
    {
        FirstInstance(_enemy, _enemyCount);
        _intervalAdjustment = new bool[(int)_intervalTime];
        _generateEnabled = true;
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                GenerateEnemy();
            }).AddTo(this);
    }

    public void FirstInstance(Enemy enemy,int count)
    {
        for(int i = 0; i < count; i++)
        {
            var enemyPrefab = Instantiate<Enemy>(enemy);
            enemyPrefab.Instance(_playerTransform);
            _enemyList.Add(enemyPrefab);
        }
    }

    public async void GenerateEnemy()
    {
        foreach(var enemy in _enemyList)
        {
            if (enemy.IsActive || !_generateEnabled) continue;
            else if(!enemy.IsActive && _generateEnabled)
            {
                enemy.Create(_generatePos[UnityEngine.Random.Range(0, _generatePos.Length)]);
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
        _deathCount++;
    }
}
