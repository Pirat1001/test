using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class TankController : MonoBehaviour
{
    public float turningSpeed = 5;
    public float speed = 5;

    private float angle;
    private Rigidbody2D rb2d;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public HealthBar healthBar;
    public TMP_Text gameOver;
    public GameObject playAgain;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
        gameOver.enabled = false;
        playAgain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        angle -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        rb2d.MoveRotation(angle);

        float y = Input.GetAxis("Vertical");
        rb2d.velocity = rb2d.transform.up * y * speed;

        if (healthBar.Death(currentHealth))
        {
            PlayerDead();
        }
    }
    public void DamageTaken(float damage)
    {
        currentHealth -= damage;
        healthBar.SetSlider(currentHealth);
    }

    public void PlayerDead()
    {
        Time.timeScale = 0;
        gameOver.enabled = true;
        playAgain.SetActive(true);
        StartCoroutine(LoadMenu("Menu"));
    }
    IEnumerator LoadMenu(string delay)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(delay);
    }
}
