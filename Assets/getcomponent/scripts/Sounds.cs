using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip Clip;
    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;

    // [HideInInspector]
    public AudioSource source;


















}