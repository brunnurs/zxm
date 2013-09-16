using System;
using System.Collections.Generic;
using System.Diagnostics;
using Zxm.Core.Common;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class EncrytedMessageService
    {
        private readonly EncryptionService _encryptionService;
        private readonly MessageService _messageService;

        public EncrytedMessageService(EncryptionService encryptionService,
                                      MessageService messageService)
        {
            //TODO Pos9: 7 Get User Settings Service
            _encryptionService = encryptionService;
            _messageService = messageService;
        }

        public event EventHandler<EventArgs<Message>> MessageSent;

        public void RequestMessages(Action<List<Message>> messageCallback)
        {
            _messageService.RequestMessages(list => RequestMessagesCallback(list, messageCallback));
        }

        public void SendMessage(Message newMessage, Action<Message, bool> messageSentCallback)
        {
            // Make a copy which can be used for the MessageSent-Event
            var originalMessage = new Message(newMessage);

            EncryptMessage(newMessage);

            _messageService.SendMessage(newMessage, (message, successfully) => MessageSentCallback(originalMessage, successfully, messageSentCallback));
        }

        private void EncryptMessage(Message newMessage)
        {
            var encryptedContent = _encryptionService.Encrypt(newMessage.Content, GetKey());
            newMessage.Content = encryptedContent;
        }

        private void RequestMessagesCallback(List<Message> list, Action<List<Message>> messageCallback)
        {
            list.ForEach(DecryptMessage);
            messageCallback(list);
        }

        private byte[] GetKey()
        {
            //TODO Pos9: 6 Do use UserSettingsService
            return EncryptionService.GetKeyFromPassword(Config.DefaultUserPassword);
        }

        private void DecryptMessage(Message message)
        {
            try
            {
                byte[] key = GetKey();
                var decryptedContent = _encryptionService.Decrypt(message.Content, key);
                message.Content = decryptedContent;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("failed to decrypt message from {0}. Exception: {1}", message.Sender, ex);
            }
        }

        private void MessageSentCallback(Message message, bool successfully, Action<Message, bool> messageSentCallback)
        {
            if (successfully)
            {
                if (MessageSent != null)
                {
                    MessageSent(this, new EventArgs<Message>(message));
                }
            }
            messageSentCallback(message, successfully);
        }
    }
}
