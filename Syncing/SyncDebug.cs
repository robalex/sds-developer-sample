using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            if (items == null) {
                throw new ArgumentNullException(nameof(items));
            }

            var bag = new ConcurrentBag<string>();

            if (!items.Any()) {
                return bag.ToList();
            }

            var tasks = items.Select(i => Task.Run(() => bag.Add(i)));
            Task.WhenAll(tasks).GetAwaiter().GetResult();

            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            if (getItem == null) {
                throw new ArgumentNullException(nameof(getItem));
            }

            var itemsToInitialize = Enumerable.Range(0, 100).ToList();
            var chunkSize = (itemsToInitialize.Count / 3) +1;
            var itemChunks = itemsToInitialize.Chunk(chunkSize).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = itemChunks
                .Select(chunk => new Thread(() => {
                    foreach (var item in chunk)
                    {
                        concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                    }
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}