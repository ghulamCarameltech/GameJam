using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  	[SerializeField]
	private AudioClip []_musicClip;
	private static Dictionary<string, AudioClip> Musics;

	[SerializeField]
	private AudioClip []_audioClip;
	private static Dictionary<string, AudioClip> Sounds;


	private static AudioSource _musicSource;
    private static AudioSource _audioSource;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Musics = new Dictionary<string, AudioClip> ();
		foreach (AudioClip music in _musicClip) 
		{
			Musics.Add (music.name, music);
		}

		Sounds = new Dictionary<string, AudioClip> ();
		foreach (AudioClip sound in _audioClip) 
		{
			Sounds.Add (sound.name, sound);
		}

		_musicSource = GetComponents<AudioSource>()[0];
		_audioSource = GetComponents<AudioSource>()[1];
	}

	void Start()
	{
		float musicVolume = PlayerPrefsManager.GetMusicVolume();
		float soundVolume = PlayerPrefsManager.GetSoundVolume();
		SetMusicVolume(musicVolume);
		SetSoundVolume(soundVolume);
	}

	public static void PlaySound(string name)
	{
		// _audioSource.Stop();

		if(!Sounds.ContainsKey(name))
		{
			return;
		}

		_audioSource.PlayOneShot(Sounds[name]);		
	}

	public static float SoundLength(string name)
	{
		if(!Sounds.ContainsKey(name))
		{
			return 0;
		}

		return Sounds[name].length;
	}

	public static void PlayMusic(string name)
	{
		_musicSource.Stop();

		if(!Musics.ContainsKey(name))
		{
			return;
		}

		_musicSource.clip = Musics[name];
		_musicSource.Play();
	}

	public static void SetMusicVolume(float value)
	{
		_musicSource.volume = value;
		PlayerPrefsManager.SetMusicVolume(value);
	}

	public static void SetSoundVolume(float value)
	{
		_audioSource.volume = value;
		PlayerPrefsManager.SetSoundVolume(value);
	}
}
