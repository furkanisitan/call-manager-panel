using CallManagerPanel.Core.Entities;
using CallManagerPanel.Entities.Concrete;
using CallManagerPanel.MVCWebUI.Models;
using System;
using System.Collections;

namespace CallManagerPanel.MVCWebUI.Library.Helpers.MappingHelpers
{
    // Command dizayn paterni kullanılmıştır.

    // Invoker class
    public static class MapVmToEntityHelper
    {
        #region invoker
        private static readonly Hashtable Commands;

        static MapVmToEntityHelper()
        {
            Commands = new Hashtable
            {
                { typeof(Contact), new ContactCommand() },
                { typeof(Call), new CallCommand() }
            };
        }

        /// <summary>
        /// item nesnesini T tipli nesneye dönüştürür.
        /// </summary>
        public static T MapTo<T>(this IViewModel item) where T : class, IEntity, new()
        {
            var command = (BaseCommand<T>)Commands[typeof(T)];
            return (T)Convert.ChangeType(command.Execute(item), typeof(T));
        }
        #endregion

        // Command Base
        private abstract class BaseCommand<TReturn> where TReturn : class, IEntity, new()
        {
            public abstract TReturn Execute(IViewModel viewModel);
        }

        #region command classes
        private class ContactCommand : BaseCommand<Contact>
        {
            private readonly Receiver _receiver;

            public ContactCommand()
            {
                _receiver = new Receiver();
            }

            public override Contact Execute(IViewModel viewModel)
            {
                return _receiver.MapToContact(viewModel as ContactVm);
            }
        }

        private class CallCommand : BaseCommand<Call>
        {
            private readonly Receiver _receiver;

            public CallCommand()
            {
                _receiver = new Receiver();
            }

            public override Call Execute(IViewModel viewModel)
            {
                return _receiver.MapToCall(viewModel as CallVm);
            }
        }
        #endregion


        #region command methods
        private class Receiver
        {
            public Contact MapToContact(ContactVm vm)
            {
                return vm == null ? null : new Contact { Id = HashidsHelper.Decrypt(vm.Id), Phone = vm.Phone, CallReason = vm.CallReason, CallResult = vm.CallResult, Date = vm.Date };
            }

            public Call MapToCall(CallVm vm)
            {
                return vm == null ? null : new Call { Id = HashidsHelper.Decrypt(vm.Id), ContactId = HashidsHelper.Decrypt(vm.ContactId), Date = vm.Date, IsAccess = vm.IsAccess };
            }
        }
        #endregion
    }
}