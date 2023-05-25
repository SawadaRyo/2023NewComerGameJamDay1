using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranstion : MonoBehaviour
{
    // ƒV[ƒ“‘JˆÚ
    public void SwitchScrene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
