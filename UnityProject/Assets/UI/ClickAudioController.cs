using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAudioController : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _playseconds;
    [SerializeField, Header("éüëJà⁄Ç∑ÇÈÉVÅ[Éìñº")] string _nextSceneName;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void ClickAudioPlay()
    {
        StartCoroutine(Play());
    }
    IEnumerator Play()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_playseconds);
        FindObjectOfType<SceneTranstion>().SwitchScrene(_nextSceneName);
    }
}
