using UnityEngine;


namespace Pacman
{
    internal sealed class GhostMove : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform[] _wayPoints;
        [SerializeField] private float _speed = 0.3f;

        private Animator _animation;
        private Rigidbody2D _rigidBody;
        private int _trackingTheWaypointToWhichTheBlinksGo = 0;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animation = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MoveTheGhost();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.PlayerTag))
            {
                Destroy(collision.gameObject);
            }
        }

        #endregion


        #region Methods

        private void MoveTheGhost()
        {
            if (transform.position !=
                _wayPoints[_trackingTheWaypointToWhichTheBlinksGo].position)
            {
                Vector2 position = Vector2.MoveTowards(transform.position,
                    _wayPoints[_trackingTheWaypointToWhichTheBlinksGo].position, _speed);
                _rigidBody.MovePosition(position);
            }
            else
            {
                _trackingTheWaypointToWhichTheBlinksGo =
                    (_trackingTheWaypointToWhichTheBlinksGo + 1) % _wayPoints.Length;
            }
            Vector2 direction = _wayPoints[_trackingTheWaypointToWhichTheBlinksGo].position
                - transform.position;
            _animation.SetFloat(Constants.DirectionX, direction.x);
            _animation.SetFloat(Constants.DirectionY, direction.y);
        }

        #endregion
    }
}