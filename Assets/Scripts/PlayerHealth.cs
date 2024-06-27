using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public float health;
    public float maxH;
    public Image healthBar;

    public GameManagement gameManager;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        maxH = health;
    }

    // Update is called once per frame
    void Update()
    {
            healthBar.fillAmount = Mathf.Clamp(health / maxH, 0, 1);

            if(health <= 0 && !isDead) {
                isDead = true;
                gameObject.SetActive(false);
                gameManager.GameOver();
            }

    }


}
