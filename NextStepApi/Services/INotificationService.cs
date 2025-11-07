using Job_Application.Models;

namespace Job_Application.Services
{
    public interface INotificationService
    {
        /// <summary>
        /// Create a notification for a specific user
        /// </summary>
        Task CreateNotification(
            int userId, 
            string title, 
            string message, 
            int? relatedEntityId = null,
            string notificationType = "General"
        );
        
        /// <summary>
        /// Send notifications to multiple users
        /// </summary>
        Task NotifyMultipleUsers(
            List<int> userIds, 
            string title, 
            string message, 
            string notificationType = "General"
        );
    }
}
