using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")] 
    [SerializeField] AudioSource audioSource;

    [Header("AudioClip Clip")]
    public AudioClip winMusic;

    public void Start()
    {
        audioSource.clip = winMusic;
        audioSource.Play();
    }
}
