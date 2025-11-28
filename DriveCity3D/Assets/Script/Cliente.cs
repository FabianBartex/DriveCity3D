using UnityEngine;

public class Cliente : MonoBehaviour
{
    public Animator portaAnim;      // Animator da porta do carro
    public GameObject clienteObj;   // Objeto visual do cliente

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("ClienteTrigger: carro chegou no cliente.");

        // Checagens de segurança
        if (portaAnim == null) Debug.LogWarning("ClienteTrigger: portaAnim não atribuído.");
        if (clienteObj == null) Debug.LogWarning("ClienteTrigger: clienteObj não atribuído.");

        // ✔ Apenas um trigger: animação já abre → espera → fecha
        if (portaAnim != null)
            portaAnim.SetTrigger("Abrir");

        // ✔ Cliente entra no carro (desaparece)
        if (clienteObj != null)
            Destroy(clienteObj, 0.5f);

        // ✔ Atualiza estado da corrida
        var manager = FindObjectOfType<CorridaManagerTeste>();
        if (manager != null)
        {
            manager.estadoAtual = EstadoCorrida.IndoParaDestino;
            Debug.Log("ClienteTrigger: estado → IndoParaDestino.");
        }
        else
        {
            Debug.LogWarning("ClienteTrigger: CorridaManagerTeste não encontrado.");
        }
    }
}

