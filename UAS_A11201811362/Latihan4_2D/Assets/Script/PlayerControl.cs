using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // digunakan untuk meload library ScaneManager.Load(<nama scene>) yang berfungsi untuk mereset
                                   // object player jika object player melebihi tinggi scene atau jatuh ketanah atau menabrak rintangan                                

public class PlayerControl : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2(0,100);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float touchclicked = Input.GetAxis("Fire1");
        if (touchclicked == 1f)
        {
            GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
            GetComponent<Rigidbody2D> ().AddForce(jumpForce);
        }
        Vector2 ScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        
        if (ScreenPosition.y > Screen.height || ScreenPosition.y < 0)
        {
            Die();
        }

        
    }
    
    void Die ()
    {
        Debug.Log ("Game Over !!");
        SceneManager.LoadScene ("Menu");
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        Die();
    }
}
