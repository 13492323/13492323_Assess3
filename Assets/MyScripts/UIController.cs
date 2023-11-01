using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
   public void ChangeScene(string name)
   {
      SceneManager.LoadScene(name);
   }

   public void Exit()
   {
      Application.Quit();
   }
   public void ReloadScene()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
   }
}
