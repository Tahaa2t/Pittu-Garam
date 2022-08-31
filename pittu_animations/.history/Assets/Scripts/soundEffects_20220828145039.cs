using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class soundEffects : MonoBehaviour
{
    [SerializeField] AudioClip[] _stepsAudio;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }
    // animation event
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        _audioSource.PlayOneShot(clip);

    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, _stepsAudio.Length - 1);
        
        return _stepsAudio[index];
    }

}
