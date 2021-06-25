using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pacman
{
    internal class Pacman : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _speed = 0.4f;

        private Vector2 _destination = Vector2.zero;
        private Collider2D _collider;
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        #endregion


        #region UnityNethods

        private void Start()
        {
            _destination = transform.position;
            _collider = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            MoveToDestination();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag(Constants.GhostTag))
            {
                SceneManager.LoadScene(Constants.GameScene);
            }
        }

        #endregion


        #region Methods

        private bool IsValid(Vector2 direction)
        {
            Vector2 position = transform.position;
            RaycastHit2D raycastHit = Physics2D.Linecast(position + direction, position);
            return raycastHit.collider == _collider;
        }

        private void MoveToDestination()
        {
            Vector2 position = Vector2.MoveTowards(transform.position, _destination,
                _speed);
            _rigidbody.MovePosition(position);
            CheckForUserInput();
        }

        private void CheckForUserInput()
        {
            if ((Vector2)transform.position == _destination)
            {
                if (Input.GetKey(KeyCode.UpArrow) && IsValid(Vector2.up))
                {
                    _destination = (Vector2)transform.position + Vector2.up;
                }
                if (Input.GetKey(KeyCode.RightArrow) && IsValid(Vector2.right))
                {
                    _destination = (Vector2)transform.position + Vector2.right;
                }
                if (Input.GetKey(KeyCode.LeftArrow) && IsValid(-Vector2.right))
                {
                    _destination = (Vector2)transform.position - Vector2.right;
                }
                if (Input.GetKey(KeyCode.DownArrow) && IsValid(-Vector2.up))
                {
                    _destination = (Vector2)transform.position - Vector2.up;
                }
            }

            Vector2 direction = _destination - (Vector2)transform.position;
            _animator.SetFloat(Constants.DirectionX, direction.x);
            _animator.SetFloat(Constants.DirectionY, direction.y);
        }

        #endregion
    }
}
