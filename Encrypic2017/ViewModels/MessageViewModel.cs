using Encrypic2017.Data;
using Encrypic2017.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic2017.ViewModels
{
    class MessageViewModel : NotificationBase<Message>
    {
        MessageModel mm = new MessageModel();
        UserModel um = new UserModel();
        Message newMessage = new Message();
        Response res = new Response();
        User messageToUser = new User();

        public MessageViewModel(Message message = null) : base(message)
        {

        }

        public string messageFrom
        {
            get { return This.messageFrom; }
            set { SetProperty(This.messageFrom, value, () => This.messageFrom = value); }
        }

        public string messageTo
        {
            get { return This.messageTo; }
            set { SetProperty(This.messageTo, value, () => This.messageTo = value); }
        }

        public string sentAt
        {
            get { return This.sentAt; }
            set { SetProperty(This.sentAt, value, () => This.sentAt = value); }
        }

        public string secretkey
        {
            get { return This.secretkey; }
            set { SetProperty(This.secretkey, value, () => This.secretkey = value); }
        }

        public string fileAttachment
        {
            get { return This.fileAttachment; }
            set { SetProperty(This.secretkey, value, () => This.fileAttachment = value); }
        }

        public async Task<Response> sendMessage()
        {
            if (string.IsNullOrEmpty(fileAttachment))
            {
                res.data = "{'msg':'Please upload an image first.'}";
                res.status = "BadRequest";
                return res;
            }
            else
            {
                string jsonString = await um.getFromLocalStorage();

                var data = JsonConvert.DeserializeObject<RootObject>(jsonString);

                var username = data.user.username;

                newMessage.messageFrom = username;
                newMessage.messageTo = messageToUser.username;
                newMessage.sentAt = DateTime.Now.ToString();
                newMessage.secretkey = data.user.secretkey + "" + messageToUser.secretkey;
                newMessage.fileAttachment = fileAttachment;

                return await mm.postMessage(newMessage);
            }
        }
    }
}
