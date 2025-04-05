using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillingFloor : MonoBehaviour
{
    [SerializeField] private Animator _deathFloorAnimation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //TODO : Play death floor animation
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
