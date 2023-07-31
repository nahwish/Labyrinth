using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] zoneMusic;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zona1"))
        {
            PlayMusic(0);
        }
        else if (other.CompareTag("ExitCollider"))
        {
            PlayMusic(1);
        }
        else if (other.CompareTag("Zona2"))
        {
            PlayMusic(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zona1"))
        {
            audioSource.Stop();
        }
        if (other.CompareTag("ExitCollider"))
        {
            audioSource.Stop();
        }
    }

    private void PlayMusic(int index)
    {
        if (index >= 0 && index < zoneMusic.Length)
        {
            audioSource.clip = zoneMusic[index];
            audioSource.Play();
        }
    }
}
