using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class soundEffects : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClip;
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
        int index = Random.Range(0, _audioClip.Length - 1);
        
        return _audioClip[index];
    }

}
