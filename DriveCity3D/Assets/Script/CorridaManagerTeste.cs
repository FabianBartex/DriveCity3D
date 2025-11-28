using UnityEngine;

public enum EstadoCorrida
{
    Nenhuma,
    IndoBuscarCliente,
    IndoParaDestino,
    Finalizada
}

public class CorridaManagerTeste : MonoBehaviour
{
    public EstadoCorrida estadoAtual = EstadoCorrida.Nenhuma;

    private EstadoCorrida ultimoEstado;

    void Start()
    {
        ultimoEstado = estadoAtual;
        Debug.Log("Estado inicial: " + estadoAtual);
    }

    void Update()
    {
        // Loga SOMENTE quando o estado muda
        if (estadoAtual != ultimoEstado)
        {
            Debug.Log("Estado atual: " + estadoAtual);
            ultimoEstado = estadoAtual;
        }
    }
}