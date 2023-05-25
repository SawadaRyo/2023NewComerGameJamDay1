using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXController : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField, Header("çUåÇâπ")] AudioClip _attack;
    [SerializeField, Header("ì¡éÍçUåÇâπ")] AudioClip _specialattack;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void AttackAudio()
    {
        _audioSource.PlayOneShot(_attack);
    }

    public void SpecialAttackAudio()
    {
        _audioSource.PlayOneShot(_specialattack);
    }
}
