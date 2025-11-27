using UnityEngine;

public class AddCollidersCidadeMontada : MonoBehaviour
{
    public bool aplicarEmRuas = true;
    public bool aplicarEmPredios = true;

    public float tamanhoMinimo = 1.2f; // ignora peças pequenas
    public string[] ignorarPorNome = new string[]
    {
        "tree", "arvore", "poste", "post", "lamp", "light",
        "cone", "sign", "placa", "bush", "folha", "grass"
    };

    void Start()
    {
        int adicionados = 0;
        MeshFilter[] meshes = FindObjectsOfType<MeshFilter>();

        foreach (MeshFilter mf in meshes)
        {
            GameObject obj = mf.gameObject;

            // Já tem collider → ignora
            if (obj.GetComponent<Collider>() != null)
                continue;

            string nome = obj.name.ToLower();

            // Ignorar por nome
            foreach (string s in ignorarPorNome)
                if (nome.Contains(s))
                    goto PULAR;

            // Tamanho mínimo
            Vector3 size = obj.GetComponent<MeshRenderer>().bounds.size;
            if (size.x < tamanhoMinimo && size.z < tamanhoMinimo)
                goto PULAR;

            // Detectar ruas
            bool eRua =
                nome.Contains("road") ||
                nome.Contains("street") ||
                nome.Contains("asphalt") ||
                nome.Contains("sidewalk") ||
                nome.Contains("pavement");

            if (eRua)
            {
                if (aplicarEmRuas)
                {
                    BoxCollider bc = obj.AddComponent<BoxCollider>();
                    bc.center = new Vector3(0, -0.05f, 0);
                    bc.size = new Vector3(bc.size.x, 0.1f, bc.size.z);
                    adicionados++;
                }
                continue;
            }

            // Prédios
            if (aplicarEmPredios)
            {
                obj.AddComponent<BoxCollider>();
                adicionados++;
            }

        PULAR:;
        }

        Debug.Log("Colliders adicionados: " + adicionados);
    }
}


