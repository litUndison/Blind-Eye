using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            Cursor.visible = true;
        }
    }
}
