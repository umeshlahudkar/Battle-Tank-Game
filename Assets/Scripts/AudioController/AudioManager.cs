using System;
using UnityEngine;

public class AudioManager : GenericMonoSingleton<AudioManager>
{
    [SerializeField] AudioSource SFXAudioSource;
    [SerializeField] AudioSource backgroundAudioSource;

    [SerializeField] Sound[] sounds;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        PlayBackgroundMusic(SoundType.BackGround);
    }

    public void MuteAudio()
    {
        backgroundAudioSource.mute = true;
        SFXAudioSource.mute = true;
    }

    public void UnMuteAudio()
    {
        backgroundAudioSource.mute = false;
        SFXAudioSource.mute = false;
    }
    public void PlayBackgroundMusic(SoundType soundType)
    {
        AudioClip clip = GetAudioClip(soundType);
        if(clip != null)
        {
            backgroundAudioSource.clip = clip;
            backgroundAudioSource.Play();
        }
    }

    public void PlaySFXAudio(SoundType soundType)
    {
        AudioClip clip = GetAudioClip(soundType);
        if(clip != null)
        {
            SFXAudioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetAudioClip(SoundType _soundType)
    {
        Sound sound = Array.Find(sounds, item => item.soundType == _soundType);
        if(sound != null)
        {
            return sound.clip;
        }
        return null;
    }

    [Serializable]
    public class Sound
    {
        public SoundType soundType;
        public AudioClip clip;
    }
    
}

public enum SoundType
{
    None,
    BackGround,
    TankExplosion,
    BulletExplosion,
    BulletFire,
    ObjectDestroy,
    ButtonClik
}
