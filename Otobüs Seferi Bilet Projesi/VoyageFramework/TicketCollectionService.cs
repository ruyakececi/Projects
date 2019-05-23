using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class TicketCollection<Ticket>
    {
        public int Length
        {
            get { return _length; }
            private set { _length = value; }
        }
        private Ticket[] _innerCollection;
        private int _length;
        public TicketCollection()
        {
            _innerCollection = new Ticket[0];
            Length = 0;
        }

        public Ticket this[int index]//indexer
        {
            get { return _innerCollection[index]; }
            private set
            {
                if (index < 0 && index >= _innerCollection.Length)
                {
                    _innerCollection[index] = value;
                }
            }
        }
        public void Add(Ticket Ticket)
        {
            if (!Contains(Ticket))
            {
                Array.Resize<Ticket>(ref _innerCollection, _innerCollection.Length + 1);
                _innerCollection[_innerCollection.Length - 1] = Ticket;
                Length++;
            }
        }
        public Ticket GetTicketAt(int index)
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
            Array.Resize<Ticket>(ref _innerCollection, _innerCollection.Length - 1);
            Length--;
        }
        public int IndexOf(Ticket Ticket)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (_innerCollection[i].Equals(Ticket))
                    return i;
            }
            return -1;
        }
        public void Remove(Ticket Ticket)
        {
            RemoveAt(IndexOf(Ticket));
        }
        public bool Contains(Ticket Ticket)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                if (_innerCollection[i].Equals(Ticket))
                    return true;
            }
            return false;
        }
        public void Insert(Ticket Ticket, int index)
        {
            Array.Resize<Ticket>(ref _innerCollection, _innerCollection.Length + 1);
            for (int i = index; i < _innerCollection.Length; i++)
            {
                if (index > i)
                {
                    _innerCollection[i + 1] = _innerCollection[i];
                }
                _innerCollection[index] = Ticket;
            }
            Length++;
        }
    }
}

