using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flapSFX;

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
            Destroy(gameObject);
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        Destroy(gameObject);
        birdIsAlive = false;
    }

    // Simple function call which returns if the bird is still alive
    public bool checkIfBirdAlive() {
        return birdIsAlive;
    }
}
