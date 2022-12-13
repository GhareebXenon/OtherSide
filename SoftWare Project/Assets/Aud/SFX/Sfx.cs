using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Aud;

namespace Aud.SFX
{
    public class Sfx : MonoBehaviour
    {
        public SoundCollection[] soundFX;
        public Rigidbody2D RigidBody2D;
        float horizontal;
        public void PlayJumpAudio(InputAction.CallbackContext context)
        {
            if (context.performed)
                soundFX[0].audioCollection[0].audioSource.Play();
        }

        public void PlayMoveAudio(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;
            if (horizontal < 0.00f)
                soundFX[1].audioCollection[0].audioSource.Play();
            else if (horizontal > 0.00f)
                soundFX[1].audioCollection[0].audioSource.Play();
            else
            {
                if (soundFX[1].audioCollection[0].audioSource.isPlaying && RigidBody2D.velocity.x < 0.001f)
                    soundFX[1].audioCollection[0].audioSource.Stop();
                else
                    soundFX[1].audioCollection[0].audioSource.Stop();
            }
        }
        void OnCollisionEnter2D(Collision2D groundCollision)
        {
            if (groundCollision.relativeVelocity.magnitude > 1)
            {
                if (!soundFX[2].audioCollection[0].audioSource.isPlaying)
                    soundFX[2].audioCollection[0].audioSource.Play();
            }
        }
    }
}
