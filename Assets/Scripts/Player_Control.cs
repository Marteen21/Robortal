using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

namespace UnityStandardAssets._2D {
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Player_Control : NetworkBehaviour {
        [SyncVar(hook = "OnPlayerJumpSynced")]
        private bool syncPlayerJump;
        [SyncVar(hook = "OnPlayerHorizontalSynced")]
        private float syncPlayerHorizontal;
        [SyncVar(hook = "OnPlayerCrouchSynced")]
        private bool syncPlayerCrouch;
        private PlatformerCharacter2D m_Character;
        private Animator m_Anim;
        private bool m_Jump;
        private bool lastJump;
        private bool lastCrouch;
        private float lastHorizontal;


        private void Awake() {
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_Anim = GetComponent<Animator>();
        }


        private void Update() {
            if (isLocalPlayer) {
                GetJump();
            }
            else {
                SetAnimations();
            }
        }


        private void FixedUpdate() {
            if (isLocalPlayer) {
                GetHorizontalAndJump();
            }
        }
        private void GetJump() {
            if (!m_Jump) {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }
        private void GetHorizontalAndJump() {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.S);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
            if (CheckForChanges(crouch, m_Jump, h)) {
                lastCrouch = crouch;
                lastJump = m_Jump;
                lastHorizontal = h;
                CmdProvideAnimationsToServer(crouch, m_Jump, h);
            }
        }
        private bool CheckForChanges(bool crch, bool jmp, float hrzntl) {
            if (crch != lastCrouch || jmp != lastJump || hrzntl != lastHorizontal) {
                return true;
            }
            else {
                return false;
            }
        }
        void SetAnimations() {
            m_Anim.SetBool("Crouch", syncPlayerCrouch);
            m_Anim.SetBool("Ground", !syncPlayerJump);
            m_Anim.SetFloat("Speed", Mathf.Abs(syncPlayerHorizontal));
        }
        [Command]
        void CmdProvideAnimationsToServer(bool playerCrouch, bool playerJump, float playerHorizontal) {
            syncPlayerCrouch = playerCrouch;
            syncPlayerJump = playerJump;
            syncPlayerHorizontal = playerHorizontal;            
        }
        [ClientCallback]
        void OnPlayerJumpSynced(bool jmp) {
            syncPlayerJump = jmp;
        }
        [ClientCallback]
        void OnPlayerCrouchSynced(bool crch) {
            syncPlayerCrouch = crch;
        }
        [ClientCallback]
        void OnPlayerHorizontalSynced(float hrzntl) {
            syncPlayerHorizontal = hrzntl;
        }
    }
}
