using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public enum AudioKind
{
    Master,
    BGM,
    SE
}
public class AudioVolumeSlider : MonoBehaviour
{
    [SerializeField] InputProvider inputProvider;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioKind audioKind;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        AdaptSliderValue();
    }
    private void Update()
    {
        if (audioKind == AudioKind.Master)
        {
            float db;
            mixer.GetFloat("Master", out db);
        }
        
    }
    // Update is called once per frame

    private void AdaptSliderValue()
    {
        float db;
        switch (audioKind)
        {
            case (AudioKind.Master):
                mixer.GetFloat("Master", out db);
                slider.value = ConvertDbToVolume(db);
                break;
            case (AudioKind.BGM):
                mixer.GetFloat("BGM", out db);
                slider.value = ConvertDbToVolume(db);
                break;
            case (AudioKind.SE):
                mixer.GetFloat("SE", out db);
                slider.value = ConvertDbToVolume(db);
                break;
        }
    }
    public void StartSlideMove()
    {
        StopAllCoroutines();
        StartCoroutine(SliderVolumeChange());
    }
    public void StopSlideMove()
    {
        StopAllCoroutines();
    }
    IEnumerator SliderVolumeChange()
    {
        while (true)
        {
            if (inputProvider.IsRightButton()) slider.value-=0.01f;
            if (inputProvider.IsLeftButton()) slider.value+=0.01f;
            yield return null;
        }
        
    }

    public void SetAudioValue()
    {
        float audioVolume = ConvertVolume2dB(slider.value);
        switch (audioKind)
        {
            case (AudioKind.Master):
                mixer.SetFloat("Master", audioVolume);
                break; 
            case (AudioKind.BGM):
                mixer.SetFloat("BGM", audioVolume);
                break;
            case (AudioKind.SE):
                mixer.SetFloat("SE", audioVolume);
                break;
        }
    }
    float ConvertVolume2dB(float volume)
    {
        return Mathf.Clamp(20f * Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)), -80f, 0f); 
    }
    float ConvertDbToVolume(float db)
    { 
        return  Mathf.Clamp(Mathf.Pow(10,db/20f),0f,1f);
    }

}
