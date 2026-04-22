using TMPro;
using UnityEngine;

public class LogInfo : MonoBehaviour
{
    public string _text;
    public string _question;
    
    public void OpenLogInfo()
    {
        GameObject[] allInactive = FindObjectsOfType<GameObject>(true);
        foreach (GameObject obj in allInactive)
        {
            if (!obj.activeInHierarchy && obj.tag == "LogInfo") 
            {
                obj.SetActive(true);
                obj.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _text;
            }
        }
    }
}
