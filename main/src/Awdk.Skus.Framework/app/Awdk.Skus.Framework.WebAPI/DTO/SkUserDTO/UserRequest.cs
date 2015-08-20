using System;


namespace Awdk.Skus.Framework.WebAPI.DTO.SkUserDTO
{
    public class UserRequest
    {
        public int JobId { get; set; }
        public int SkUserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
