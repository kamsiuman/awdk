using System;
using System.Collections.Generic;

namespace Awdk.Skus.Framework.Common.EventManager
{
    public class PublishEvent
    {
        public string WorkspaceId { get; set; }
        public List<string> EntityIds { get; set; }
        public string EntityType { get; set; }
        public bool IsFirstTimePublished { get; set; }
        public DateTime PublishTime { get; set; }
    }
}