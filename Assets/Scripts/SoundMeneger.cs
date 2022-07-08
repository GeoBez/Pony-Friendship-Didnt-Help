using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundMeneger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public static SoundMeneger Instance { get; private set; }
    private Dictionary<Sounds, AudioClip> keyValueClip = new();
    void Start()
    {
        Instance = this;
        audioSource = GetComponentInParent<AudioSource>();

        foreach(Sounds sound in Enum.GetValues(typeof(Sounds)))
        {
            AudioClip clip = Resources.Load<AudioClip>($"Sounds\\{sound}");
            if(clip == null)
            { Debug.LogWarning($"Was not found Sound:{sound} in Resources"); continue; }
            keyValueClip.Add(sound, clip);
        }
        Debug.Log($"Load Sound Successful: {keyValueClip.Count()}/{Enum.GetValues(typeof(Sounds)).Length}");
    }
    public static void Play(Sounds sounds)
    {
        Instance.audioSource.PlayOneShot(Instance.keyValueClip[sounds]);
    }
    
    public enum Sounds
    {
        Loot,
        UseUpgrade
    }
}
