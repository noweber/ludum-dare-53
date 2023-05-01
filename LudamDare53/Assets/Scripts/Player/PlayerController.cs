using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f; // Movement speed
        [SerializeField] private float jumpForce = 10f; // Jump force
        [SerializeField] private float airJumpForce = 5f; // Jump force
        [SerializeField] private float maxSprintMultiplier = 2f; // Maximum speed multiplier when sprinting
        [SerializeField] private float sprintStaminaCost = 1f; // Stamina cost per second while sprinting
        [SerializeField] private float sprintStaminaRecoveryRate = 0.5f; // Stamina recovery rate per second when not sprinting
        [SerializeField] private TextMeshProUGUI staminaText;
        [SerializeField] private AudioSource dashSound;
        [SerializeField] private float groundDashCostFactor = 2f;
        [SerializeField] private float initialDashCostDenominator = 4f;
        [SerializeField] private float airJumpCostDenominator = 2f;
        [SerializeField] private AudioSource landSound;
        [SerializeField] private AudioSource jumpSound;

        private Rigidbody2D rb;
        private float horizontalInput;
        private bool isGrounded;
        private bool isSprinting;
        private float sprintMultiplier = 1f;
        private float sprintStamina = 100f;
        private float sprintMaxStamina = 100f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Handle input
            horizontalInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
            {
                Jump(true);
            }

            // Update sprinting and stamina
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartSprint();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                StopSprint();
            }
            if (isSprinting)
            {
                // Sprinting on the ground costs more stamina than in the air;:
                float adjustedStaminaCost = sprintStaminaCost;
                if (isGrounded)
                {
                    adjustedStaminaCost *= groundDashCostFactor;
                }
                sprintStamina = Mathf.Clamp(sprintStamina - adjustedStaminaCost * Time.deltaTime, 0f, sprintMaxStamina);
                sprintMultiplier = Mathf.Lerp(1f, maxSprintMultiplier, sprintStamina / sprintMaxStamina);
            }
            else
            {
                sprintStamina = Mathf.Clamp(sprintStamina + sprintStaminaRecoveryRate * Time.deltaTime, 0f, sprintMaxStamina);
                sprintMultiplier = 1f;
            }
            UpdateStaminaText();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontalInput * speed * sprintMultiplier, rb.velocity.y);

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the character is grounded
            if (collision.gameObject.CompareTag(Tags.Platform))
            {
                isGrounded = true;
                if (landSound != null)
                {
                    landSound.Play();
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            // Check if the character is no longer grounded
            if (collision.gameObject.CompareTag(Tags.Platform))
            {
                isGrounded = false;
                if (jumpSound != null)
                {
                    jumpSound.Play();
                }
            }
        }

        private void Jump(bool mustSpendStamina = false)
        {
            if (mustSpendStamina && sprintStamina < CostToJumpInAir())
            {
                return;
            }
            else if (mustSpendStamina)
            {
                sprintStamina -= CostToJumpInAir();
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + airJumpForce);
                return;
            }
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
        }

        private float CostToStartSprint()
        {
            return sprintMaxStamina / initialDashCostDenominator;
        }
        private float CostToJumpInAir()
        {
            return sprintMaxStamina / airJumpCostDenominator;
        }

        private void StartSprint()
        {
            if (!isSprinting && sprintStamina >= CostToStartSprint())
            {
                sprintStamina -= CostToStartSprint();
                isSprinting = true;
                if (dashSound != null)
                {
                    dashSound.Play();
                }
            }
        }

        private void StopSprint()
        {
            isSprinting = false;
        }

        private void UpdateStaminaText()
        {
            if (staminaText != null)
            {
                staminaText.text = (Mathf.RoundToInt((sprintStamina / sprintMaxStamina) * 100f) / 10 * 10).ToString() + "%";
            }
        }
    }
}