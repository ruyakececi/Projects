using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class HostCollection<Host>
    {
        public int Length
        {
            get { return _length; }
            private set { _length = value; }
        }
        private Host[] _innerCollection;
        private int _length;
        public HostCollection()
        {
            _innerCollection = new Host[0];
            Length = 0;
        }

        public Host this[int index]//indexer
        {
            get { return _innerCollection[index]; }
            set
            {
                if (index < 0 && index >= _innerCollection.Length)
                {
                    _innerCollection[index] = value;
                }
            }
        }
        public void Add(Host Host)
        {
            if (!Contains(Host))
            {
                Array.Resize<Host>(ref _innerCollection, _innerCollection.Length + 1);
                _innerCollection[_innerCollection.Length - 1] = Host;
                Length++;
            }
        }
        public Host GetHostAt(int index)
        {
            return _innerCollection[index];
        }
        public void RemoveAt(int index)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (index >= i && _innerCollection.Length!=1)
                {
                    _innerCollection[i] = _innerCollection[i + 1];
                }
            }
            Array.Resize<Host>(ref _innerCollection, _innerCollection.Length - 1);
            Length--;
        }
        public int IndexOf(Host Host)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (_innerCollection[i].Equals(Host))
                    return i;
            }
            return -1;
        }
        public void Remove(Host Host)
        {
            RemoveAt(IndexOf(Host));
        }
        public bool Contains(Host Host)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (_innerCollection[i].Equals(Host))
                    return true;
            }
            return false;
        }
        public void Insert(Host Host, int index)
        {
            Array.Resize<Host>(ref _innerCollection, _innerCollection.Length + 1);
            for (int i = index; i < _innerCollection.Length; i++)
            {
                if (index > i)
                {
                    _innerCollection[i + 1] = _innerCollection[i];
                }
                _innerCollection[index] = Host;
            }
            Length++;
        }
    }
}

