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
    public Transform cliente;
    public Transform destino;

    void Update()
    {
        Debug.Log("Estado atual: " + estadoAtual);
    }

    public void IniciarCorrida()
    {
        estadoAtual = EstadoCorrida.IndoBuscarCliente;
        Debug.Log("Corrida iniciada!");
    }
}

