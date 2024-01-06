using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GobangGameWcfService
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string PosterName { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public System.DateTime PostTime { get; set; }

        public Post(int id, string posterName, string title, string content, DateTime postTime)
        {
            Id = id;
            PosterName = posterName;
            Title = title;
            Content = content;
            PostTime = postTime;
        }
    }
}