using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SwitchScene : MonoBehaviour
{

    public void LaunchScene(int p_sceneIndex)
    {
        SceneManager.LoadSceneAsync(p_sceneIndex);
    }

    private void OnMouseOver()
    {
        Debug.Log(name);
    }
}
