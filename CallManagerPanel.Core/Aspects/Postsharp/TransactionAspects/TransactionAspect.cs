using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Transactions;

namespace CallManagerPanel.Core.Aspects.Postsharp.TransactionAspects
{
    /// <summary>
    /// Method gövdesini 'transaction' olarak çalıştırır. Hata olması durumunda tüm işlemler geri alınır.
    /// </summary>
    [PSerializable]
    public sealed class TransactionAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var transactionScope = new TransactionScope(TransactionScopeOption.Required);
            args.MethodExecutionTag = transactionScope;
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var transactionScope = (TransactionScope)args.MethodExecutionTag;
            transactionScope.Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var transactionScope = (TransactionScope)args.MethodExecutionTag;
            transactionScope.Dispose();
        }
    }
}
