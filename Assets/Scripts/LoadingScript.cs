using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum Connect
{
    connecting,
    error,
    connected,
    idle
}
public class LoadingScript : MonoBehaviour
{
    [SerializeField] GameObject _loadingScreen;
    [SerializeField] GameObject _loadingIcon;
    [SerializeField] TextMeshProUGUI _loadingText;
    [SerializeField] private float _rotationSpeed;
    private GameObject _aiWorker;
    [SerializeField] private GameObject _answerText;
    [SerializeField] private GameObject _button;
    public Connect _state = Connect.idle;
    private bool _enabled = false;
    
    void Start()
    {
        _state = Connect.idle;
        _aiWorker = GameObject.Find("AIWorker");
    }

    void Update()
    {
        switch(_state)
        {
            case Connect.connected:
                {
                    ConnectDone();
                    break;
                }
            case Connect.connecting:
                {
                    rotateLoadingICon();
                    break;
                }
            case Connect.error:
                {
                    ConnectWrong();
                    break;
                }
        }
    }
    public void Enable()
    {
        //_enabled = true;
        Cursor.visible = true;
        _loadingScreen.SetActive(true);
        //_loadingIcon.SetActive(true);
        //_loadingText.enabled = true;
    }
    void rotateLoadingICon()
    {
        _loadingIcon.transform.Rotate(0,0,-_rotationSpeed * Time.deltaTime);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void ConnectDone()
    {
        _state = Connect.connected;
        _loadingIcon.SetActive(false);
        _loadingText.text = "Связь установлена, ответ получен!";
        _answerText.SetActive(true);
        _button.SetActive(true);
        Cursor.visible = true;
        _answerText.GetComponent<TextMeshProUGUI>().text = _aiWorker.GetComponent<UnityAndGeminiV3>().AIanswer;
    }
    public void ConnectWrong()
    {
        _loadingIcon.SetActive(false);
        _loadingText.GetComponent<TextMeshProUGUI>().text = "Гадалка спилась, повторите попытку позже!";
        _button.SetActive(true);
    }
}
