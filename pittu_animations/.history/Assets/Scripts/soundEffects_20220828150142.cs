using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class soundEffects : MonoBehaviour
{
    public static soundEffects _bgMusic;
    [SerializeField] AudioClip[] _stepsAudio;
    AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_bgMusic == null) // If the MusicControlScript instance variable is null
        {
            _bgMusic = this; // Set this object as the instance
        }
        else // If there is already a MusicControlScript instance active
        {
            Destroy(gameObject); // Destroy this gameObject
        }


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
