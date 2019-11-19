namespace Sample.AspNetCore.SystemTests.Test.Base
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Profiles
    {
        public class ProfileDEV : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari1 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari2 };
                yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
                yield return new object[] { Executions.Parallel, Environments.iPhoneSafari1 };
            }
        }

        public class ProfilePRO : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari1 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari2 };
                yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
                yield return new object[] { Executions.Parallel, Environments.iPhoneSafari1 };
            }
        }

        public class ProfileINT : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari1 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari2 };
                yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
                yield return new object[] { Executions.Parallel, Environments.iPhoneSafari1 };
            }
        }

        public class ProfilePREP : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
                yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari1 };
                yield return new object[] { Executions.Parallel, Environments.OSXSafari2 };
                yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
                yield return new object[] { Executions.Parallel, Environments.iPhoneSafari1 };
            }
        }


    }
}
