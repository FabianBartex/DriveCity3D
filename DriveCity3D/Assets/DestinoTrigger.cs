using UnityEngine;

public class DestinoTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chegou no destino!");

            CorridaManagerTeste manager = FindObjectOfType<CorridaManagerTeste>();
            manager.estadoAtual = EstadoCorrida.Finalizada;

            // Depois colocaremos aqui:
            // animação de abrir porta
            // spawn do cliente
            // finalizar corrida corretamente
        }
    }
}

