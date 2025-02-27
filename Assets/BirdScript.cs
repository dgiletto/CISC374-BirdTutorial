using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flapSFX;
    public ParticleSystem deathParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            flapSFX.Play();
        }

        if (transform.position.y > 10 || transform.position.y < -10 ) {
            logic.gameOver();
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        Death();
    }

    // Simple function call which returns if the bird is still alive
    public bool checkIfBirdAlive() {
        return birdIsAlive;
    }

    // Function used to kill bird
    public void Death() {
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(gameObject);
        birdIsAlive = false;
    }
}
