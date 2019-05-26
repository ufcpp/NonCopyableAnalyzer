using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Struct)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct Collection<T> : IEnumerable<T>
{
    public struct Enumerator : IEnumerator<T>
    {
        private T[] _data;
        private int _index;
        public T Current { get { return _data[_index]; } }
        public Enumerator(T[] data) { _data = data; _index = -1; }
        public bool MoveNext() => (++_index >= _data.Length);
    }

    private T[] _data;
    public Collection(T[] data) => _data = data;
    public Enumerator GetEnumerator() => new Enumerator(_data);
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
    IEnumerable IEnumerable.GetEnumerator() => GetEnumerator();
}

class Program
{
    static void Consume<T>(T i) {}
    
    static void Main()
    {
        var collection = new Collection<int>( new int[] {1, 2, 3} );
        var e = collection.GetEnumerator();
        while(e.MoveNext()) Consume(e.Current);
        foreach(var i in collection) Consume(i);
        foreach(var i in (Collection<int>)collection) Consume(i); // ❌        
        foreach(var i in (IEnumerable<int>)collection) Consume(i); // ❌        
    }
}