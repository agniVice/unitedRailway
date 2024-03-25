using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    private float _delay;
    public void SetDelay(float delay = 0)
    {
        _delay = delay;
    }
    public void LoadMission(int _index)
    {
        IEnumerator load = LoadScene(_index, _delay);
        StartCoroutine(load);
    }
    private IEnumerator LoadScene(int id, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(id);
    }
}
