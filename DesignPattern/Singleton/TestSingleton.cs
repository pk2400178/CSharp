using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Singleton
{
    public class TestSingleton
    {
        [Fact]
        public void TestCreateSingletonLazy()
        {
            SingletonLazy s1 = SingletonLazy.Instance;
            SingletonLazy s2 = SingletonLazy.Instance;

            Assert.Same(s1, s2);
        }
        [Fact]
        public void TestThreadSingletonLazy()
        {
            var s1 = Task.Run(() => GetLazyInstance());
            var s2 = Task.Run(() => GetLazyInstance());

            Assert.Same(s1.Result, s2.Result);

            s1.Result.test = 1;
            s2.Result.test = 2;

            Assert.Equal(s1.Result.test, s2.Result.test);
        }

        [Fact]
        public void TestThreadSingletonEager()
        {
            var s1 = Task.Run(() => GetEagerInstance());
            var s2 = Task.Run(() => GetEagerInstance());

            Assert.Same(s1.Result, s2.Result);
        }
        private SingletonEager GetEagerInstance()
        {
            return SingletonEager.GetInstance();
        }

        private SingletonLazy GetLazyInstance()
        {
            return SingletonLazy.Instance;
        }
    }
}
