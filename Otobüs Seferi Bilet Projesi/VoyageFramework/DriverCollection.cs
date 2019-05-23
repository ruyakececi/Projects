using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class DriverCollection<Driver>
    {
        public int Length
        {
            get { return _length; }
            private set { _length = value; }
        }
        private Driver[] _innerCollection;
        private int _length;
        public DriverCollection()
        {
            _innerCollection = new Driver[0];
            Length = 0;
        }

        public Driver this[int index]//indexer
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
        public void Add(Driver driver)
        {
            if (!Contains(driver))
            {
                Array.Resize<Driver>(ref _innerCollection, _innerCollection.Length + 1);
                _innerCollection[_innerCollection.Length - 1] = driver;
                Length++;
            }
        }
        public Driver GetDriverAt(int index)
        {
            return _innerCollection[index];
        }
        public void RemoveAt(int index)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (index >= i)
                {
                    _innerCollection[i] = _innerCollection[i + 1];
                }
            }
            Array.Resize<Driver>(ref _innerCollection, _innerCollection.Length - 1);
            Length--;
        }
        public int IndexOf(Driver driver)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (_innerCollection[i].Equals(driver))
                    return i;
            }
            return -1;
        }
        public void Remove(Driver driver)
        {
            RemoveAt(IndexOf(driver));
        }
        public bool Contains(Driver driver)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (_innerCollection[i].Equals(driver))
                    return true;
            }
            return false;
        }
        public void Insert(Driver driver,int index)
        {
            Array.Resize<Driver>(ref _innerCollection, _innerCollection.Length + 1);
            for (int i = index; i < _innerCollection.Length; i++)
            {
                if(index > i)
                {
                    _innerCollection[i+1] = _innerCollection[i];
                }
                _innerCollection[index] = driver;
            }
            Length++;
        }
    }
}
