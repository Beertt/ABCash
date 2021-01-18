using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCenas : MonoBehaviour {
    public static GerenciadorDeCenas instancia;

    public float tempoTransicao = 1;

    private void Awake() {
        if (instancia == null) {
            instancia = this;
        }
        else if (instancia != this) {
            Destroy(gameObject);
        }
    }

    //Finalizar e carregar próxima cena
    public void FinalizarCena() {
        StartCoroutine(CarregarCena());
    }

    public int GetCenaNumero() {
        return SceneManager.GetActiveScene().buildIndex;
    }

    // Carregar próxima cena
    IEnumerator CarregarCena() {
        yield return new WaitForSeconds(tempoTransicao);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
