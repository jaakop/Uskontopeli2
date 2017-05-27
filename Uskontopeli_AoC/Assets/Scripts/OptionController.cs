using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

    public Slider sensivitySlider;
    public Text sensivityText;
    public Slider sfxSlider;
    public Text sfxText;
    public Slider musicSlider;
    public Text musicText;
    public Slider renderSlider;
    public Text renderText;

    enum OptionType
    {
        MouseSensitivity, 
        SFXVolume, 
        MusicVolume,
        RenderDistance
    }

    public void Start()
    {
        sensivitySlider.onValueChanged.AddListener(delegate { ChangeValue(sensivityText, sensivitySlider, OptionType.MouseSensitivity); });
        sfxSlider.onValueChanged.AddListener(delegate { ChangeValue(sfxText, sfxSlider, OptionType.SFXVolume); });
        musicSlider.onValueChanged.AddListener(delegate { ChangeValue(musicText, musicSlider, OptionType.MusicVolume); });
        renderSlider.onValueChanged.AddListener(delegate { ChangeValue(renderText, renderSlider, OptionType.RenderDistance); });
    }

    void ChangeValue(Text _text, Slider _slider, OptionType _type)
    {
        _text.text = _slider.value.ToString();
        switch (_type)
        {
            case OptionType.MouseSensitivity:
                PlayerController.lookSensivity = _slider.value;
                break;
            case OptionType.SFXVolume:
                break;
            case OptionType.MusicVolume:
                break;
            case OptionType.RenderDistance:
                RenderManager.ChangeRenderDistance((int)_slider.value);
                break;
        }
    }
    

}
