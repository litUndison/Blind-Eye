using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Menu");
    }
}
