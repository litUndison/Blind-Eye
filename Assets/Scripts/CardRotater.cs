using System;
using UnityEngine;

public class CardRotater : MonoBehaviour
{
    [SerializeField] private float _rotationspeed;
    [SerializeField] private float _movementspeed;
    private Vector3 _rotation = new Vector3(0.0f, 0.0f, 180.0f);
    private float _rotationstage = 0.0f;

    void Update()
    {
        if(_rotation.z > 0.0f)
        {
            _rotationstage += _rotationspeed * Time.deltaTime / 10.0f;
            _rotationstage = Math.Clamp(_rotationstage, 0.0f, 1.0f);
            transform.localEulerAngles = Vector3.Lerp(_rotation, new Vector3(0.0f, 0.0f, 0.0f), _rotationstage);
        }
        if(transform.rotation.z == 0.0f)
        {
            float maxytranslation = _movementspeed * Time.deltaTime;
            float accesibleytranslation = transform.position.y - GetComponent<CardInfo>().StartAltitude;
            if(maxytranslation > accesibleytranslation)
            {
                maxytranslation = accesibleytranslation;
            }
            if(maxytranslation > 0)
            {
                transform.Translate(0.0f, -maxytranslation, 0.0f);
            }       
        }
        if(transform.position.y == GetComponent<CardInfo>().StartAltitude)
        {
            Destroy(GetComponent<CardRotater>());
        }
    }
}
