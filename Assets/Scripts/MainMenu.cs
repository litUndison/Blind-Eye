using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] SlideMenus;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameObject.FindGameObjectWithTag("LogInfo"))
        {
            foreach(var menu in SlideMenus)
            {
                if(menu.activeInHierarchy)
                {
                    menu.GetComponent<SlideMenu>().Quit();
                }
            }
        }
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
