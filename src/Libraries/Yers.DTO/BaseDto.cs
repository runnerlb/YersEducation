using System;

namespace Yers.DTO
{
    [Serializable]
    public abstract class BaseDto
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}