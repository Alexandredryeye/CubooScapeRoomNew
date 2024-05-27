using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    // Refer�ncia ao Animator
    public Animator animator;
    public FadeScreen FadeScreen;
    public int sceneIndex;

    // M�todo chamado quando outro objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player" (ou qualquer outra tag que voc� desejar)
        if (other.CompareTag("Player"))
        {
            
            // Ativa o booleano no Animator
            animator.SetBool("open", true);
            StartCoroutine(GoToSceneRoutine(sceneIndex));

        }
    }

    // M�todo chamado quando outro objeto sai do trigger
    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player" (ou qualquer outra tag que voc� desejar)
        if (other.CompareTag("Player"))
        {
            // Desativa o booleano no Animator
            animator.SetBool("open", false);
        }
    }
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        FadeScreen.FadeOut();
        yield return new WaitForSeconds(FadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
