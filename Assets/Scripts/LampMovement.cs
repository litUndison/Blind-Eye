using UnityEngine;

public class LampMovement : MonoBehaviour
{
    [SerializeField] private int _dispersion = 10;
    [SerializeField] private float _speed = 2.0f;
    private bool _direction = true;
    private Vector3 _rotation = new Vector3(90, 0, 0);

    void Update()
    {
        switch (_direction)
        {
            case true:
                {
                    if(_rotation.x >= 90 + _dispersion)
                    {
                        _direction = false;
                    }
                    _rotation += new Vector3(_speed * Time.deltaTime, 0, 0);    
                    transform.localEulerAngles = _rotation;
                    break;
                }
            case false:
                {
                    if(_rotation.x <= 90 - _dispersion)
                    {
                        _direction = true;
                    }
                    _rotation -= new Vector3(_speed * Time.deltaTime, 0, 0);    
                    transform.localEulerAngles = _rotation;
                    break;
                }
        }
    }
}
