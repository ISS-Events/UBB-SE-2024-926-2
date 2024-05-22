using System.Data;
using System.Data.SqlClient;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Exceptions;
using CodeBuddies.MVVM;
namespace CodeBuddies.Repositories
{
    public class BuddyRepository : DBRepositoryBase, IBuddyRepository
    {
        public BuddyRepository() : base()
        {
        }

        public List<Buddy> GetAllBuddies()
        {
            List<Buddy> buddies = new ();

            DataSet buddyDataSet = new ();
            string selectAllBuddies = "SELECT * FROM Buddies";
            SqlCommand selectAllBuddiesCommand = new (selectAllBuddies, sqlConnection);
            dataAdapter.SelectCommand = selectAllBuddiesCommand;
            buddyDataSet.Clear();
            dataAdapter.Fill(buddyDataSet, "Buddies");

            foreach (DataRow buddyRow in buddyDataSet.Tables["Buddies"]?.Rows)
            {
                SqlDataAdapter notificationsDataAdapter = new ();

                DataSet notificationDataSet = new ();
                string notificationQuery = "SELECT * FROM Notification where ReceiverId = @id";
                SqlCommand selectAllNotificationsForSpecificBuddyCommand = new (notificationQuery, sqlConnection);
                notificationsDataAdapter.SelectCommand = selectAllNotificationsForSpecificBuddyCommand;
                selectAllNotificationsForSpecificBuddyCommand.Parameters.AddWithValue("@id", buddyRow["Id"]);
                notificationDataSet.Clear();
                notificationsDataAdapter.Fill(notificationDataSet, "Notification");

                List<Notification> notifications = new ();

                foreach (DataRow notificationRow in notificationDataSet.Tables["Notification"].Rows)
                {
                    Notification currentNotification;

                    if (notificationRow["Type"].ToString() == "invite")
                    {
                        currentNotification = new InviteNotification((long)notificationRow["Id"], (DateTime)notificationRow["Timestamp"], notificationRow["Type"].ToString(), notificationRow["Status"].ToString(), notificationRow["Description"].ToString(), (long)notificationRow["SenderId"], (long)notificationRow["ReceiverId"], (long)notificationRow["SessionId"], false);
                    }
                    else
                    {
                        currentNotification = new InfoNotification((long)notificationRow["Id"], (DateTime)notificationRow["Timestamp"], notificationRow["Type"].ToString(), notificationRow["Status"].ToString(), notificationRow["Description"].ToString(), (long)notificationRow["SenderId"], (long)notificationRow["ReceiverId"], (long)notificationRow["SessionId"]);
                    }

                    notifications.Add(currentNotification);
                }

                Buddy currentBudy = new ((long)buddyRow["Id"], buddyRow["BuddyName"].ToString(), buddyRow["ProfilePhotoUrl"].ToString(), buddyRow["Status"].ToString(), notifications);
                buddies.Add(currentBudy);
            }

            return buddies;
        }

        public List<Buddy> GetActiveBuddies()
        {
            return GetAllBuddies().Where(buddy => buddy.Status == "active").ToList();
        }

        public List<Buddy> GetInactiveBuddies()
        {
            return GetAllBuddies().Where(buddy => buddy.Status == "inactive").ToList();
        }

        public Buddy UpdateBuddyStatus(Buddy buddy)
        {
            buddy.Status = buddy.Status == "active" ? "inactive" : "active";
            return buddy;
        }

        public void ClearDatabase()
        {
            List<string> tables = new ()
            {
                "BuddiesSessions", "MessagesCodeReviews", "MessagesSessions", "CodeReviewsSessions", "Notification",
                "Sessions", "Messages", "CodeReviews", "CodeContributions", "Buddies"
            };
            foreach (string table in tables)
            {
                string deleteNotificationQuery = $"DELETE FROM {table}";
                using SqlCommand deleteCommand = new (deleteNotificationQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public void AddBuddy(long buddyId, string buddyName, string buddyProfile, string status)
        {
            string insertQuery = "INSERT INTO Buddies VALUES (@BuddyId, @BuddyName, @BuddyProfile, @Status)";
            try
            {
                using SqlCommand insertCommand = new (insertQuery, sqlConnection);
                insertCommand.Parameters.AddWithValue("@BuddyId", buddyId);
                insertCommand.Parameters.AddWithValue("@BuddyName", buddyName);
                insertCommand.Parameters.AddWithValue("@BuddyProfile", buddyProfile);
                insertCommand.Parameters.AddWithValue("@Status", status);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new EntityAlreadyExists(ex.Message);
            }
        }
    }
}
