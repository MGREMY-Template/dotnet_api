namespace Domain.Mapper;

using System.Collections.Generic;
using System.Linq;

public class SignalRConnectionMapping<T>
{
    private readonly Dictionary<T, HashSet<string>> _connections = new();

    public int Count
    {
        get
        {
            return this._connections.Count;
        }
    }

    public void Add(T key, string connectionId)
    {
        lock (this._connections)
        {
            if (!this._connections.TryGetValue(key, out HashSet<string> connections))
            {
                connections = new HashSet<string>();
                this._connections.Add(key, connections);
            }

            lock (connections)
            {
                _ = connections.Add(connectionId);
            }
        }
    }

    public IEnumerable<string> GetConnections(T key)
    {
        return this._connections.TryGetValue(key, out HashSet<string> connections)
            ? connections
            : Enumerable.Empty<string>();
    }

    public void Remove(T key, string connectionId)
    {
        lock (this._connections)
        {
            if (!this._connections.TryGetValue(key, out HashSet<string> connections))
            {
                return;
            }

            lock (connections)
            {
                _ = connections.Remove(connectionId);

                if (!connections.Any())
                {
                    _ = this._connections.Remove(key);
                }
            }
        }
    }
}
