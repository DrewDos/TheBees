using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Forms.Verification
{
    public class VerifyManual : VerifyHandler
    {
        private Dictionary<string, bool> verifKeys = new Dictionary<string, bool>();

        public override bool Pending
        {
            get
            {
                return base.Pending;
            }
            set
            {
                if(!value)
                    verifKeys.ToList().ForEach((kvp) => verifKeys[kvp.Key] = value );

                base.Pending = value;
            }
        }


        public VerifyManual()
            : base()
        {
        }

        public VerifyManual(params string[] keys)
            : base()
        {
            Array.ForEach(keys, (x) => verifKeys[x] = false );
        }
        public bool GetKey(string key)
        {
            if (!verifKeys.ContainsKey(key))
                throw new ArgumentException("Key does not exist");

            return verifKeys[key];
        }

        public void SetKey(string key, bool setTo)
        {
            verifKeys[key] = setTo;
            UpdatePending();
        }

        private void UpdatePending()
        {
            pending = verifKeys.ContainsValue(true);
        }
    }
}
