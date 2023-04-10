using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        // Si el tag es el mismo añader municion al arma y destruye el arma.
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            /* 
            Hacedemos a nuestra variable de gunAmmo del
            script GameManager y sumaremos la municion de
            nuestra caja al arma.
            */
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;

            Destroy(other.gameObject);
        }
    }
}
