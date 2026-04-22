using UnityEngine;

public class CursorClick : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetBool("IsClicked",true);
        }
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Click"))
        {
            _animator.SetBool("IsClicked",false);
        }
    }
}
