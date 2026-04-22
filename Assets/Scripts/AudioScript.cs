using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField, Tooltip("Заполнить ТОЛЬКО ОДНО ПОЛЕ, иначе оно будет менять на разные громкости")] private AudioSource sound = null;
    [SerializeField, Tooltip("Заполнить ТОЛЬКО ОДНО ПОЛЕ, иначе оно будет менять на разные громкости")] private AudioSource music = null;
    void Update()
    {
        if(sound != null)
        {
            sound.volume = Parameters._soundVolume;
        }
        if(music != null)
        {
            music.volume = Parameters._musicVolume;
        }
    }
}
