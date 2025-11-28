using UnityEngine;

public class Destino : MonoBehaviour
{
    public Animator portaAnim;
    public GameObject clientePrefab;
    public Transform spawnPontoCliente;
    public float abrirDelay = 0f;
    public float destruirClienteDepois = 3f; // cliente desaparece sozinho depois de alguns segundos

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Destino: carro chegou ao destino.");

        if (portaAnim != null)
            Invoke(nameof(AbrirPorta), abrirDelay);

        // Spawn do cliente
        if (clientePrefab != null && spawnPontoCliente != null)
        {
            GameObject cli = Instantiate(clientePrefab, spawnPontoCliente.position, spawnPontoCliente.rotation);
            Destroy(cli, destruirClienteDepois);
        }

        // Mudança de estado
        var manager = FindObjectOfType<CorridaManagerTeste>();
        if (manager != null)
            manager.estadoAtual = EstadoCorrida.Finalizada;
    }

    void AbrirPorta()
    {
        if (portaAnim != null)
            portaAnim.SetTrigger("Abrir");
    }
}