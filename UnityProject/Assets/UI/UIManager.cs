using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _score;
    [SerializeField] Text _timer;
    GameManager _gameManager;
    IEnemyManager _ienemyManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer != null)
        {
            _timer.text = $"{_gameManager.Timer.ToString("F2")}";
        }
        if (_score != null)
        {
            _score.text = $"{GameManager._score}";
        }
    }
}
