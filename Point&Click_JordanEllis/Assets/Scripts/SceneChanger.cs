using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int sceneNumber;
    //0 = Start
    //1 = Main
    //2 = End 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (sceneNumber == 0)
      {
        StartSceneControls();
      }

      else if (sceneNumber == 1)
      {
        MainSceneControls();
      }

      else if (sceneNumber == 2)
      {
        EndSceneControls();
      }
    } 

   public void StartSceneControls()
   {
    if (Input.GetKeyDown(KeyCode.Return))
    {
        SceneManager.LoadScene("MainScene");
    }
   }

  public void MainSceneControls()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
        SceneManager.LoadScene("EndScene");
    }
  }

  public void EndSceneControls()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
        SceneManager.LoadScene("StartScene");
    }
  }
}   


