using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteTrigger : MonoBehaviour
{
    public Animator portaAnim;      // arraste o Animator da porta do carro
    public GameObject clienteObj;   // o objeto visual do cliente (ou o próprio GameObject)

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("ClienteTrigger: carro chegou no cliente.");

        // Checa se existem referências
        if (portaAnim == null) Debug.LogWarning("ClienteTrigger: portaAnim não atribuído no Inspector.");
        if (clienteObj == null) Debug.LogWarning("ClienteTrigger: clienteObj não atribuído no Inspector.");

        // Abrir porta
        if (portaAnim != null) portaAnim.SetTrigger("Abrir");

        // Destruir o cliente (simula entrar no carro) após 0.5s
        if (clienteObj != null) Destroy(clienteObj, 0.5f);

        // Fechar porta após atraso (ajusta tempo conforme sua animação)
        if (portaAnim != null) Invoke(nameof(FecharPorta), 1f);

        // Avança estado no manager
        var manager = FindObjectOfType<CorridaManagerTeste>();
        if (manager != null)
        {
            manager.estadoAtual = EstadoCorrida.IndoParaDestino;
            Debug.Log("ClienteTrigger: estado trocado para IndoParaDestino.");
        }
        else
        {
            Debug.LogWarning("ClienteTrigger: CorridaManagerTeste não encontrado na cena.");
        }
    }

    void FecharPorta()
    {
        if (portaAnim != null) portaAnim.SetTrigger("Fechar");
    }
}
