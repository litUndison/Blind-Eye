using UnityEngine;
using UnityEngine.InputSystem;

public class EscScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
