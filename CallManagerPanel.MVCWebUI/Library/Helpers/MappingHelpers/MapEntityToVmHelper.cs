using CallManagerPanel.Core.Entities;
using CallManagerPanel.Entities.Concrete;
using CallManagerPanel.MVCWebUI.Models;
using System;
using System.Collections;
using System.Linq;

namespace CallManagerPanel.MVCWebUI.Library.Helpers.MappingHelpers
{
    // Command dizayn paterni kullanılmıştır.

    // Invoker class
    public static class MapEntityToVmHelper
    {
        #region invoker
        private static readonly Hashtable Commands;

        static MapEntityToVmHelper()
        {
            Commands = new Hashtable
            {
                { typeof(ContactVm), new ContactCommand() },
                { typeof(CallVm), new CallCommand() },
                { typeof(UserVm), new UserCommand() }
            };
        }

        /// <summary>
        /// item nesnesini T tipli nesneye dönüştürür.
        /// </summary>
        public static T MapTo<T>(this IEntity item) where T : class, IViewModel, new()
        {
            var command = (BaseCommand<T>)Commands[typeof(T)];
            return (T)Convert.ChangeType(command.Execute(item), typeof(T));
        }
        #endregion


        // Command Base
        private abstract class BaseCommand<TReturn> where TReturn : class, IViewModel, new()
        {
            public abstract TReturn Execute(IEntity entity);
        }


        #region command classes
        private class ContactCommand : BaseCommand<ContactVm>
        {
            private readonly Receiver _receiver;

            public ContactCommand()
            {
                _receiver = new Receiver();
            }

            public override ContactVm Execute(IEntity entity)
            {
                return _receiver.MapToContactVm(entity as Contact);
            }
        }

        private class CallCommand : BaseCommand<CallVm>
        {
            private readonly Receiver _receiver;

            public CallCommand()
            {
                _receiver = new Receiver();
            }

            public override CallVm Execute(IEntity entity)
            {
                return _receiver.MapToCallVm(entity as Call);
            }
        }

        private class UserCommand : BaseCommand<UserVm>
        {
            private readonly Receiver _receiver;

            public UserCommand()
            {
                _receiver = new Receiver();
            }

            public override UserVm Execute(IEntity entity)
            {
                return _receiver.MapToUserVm(entity as User);
            }
        }
        #endregion


        #region command methods
        private class Receiver
        {
            public ContactVm MapToContactVm(Contact contact)
            {
                return contact == null ? null : new ContactVm { Id = HashidsHelper.Encrypt(contact.Id), Phone = contact.Phone, CallReason = contact.CallReason, CallResult = contact.CallResult, Date = contact.Date };
            }

            public CallVm MapToCallVm(Call call)
            {
                // Call sınıfında User virtual bir property olduğu için database sorgusunda açıkca include edilmezse
                // call nesnesinde bu property tanımı olmaz ve buna erişmeye çalışıldığında hata fırlatır.
                string userFullName;
                try { userFullName = call.User?.Fullname; }
                catch { userFullName = null; }

                return call == null ? null : new CallVm { Id = HashidsHelper.Encrypt(call.Id), ContactId = HashidsHelper.Encrypt(call.ContactId), UserId = HashidsHelper.Encrypt(call.UserId), UserFullname = userFullName, IsAccess = call.IsAccess, Date = call.Date };
            }

            public UserVm MapToUserVm(User user)
            {
                return new UserVm { Roles = string.Join(",", user.Roles?.Select(x => x.Name).ToArray() ?? new string[0]), Fullname = user.Fullname, Username = user.Username, Password = user.Password };
            }
        }
        #endregion
    }
}