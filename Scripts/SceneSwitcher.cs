using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(scene.name == "StartScene")
            {
                SceneManager.LoadScene("GameScene");
            }else if(scene.name == "YouFail" || scene.name == "YouWin")
            {
                SceneManager.LoadScene("StartScene");
            }
        }
    }
}
