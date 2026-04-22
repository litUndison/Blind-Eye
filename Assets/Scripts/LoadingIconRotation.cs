using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class LoadingIconRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private GameObject _aiWorker;
    void Start()
    {
        _aiWorker = GameObject.Find("AIWorker");
    }
    void Update()
    {
        if(string.IsNullOrEmpty(_aiWorker.GetComponent<UnityAndGeminiV3>().AIanswer))
            transform.Rotate(0,0,-_rotationSpeed * Time.deltaTime);
    }
}
