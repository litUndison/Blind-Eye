using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _tablelayer;
    [SerializeField] private float _movementspeed;
    private Vector3 _lastmouseposition;

    void Start()
    {
        Cursor.visible = false;
        _lastmouseposition = transform.position;
    }

    void Update()
    {
        Ray cursorray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit tablehit;
        if(Physics.Raycast(cursorray, out tablehit, 1000.0f, _tablelayer))
        {
            _lastmouseposition = tablehit.point;
        }
        if(gameObject.transform.position != _lastmouseposition)
        {
            Vector3 movevector = _lastmouseposition - gameObject.transform.position;
            transform.Translate(movevector * _movementspeed * Time.deltaTime);
        }
    }
}
