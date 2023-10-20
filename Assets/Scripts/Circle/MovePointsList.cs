using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Circle
{
    public class MovePointsList
    {
        private List<Vector3> _movePositions = new List<Vector3>();

        public bool HasMovePoints
        {
            get
            {
                if (_movePositions.Count > 0) return true;
                else return false;
            }
        }

        public Vector3 CurrentMovePosition
        {
            get
            {
                if (_movePositions.Count > 0) return _movePositions[0];
                else return Vector3.zero;
            }
        }

        public void AddMovePosition(Vector3 pos)
        {
            _movePositions.Add(pos);
        }

        public void ClearFirstPoint()
        {
            _movePositions.RemoveAt(0);
        }

        public void ClearMovePosition(Vector3 pos)
        {
            _movePositions.Remove(pos);
        }
    }
}