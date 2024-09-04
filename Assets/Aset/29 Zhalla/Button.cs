using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Canvas Maincanvas;
    public Canvas Settingcanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mulai(){
        SceneManager.LoadScene("level1");
    }

    public void Setting(){
        Maincanvas.gameObject.SetActive(false);
        Settingcanvas.gameObject.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }
}
