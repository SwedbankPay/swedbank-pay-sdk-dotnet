using System.Collections;

namespace Sample.AspNetCore.SystemTests.Test.Base;

public class Profiles
{
    public class ProfileDev : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari1 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari2 };
            yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
            yield return new object[] { Executions.Parallel, Environments.IPhoneSafari1 };
        }
    }

    public class ProfileInt : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari1 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari2 };
            yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
            yield return new object[] { Executions.Parallel, Environments.IPhoneSafari1 };
        }
    }

    public class ProfilePrep : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari1 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari2 };
            yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
            yield return new object[] { Executions.Parallel, Environments.IPhoneSafari1 };
        }
    }

    public class ProfilePro : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsChrome2 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox1 };
            yield return new object[] { Executions.Parallel, Environments.WindowsFirefox2 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari1 };
            yield return new object[] { Executions.Parallel, Environments.OsxSafari2 };
            yield return new object[] { Executions.Parallel, Environments.AndroidChrome1 };
            yield return new object[] { Executions.Parallel, Environments.IPhoneSafari1 };
        }
    }
}