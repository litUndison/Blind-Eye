using UnityEngine;

public class CardInfo : MonoBehaviour
{
    public string _cardname;
    private float _startaltitude;
    public float StartAltitude
    {
        get { return _startaltitude;}
    }

    void Start()
    {
        _startaltitude = transform.position.y;
    }
}
