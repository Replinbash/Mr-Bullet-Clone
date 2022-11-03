using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Slider _volumeSlider;
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>(); 
    private void Start() => LoadAudioVolume();
	
    public void PlayAudio(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio, AudioListener.volume);    
    }

    public void SetAudioVolume(float value)
    {
		AudioListener.volume = value;
        SaveAudioVolume();
    }

    private void SaveAudioVolume()
    {
        PlayerPrefs.SetFloat("AudioVolume", AudioListener.volume);
    }

    private void LoadAudioVolume()
    {
        if (PlayerPrefs.HasKey("AudioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
            _volumeSlider.value = PlayerPrefs.GetFloat("AudioVolume");
		}

        else
        {
            PlayerPrefs.SetFloat("AudioVolume", .5f);
			AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
			_volumeSlider.value = PlayerPrefs.GetFloat("AudioVolume");
		}
    }
}
