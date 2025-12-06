
namespace Practika.Models
{
    public class ActionLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public string ActionDetails { get; set; } = string.Empty;
        public DateTime ActionTime { get; set; }
    }
}