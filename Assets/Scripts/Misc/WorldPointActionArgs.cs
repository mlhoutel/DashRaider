using System.Collections;
using System.Collections.Generic;

using UnityEngine;


    public class WorldPointActionArgs
    {
    //A mettre dans le dossier Scripts

        private Vector3 position;
        private RaycastHit hitInfo;

        public Vector3 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public RaycastHit HitInfo
        {
            get
            {
                return hitInfo;
            }

            set
            {
                hitInfo = value;
            }
        }

        public void Set(RaycastHit hitInfo)
        {
            this.Position = hitInfo.point;
            this.HitInfo = hitInfo;
        }

        public WorldPointActionArgs(RaycastHit hitInfo)
        {
            this.Position = hitInfo.point;
            this.HitInfo = hitInfo;
        }

        public WorldPointActionArgs()
        { }

    }
