using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathCountUI : MonoBehaviour
{
    [SerializeField]
    EnemyManager _enemyManager;
    [SerializeField]
    Text _countUI;

    // Start is called before the first frame update
    void Start()
    {
        _enemyManager.DeathCountForUI
            .Subscribe(count =>
            {
                _countUI.text = $"Enemy:{count.ToString("d3")}";
            });
    }
}
