using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningEffect : MonoBehaviour
{
    [SerializeField, Range(1,255)]  private float _speed = 100f;
    public Color _color;

    void Update()
    {
        Decreasing();
    }

    void OnEnable()
    {
        _color = GetComponent<TextMeshProUGUI>().color;
        _color.a = 1;
        GetComponent<TextMeshProUGUI>().color = _color;
    }
    void Decreasing()
    {
        if(GetComponent<TextMeshProUGUI>().color.a <= 0)
        {
            gameObject.SetActive(false);
            return;
        }
        _color.a -= _speed/255f * Time.deltaTime;
        GetComponent<TextMeshProUGUI>().color = _color;
    }
}
