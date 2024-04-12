using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAtaque : MonoBehaviour
{
    //Ataques
    [SerializeField] PlayerVida vida;
    [SerializeField] GameObject ataqueFisico, pivotAtaqueFisico;
    [SerializeField] GameObject ataqueMagico, pivotAtaqueMagia;

    [SerializeField] Image imageMagia;
    [SerializeField] float quantiMagia;

    [SerializeField] public bool podeAtacar = true;
    [SerializeField] public float cooldownAtaqueFisico = 0.1f, cooldownAtaqueMagico = 1.2f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && podeAtacar)
        {
            AtaqueFisico();
        }

        if (Input.GetMouseButtonDown(1) && podeAtacar)
        {
            AtaqueMagico();
        }
    }
    void AtaqueFisico()
    {
        podeAtacar = false;
        Instantiate(ataqueFisico, pivotAtaqueFisico.transform.position, transform.rotation);
        StartCoroutine(cdAtaqueFisico());
    }

    IEnumerator cdAtaqueFisico()
    {
        yield return new WaitForSeconds(cooldownAtaqueFisico);
        podeAtacar = true;
    }

    void AtaqueMagico()
    {
        Instantiate(ataqueMagico, pivotAtaqueFisico.transform.position, transform.rotation);
        StartCoroutine(cdAtaqueMagico());

    }

    IEnumerator cdAtaqueMagico()
    {
        podeAtacar = false;
        yield return new WaitForSeconds(cooldownAtaqueMagico);
        podeAtacar = true;
    }
}
