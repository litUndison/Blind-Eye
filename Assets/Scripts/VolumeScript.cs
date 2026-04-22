using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    void Start()
    {   
        if(gameObject.name == "MusicSlider")
        {
            gameObject.GetComponent<Slider>().value = Parameters._musicVolume;
        }
        else if(gameObject.name == "SoundSlider")
        {
            gameObject.GetComponent<Slider>().value = Parameters._soundVolume;
        } 
    }
    public void SetMusicVolume()
    {
        Parameters.SetMusicVolume(gameObject.GetComponent<Slider>().value);
    }
    public void SetSoundVolume()
    {
        Parameters.SetSoundVolume(gameObject.GetComponent<Slider>().value);
    }
}
