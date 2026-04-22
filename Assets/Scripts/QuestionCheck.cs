using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionCheck : MonoBehaviour
{
    [SerializeField] private GameObject _inputField;
    [SerializeField] private GameObject _warningMessage;
    void Start()
    {
        
    }

    public void StartAsking()
    {
        if(!string.IsNullOrEmpty(_inputField.GetComponent<TMP_InputField>().text))
        {
            Parameters.SetQuestion(_inputField.GetComponent<TMP_InputField>().text);
            SceneManager.LoadScene("BlindEye");
        }
        else
        {
            if(!_warningMessage.activeInHierarchy)
            {
                _warningMessage.SetActive(true);
            }
            else
            {
                _warningMessage.GetComponent<WarningEffect>()._color.a = 1;
            }
        }
    }
}
