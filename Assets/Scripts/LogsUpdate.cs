using TMPro;
using UnityEngine;

public class LogsUpdate : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _textPrefab;

    void Start()
    {
        LoadAllLogs();
    }   

    void LoadAllLogs()
    {
        foreach(var log in Parameters._logs)
        {
            GameObject textObj = Instantiate(_textPrefab, _content);
            textObj.GetComponent<LogInfo>()._text = log.Value; 
            textObj.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = log.Key; 
            textObj.GetComponent<LogInfo>()._question = log.Key; 
        }
        
    }

}
