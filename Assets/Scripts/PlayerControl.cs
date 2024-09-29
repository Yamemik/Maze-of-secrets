using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedRun;
    [SerializeField] float jump;
    [SerializeField] AudioClip[] audioMove;

    AudioSource playerAudio;
    CharacterController player;

    float xMove;
    float zMove;
    float speedCurrent;
    Vector3 moveDirection;
    float gravity = 0.1f;
    int audioCurrent = 0;
    Vector3 OldPosition;

    private void Start()
    {
        player = GetComponent<CharacterController>();

        playerAudio = GetComponent<AudioSource>();

        Vector3 OldPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");

        if (player.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0f, zMove);
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y += jump;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                player.height = 1.4f;
            }
            else
            {
                player.height = 1.8f;
            }
        }

        moveDirection.y -= gravity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedCurrent = speedRun;
            audioCurrent = 1;
        }
        else
        {
            speedCurrent = speed;
            audioCurrent = 0;
        }

        player.Move(moveDirection * speedCurrent * Time.deltaTime);

        //if (OldPosition != transform.position)
        //{
        //    playerAudio.PlayOneShot(audioMove[audioCurrent]);
        //    OldPosition = transform.position;
        //}
    }
}
