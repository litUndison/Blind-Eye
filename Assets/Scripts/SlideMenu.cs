using UnityEngine;

public class SlideMenu : MonoBehaviour
{
    [SerializeField] private float _speed = 2000f;
    [SerializeField] private GameObject _card;

    private RectTransform _rect;

    private Vector2 _shownPos = Vector2.zero;
    private Vector2 _hiddenPos;

    private bool _isMoving;
    private bool _hideAfterMove;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _hiddenPos = new Vector2(0, Screen.height);
    }

    void OnEnable()
    {
        _rect.anchoredPosition = _hiddenPos;
        MoveTo(_shownPos, false);
    }

    void FixedUpdate()
    {
        if (!_isMoving) return;

        _rect.anchoredPosition = Vector2.MoveTowards(_rect.anchoredPosition, _targetPos, _speed * Time.unscaledDeltaTime);

        if (Vector2.Distance(_rect.anchoredPosition, _targetPos) < 1f)
        {
            _rect.anchoredPosition = _targetPos;
            _isMoving = false;

            if (_hideAfterMove)
            {
                _card.GetComponent<MouseTrigger>()._entersound.Play();
                _card.GetComponent<CardScript>().Lower();
                gameObject.SetActive(false);
            }
        }
    }

    private Vector2 _targetPos;

    void MoveTo(Vector2 target, bool hideAfter)
    {
        _targetPos = target;
        _hideAfterMove = hideAfter;
        _isMoving = true;
    }

    public void Quit()
    {
        MoveTo(_hiddenPos, true);
        GameObject.FindGameObjectWithTag("CardsManager").GetComponent<CardManagement>().UnlockCards();
    }
}
