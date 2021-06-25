using UnityEngine;


namespace Pacman
{
    internal sealed class Pacdot : MonoBehaviour
    {
        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.PlayerTag))
            {
                ScoreManager.Score++;
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
