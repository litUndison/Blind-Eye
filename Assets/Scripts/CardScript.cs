using UnityEngine;

public enum CardState
{
    Idle,
    Raising,
    Lowering,
    FastLowering,
    FlyingAway
}

public class CardScript : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _raiseTarget;
    private Vector3 _flyTarget;

    [SerializeField] private float _raiseDistance = 2f;
    [SerializeField] private float _speed = 5f;
    [SerializeField, Tooltip("Во сколько раз увеличивается скорость при нажатии на карту")] private float _speedMultiplier = 2f;
    [SerializeField] private float _flyDistance = 30f;

    [SerializeField] private GameObject _MenuForOpen;

    private CardState _state = CardState.Idle;

    void Start()
    {
        _startPos = transform.position;
        _raiseTarget = _startPos + (-transform.forward) * _raiseDistance;
        _flyTarget = _startPos + (-transform.forward) * _flyDistance;
    }

    void FixedUpdate()
    {
        switch (_state)
        {
            case CardState.Raising:
                {
                    MoveTo(_raiseTarget, _speed);
                    break;
                }
            case CardState.Lowering:
                {
                    MoveTo(_startPos, _speed);
                    break;
                }   
            case CardState.FastLowering:
                {
                    MoveTo(_startPos, _speed * _speedMultiplier);
                    break;
                }
            case CardState.FlyingAway:
                {
                    MoveTo(_flyTarget, _speed * _speedMultiplier);
                    break;
                }
        }
    }

    void MoveTo(Vector3 target, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            if(_state == CardState.FlyingAway)
            {
                _MenuForOpen.SetActive(true);
            }
            _state = CardState.Idle;
        }
    }

    public void Raise()
    {
        if (_state == CardState.FlyingAway || _state == CardState.FastLowering) return;

        transform.GetChild(0).gameObject.SetActive(true);
        _state = CardState.Raising;
    }

    public void Lower()
    {
        if (_state == CardState.FlyingAway || _state == CardState.FastLowering) return;
        
        transform.GetChild(0).gameObject.SetActive(false);
        if (Vector3.Distance(transform.position, _flyTarget) < 0.01f)
        {
            _state = CardState.FastLowering;
        }
        else
        {
            _state = CardState.Lowering;
        }
    }

    public void FlyAway()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("CardsManager").GetComponent<CardManagement>().LockCards();
        _state = CardState.FlyingAway;
    }
}
