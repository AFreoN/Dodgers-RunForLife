using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class FinishDemo : MonoBehaviour {


    private void OnEnable()
    {
        MutantSP.mutantSP = false;
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(4.1f);
        SceneManager.LoadScene(1);
    }
}
