using UnityEngine;

public class Destino : MonoBehaviour
{
    public Animator portaAnim;
    public GameObject clientePrefab;    // prefab do cliente para spawn após chegada
    public Transform spawnPontoCliente; // ponto onde o cliente vai aparecer (fora do carro)
    public float abrirDelay = 0f;       // delay antes de abrir a porta (opcional)

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("DestinoTrigger: carro chegou no destino.");

        if (portaAnim == null) Debug.LogWarning("DestinoTrigger: portaAnim não atribuído.");
        if (clientePrefab == null) Debug.LogWarning("DestinoTrigger: clientePrefab não atribuído.");
        if (spawnPontoCliente == null) Debug.LogWarning("DestinoTrigger: spawnPontoCliente não atribuído.");

        // Abrir porta (pode usar delay se precisar)
        if (portaAnim != null)
            Invoke(nameof(AbrirPorta), abrirDelay);

        // Spawn do cliente (apenas se prefab + spawn existirem)
        if (clientePrefab != null && spawnPontoCliente != null)
        {
            Instantiate(clientePrefab, spawnPontoCliente.position, spawnPontoCliente.rotation);
            Debug.Log("DestinoTrigger: cliente spawnado no destino.");
        }

        // Fechar porta após 1 segundo
        if (portaAnim != null) Invoke(nameof(FecharPorta), 1f);

        // Atualiza estado no manager
        var manager = FindObjectOfType<CorridaManagerTeste>();
        if (manager != null)
        {
            manager.estadoAtual = EstadoCorrida.Finalizada;
            Debug.Log("DestinoTrigger: estado trocado para Finalizada.");
        }
    }

    void AbrirPorta()
    {
        if (portaAnim != null) portaAnim.SetTrigger("Abrir");
    }

    void FecharPorta()
    {
        if (portaAnim != null) portaAnim.SetTrigger("Fechar");
    }
}
