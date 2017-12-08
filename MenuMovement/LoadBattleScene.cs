using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadBattleScene : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("SceneBattle", LoadSceneMode.Single);
        
    }
}
