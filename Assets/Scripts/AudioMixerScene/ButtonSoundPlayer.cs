using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _firstClip;
    [SerializeField] private AudioClip _secondClip;
    [SerializeField] private AudioClip _thirdClip;
    [SerializeField] private float _volume;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayFirstSound()
    {
        Play(_firstClip);
    }

    public void PlaySecondSound()
    {
        Play(_secondClip);
    }

    public void PlayThirdSound()
    {
        Play(_thirdClip);
    }

    private void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip, _volume);
    }
}
