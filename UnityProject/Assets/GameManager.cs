using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("Timer")]float _timer = 30;
    public static int _score;
    
    GameState _state = GameState.Game;
    public GameState State {get { return _state; } set { _state = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _state = GameState.GameClear;
        }
        
        switch(_state)
        {
            case GameState.GameClear:
                //“G“|‚µ”‚ðŽQÆ
                //ƒV[ƒ“‘JˆÚ
                break;
            case GameState.GameOver:
                //ƒV[ƒ“‘JˆÚ
                break;
        }
    }
    public void ScoreReset()
    {
        _score = 0;
    }

    public enum GameState
    {
        Game,
        GameClear,
        GameOver,
    }
}
