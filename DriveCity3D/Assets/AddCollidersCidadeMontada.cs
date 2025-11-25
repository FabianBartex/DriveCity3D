using UnityEngine;

public class AddCollidersCidadeMontada : MonoBehaviour
{
    public bool forcarBoxNasRuas = true;

    void Start()
    {
        int adicionados = 0;

        MeshFilter[] meshes = FindObjectsOfType<MeshFilter>();

        foreach (var mf in meshes)
        {
            // Se já tem collider → ignora
            if (mf.GetComponent<Collider>() != null)
                continue;

            string nome = mf.name.ToLower();

            // DETECTA RUAS / ASFALTO / CALÇADAS
            bool eRua = nome.Contains("road") ||
                        nome.Contains("asphalt") ||
                        nome.Contains("street") ||
                        nome.Contains("pavement") ||
                        nome.Contains("sidewalk");

            // RUAS → usa BoxCollider
            if (eRua && forcarBoxNasRuas)
            {
                mf.gameObject.AddComponent<BoxCollider>();
                adicionados++;
                continue;
            }

            // Objetos normais → BoxCollider (leve)
            // Se quiser MeshCollider nos prédios, avise
            mf.gameObject.AddComponent<BoxCollider>();
            adicionados++;
        }

        Debug.Log("Colliders adicionados: " + adicionados);
    }
}

