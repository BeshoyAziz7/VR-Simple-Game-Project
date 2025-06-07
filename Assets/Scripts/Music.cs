using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource[] musicTracks; // Assign your Audio Sources in the Inspector
    private int currentTrack = 0;

    void Start()
    {
        PlayNextTrack();
    }

    public void PlayNextTrack()
    {
        // Stop the current track if it's playing
        if (musicTracks[currentTrack].isPlaying)
        {
            musicTracks[currentTrack].Stop();
        }

        // Move to the next track, looping back to the beginning
        currentTrack = (currentTrack + 1) % musicTracks.Length;

        // Play the next track
        musicTracks[currentTrack].Play();
    }
}