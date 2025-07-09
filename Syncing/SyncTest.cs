using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DeveloperSample.Syncing
{
    public class SyncTest
    {
        [Fact]
        public void CanInitializeCollection()
        {
            var debug = new SyncDebug();
            var items = new List<string> { "one", "two" };
            var result = debug.InitializeList(items);
            Assert.Equal(items.Count, result.Count);
        }

        [Fact]
        public void CanInitializeEmptyCollection()
        {
            var debug = new SyncDebug();
            var items = new List<string>();
            var result = debug.InitializeList(items);
            Assert.Empty(result);
        }

        [Fact]
        public void InitializeListItemsCannotBeNull()
        {
            var debug = new SyncDebug();
            Assert.Throws<ArgumentNullException>(() => debug.InitializeList(null));
        }

        [Fact]
        public void ItemsOnlyInitializeOnce()
        {
            var debug = new SyncDebug();
            var count = 0;
            var dictionary = debug.InitializeDictionary(i =>
            {
                Thread.Sleep(1);
                Interlocked.Increment(ref count);
                return i.ToString();
            });

            Assert.Equal(100, count);
            Assert.Equal(100, dictionary.Count);
        }

        [Fact]
        public void InitializeDictionaryGetItemCannotBeNull()
        {
            var debug = new SyncDebug();
            Assert.Throws<ArgumentNullException>(() => debug.InitializeDictionary(null));
        }
    }
}
