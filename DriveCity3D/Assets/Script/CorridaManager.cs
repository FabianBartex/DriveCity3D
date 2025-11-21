using UnityEngine;

public enum EstadoCorrida
{
    EsperandoChamada,
    IndoParaCliente,
    EmbarcandoCliente,
    IndoParaDestino,
    FinalizandoCorrida
}

public class CorridaManager : MonoBehaviour
{
    public static CorridaManager instance; // fácil acesso

    public EstadoCorrida estadoAtual = EstadoCorrida.EsperandoChamada;

    public Transform pontoCliente;
    public Transform pontoDestino;

    private void Awake()
    {
        instance = this;
    }

    public void IniciarCorrida(Transform cliente, Transform destino)
    {
        pontoCliente = cliente;
        pontoDestino = destino;

        estadoAtual = EstadoCorrida.IndoParaCliente;

        // aqui chamamos o script do carro
        CarroController carro = FindObjectOfType<CarroController>();
        carro.IrPara(pontoCliente.position);
    }

    public void ClienteAlcançado()
    {
        estadoAtual = EstadoCorrida.EmbarcandoCliente;
    }

    public void ClienteEmbarcado()
    {
        estadoAtual = EstadoCorrida.IndoParaDestino;

        CarroController carro = FindObjectOfType<CarroController>();
        carro.IrPara(pontoDestino.position);
    }

    public void DestinoAlcançado()
    {
        estadoAtual = EstadoCorrida.FinalizandoCorrida;
    }

    public void CorridaTerminada()
    {
        estadoAtual = EstadoCorrida.EsperandoChamada;
    }
}