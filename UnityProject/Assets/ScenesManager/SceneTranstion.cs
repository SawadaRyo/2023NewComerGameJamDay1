using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranstion : MonoBehaviour
{
    // �V�[���J��
    public void SwitchScrene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
