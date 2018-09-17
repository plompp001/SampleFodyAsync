using System.Diagnostics;
using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.Sample
{
    public class LogErrorAttribute : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            if (args.Exception == null)
            {
                return;
            }

            Debug.WriteLine(args.Exception);
        }
    }
}
