using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("Timer")] float _timer = 30;
    public static int _score;
    [SerializeField, Header("Clearシーン名")] string _clearSeceneName;
    [SerializeField, Header("Overシーン名")] string _overSeceneName;
    [SerializeField]GameState _state = GameState.None;
    public GameState State {get { return _state; } set { _state = value; } }
    public float Timer => _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        _timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (_state == GameState.Game)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0)
        {
            _state = GameState.GameClear;
        }
        
        switch(_state)
        {
            case GameState.GameClear:
                _score = FindObjectOfType<EnemyManager>().DeathCount;
                FindObjectOfType<SceneTranstion>().SwitchScrene(_clearSeceneName);
                break;
            case GameState.GameOver:
                FindObjectOfType<SceneTranstion>().SwitchScrene(_overSeceneName);
                break;
        }
    }

    public enum GameState
    {
        None,
        Game,
        GameClear,
        GameOver,
    }
}
