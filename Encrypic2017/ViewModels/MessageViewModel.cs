using Encrypic2017.Data;
using Encrypic2017.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Popups;

namespace Encrypic2017.ViewModels
{
    class MessageViewModel : NotificationBase<Message>
    {
        MessageModel mm = new MessageModel();
        UserModel um = new UserModel();
        Message newMessage = new Message();
        Response res = new Response();
        public ObservableCollection<Message> searchResults = new ObservableCollection<Message>();
        public Search searchQuery = new Search();

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
            set { SetProperty(This.fileAttachment, value, () => This.fileAttachment = value); }
        }

        public string messageId
        {
            get { return This.messageId; }
            set { SetProperty(This.messageId, value, () => This.messageId = value); }
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
                newMessage.messageTo = messageTo;
                newMessage.sentAt = DateTime.Now.ToString();
                newMessage.secretkey = data.user.secretkey;
                newMessage.fileAttachment = fileAttachment;

                return await mm.postMessage(newMessage);
            }
        }

        public async Task<Response> searchMessages()
        {

            searchQuery.messageResults = null;

            string jsonString = await um.getFromLocalStorage();

            var data = JsonConvert.DeserializeObject<RootObject>(jsonString);

            var username = data.user.username;

            searchQuery.query = username;
            res = await mm.searchMessage(searchQuery);
            try
            {
                searchResults.Clear();
                var messages = JsonArray.Parse(res.data);
                convertJsonToMessages(messages);
            }
            catch (Exception exJA)
            {
                MessageDialog dialog = new MessageDialog(exJA.Message);
                await dialog.ShowAsync();
            }
            return res;
        }

        public async Task<Response> deleteMessage(Message message)
        {
            res = await mm.deleteMessage(message);
            
            return res;
        }

        public void convertJsonToMessages(JsonArray jsonData)
        {
            //searchResults = new ObservableCollection<User>();
            foreach (var item in jsonData)
            {
                // get the object
                var obj = item.GetObject();

                Message temp = new Message();

                // get each key value pair and sort it to the appropriate elements
                // of the class
                foreach (var key in obj.Keys)
                {
                    IJsonValue value;
                    if (!obj.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "_id":
                            temp.messageId = value.GetString();
                            break;
                        case "messageFrom": // based on generic object key
                            temp.messageFrom = value.GetString();
                            break;
                        case "messageTo":
                            temp.messageTo = value.GetString();
                            break;
                        case "sentAt":
                            temp.sentAt = value.GetString();
                            break;
                        case "secretkey":
                            temp.secretkey = value.GetString();
                            break;
                        case "fileAttachment":
                            temp.fileAttachment = value.GetString();
                            break;
                    }
                } // end foreach (var key in obj.Keys)
                searchResults.Add(temp);
            } // end foreach (var item in array)
        }
    }
}
