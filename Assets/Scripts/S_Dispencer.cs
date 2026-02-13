    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class S_Dispencer : MonoBehaviour
    {
        [Header("Timing")]
        [Tooltip("Durée en secondes avant de revenir à la taille originale")]
        public float delaiRetourTailleOriginale = 0.1f;
        
        private HashSet<GameObject> processedMarbles = new HashSet<GameObject>();
        private Vector3 originalScale;
        private Coroutine resetCoroutine;

        void Start()
        {
            originalScale = transform.localScale;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Marble") && !processedMarbles.Contains(other.gameObject))
            {
                processedMarbles.Add(other.gameObject);
                transform.localScale *= 1.05f;
                
                if (resetCoroutine != null)
                    StopCoroutine(resetCoroutine);
                resetCoroutine = StartCoroutine(ResetScaleAfterDelay());
            }
        }

        private IEnumerator ResetScaleAfterDelay()
        {
            yield return new WaitForSeconds(delaiRetourTailleOriginale);
            transform.localScale = originalScale;
        }
    }
