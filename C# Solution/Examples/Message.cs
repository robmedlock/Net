using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Examples
{
    public class Message
    {
        public virtual string Text { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public Message()
        {

        }
        public Message(string text)
        {
            Text = text;
        }

        public override bool Equals(object obj)
        {
            return (obj as Message).Id == Id;
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }

    public class Tweet : Message
    {
        public Tweet()
        {

        }
        public Tweet(string text)
        {
            Text = text;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (value.Length > 140)
                    throw new ArgumentOutOfRangeException("max 140 characters");
                base.Text = value;
            }
        }
    }

    public class SMS : Message
    {
        public SMS()
        {

        }
        public SMS(string text)
        {
            Text = text;
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (value.Length > 160)
                    throw new ArgumentOutOfRangeException("max 160 characters");
                base.Text = value;
            }
        }
    }

    public class MessageManager
    {
        private ISerializer serializer;
        private Dictionary<int, Message> messages = new Dictionary<int, Message>();

        public MessageManager(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public int AddMessage(Message message)
        {
            int nextId = messages.Count == 0 ? 1 : messages.Keys.Max() + 1;
            messages.Add(nextId, message);
            serializer.Write(messages);
            return nextId;
        }

        public bool RemoveMessage(int messageId)
        {
            bool removed = messages.Remove(messageId);
            serializer.Write(messages);
            return removed;
        }
        public ICollection<Message> SelectAllMessages()
        {
            messages = serializer.Read();
            return messages.Values;
        }
        public Message SelectMessageById(int id)
        {
            messages = serializer.Read();
            return messages.ContainsKey(id) ? messages[id] : null;
        }
    }

    public interface ISerializer
    {
        Dictionary<int, Message> Read();
        void Write(Dictionary<int, Message> messages);
    }

    public class Serializer : ISerializer
    {
        private string path = @"..\..\messages.json ";

        public Dictionary<int, Message> Read()
        {
            if (!File.Exists(path))
                return null;
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<int, Message>>(json);
        }

        public void Write(Dictionary<int, Message> messages)
        {
            string output = JsonConvert.SerializeObject(messages);
            File.WriteAllText(path, output);
        }
    }
}
