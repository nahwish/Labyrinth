using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] zoneMusic; // Array de pistas de música para cada zona en orden.
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zona1"))
        {
            Debug.Log("holaaaaaaaaa");
            PlayMusic(0); // Índice 0 para la música de la Zona1.
        }
        else if (other.CompareTag("Zona2"))
        {
            PlayMusic(1); // Índice 1 para la música de la Zona2.
        }
        // Agrega más comparaciones y cambios de música para cada zona adicional.
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
