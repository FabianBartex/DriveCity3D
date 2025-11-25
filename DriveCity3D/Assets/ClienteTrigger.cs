using UnityEngine;

public class ClienteTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Carro chegou no cliente!");

            CorridaManagerTeste manager = FindObjectOfType<CorridaManagerTeste>();
            manager.estadoAtual = EstadoCorrida.IndoParaDestino;

            // Aqui depois vamos colocar:
            // animação abrir porta
            // destruir cliente
        }
    }
}
