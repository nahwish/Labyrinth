using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] zoneMusic; // Array de pistas de música para cada zona en orden.
    private AudioSource audioSource;

    private void Start()
    {
        // Asegurarse de que el personaje tenga un AudioSource (agregarlo si no existe).
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
            PlayMusic(0); // Índice 0 para la música de la Zona1.
        }
        else if (other.CompareTag("ExitCollider"))
        {
            PlayMusic(1); // Índice 1 para la música de la Zona2.
        }
        // Agrega más comparaciones y cambios de música para cada zona adicional.
    }
private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Zona1")){
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
