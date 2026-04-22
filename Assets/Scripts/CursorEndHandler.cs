using UnityEngine;

public class CursorEndHandler : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject _endpoint;
    [SerializeField] private float _movespeed;
    private float time;
    void OnEnable()
    {
        Destroy(GetComponent<CursorClick>());
        Destroy(GetComponent<CursorMovement>());
        time = Time.time;
    }

    void Update()
    {
        if(gameObject.transform.position != _endpoint.transform.position)
        {
            Vector3 movevector = _endpoint.transform.position - gameObject.transform.position;
            transform.Translate(movevector * _movespeed * Time.deltaTime);
        }
        if(Time.time - time >= 2)
        {
            Canvas.GetComponent<LoadingScript>().Enable();
            Destroy(GetComponent<CursorEndHandler>());
        }
    }
}
